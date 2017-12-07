﻿using ELL.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELL.Services
{
    public abstract class ServiceBase<T> where T: class 
    {

        protected ELLDBContext dataContext;
        private readonly IDbSet<T> dbset;

        protected ServiceBase()
        {
            dataContext = new ELLDBContext();
            dbset = DataContext.Set<T>();
        }

        protected ServiceBase(ELLDBContext dbContext)
        {
            dataContext = dbContext;
            dbset = DataContext.Set<T>();
        }

        protected ELLDBContext DataContext
        {
            get { return dataContext ?? (dataContext = new ELLDBContext()); }
        }

        public async Task<T> Get(int id)
        {
            return dbset.Find(id);

            //return await dbset.FindAsync(id);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> @where)
        {
            return await dbset.AnyAsync(where);
        }

        public async Task<T> Get(Expression<Func<T, bool>> @where)
        {
            return await dbset.Where(where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> @where)
        {
            return await dbset.Where(where).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbset.ToListAsync();
        }


        public async Task<int> Update(T entity)
        {
            try
            {
                dbset.Attach(entity);
                DataContext.Entry(entity).State = EntityState.Modified;

                return await Save();
            }
            catch
            {
                DataContext.Entry(entity).State = EntityState.Detached;
                throw;
            }
        }

        public async Task<int> Save()
        {
            return await DataContext.SaveChangesAsync();
        }

        public async Task<int> Create(T entity)
        {
            try
            {
                dbset.Add(entity);
                return await Save();
            }
            catch
            {
                DataContext.Entry(entity).State = EntityState.Detached;
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            var entity = await Get(id);
            dbset.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where, string order, bool descending, int take)
        {
            if(take <= 0)
            {
                if (descending)
                {
                    return await dbset.OrderByDescending(order).Where(where).ToListAsync();
                }
                else
                {
                    return await dbset.OrderBy(order).Where(where).ToListAsync();
                }
            }
            else
            {
                if (descending)
                {
                    return await dbset.OrderByDescending(order).Where(where).Take(take).ToListAsync();
                }
                else
                {
                    return await dbset.OrderBy(order).Where(where).Take(take).ToListAsync();
                }
            }            
        }

        public virtual void LoadCollection(T model,string collectionName)
        {
            dataContext.Entry<T>(model).Collection(collectionName).Load();

        }

        public async Task<int> Count(Expression<Func<T, bool>> where)
        {
            return await dbset.Where(where).CountAsync();
        }
    }

    static class IOrderedQueryable
    {
        #region Order By String Column Name
        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty); // I don't care about some naming
            MemberExpression property;
            
            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields. 
                String[] childProperties = propertyName.Split('.');
                var childProperty = typeof(T).GetProperty(childProperties[0]);
                property = Expression.MakeMemberAccess(param, childProperty);

                for (int i = 1; i < childProperties.Length; i++)
                {
                    Type t = childProperty.PropertyType;
                    if (!t.IsGenericType)
                    {
                        childProperty = t.GetProperty(childProperties[i]);
                    }
                    else
                    {
                        childProperty = t.GetGenericArguments().First().GetProperty(childProperties[i]);
                    }

                    property = Expression.MakeMemberAccess(property, childProperty);
                }
            }
            else
            {
                property = Expression.PropertyOrField(param, propertyName);
            }

            LambdaExpression sort = Expression.Lambda(property, param);

            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, false);
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, false);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, true);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, true);
        }
        #endregion
    }
}