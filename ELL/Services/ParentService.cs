using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ELL.Models;
using ELL.DBContext;
using System.Threading.Tasks;

namespace ELL.Services
{
    public class ParentService
    {
        private DBContext.DBContext dbContext;

        public ParentService()
        {
            dbContext = new DBContext.DBContext();
        }

        public async Task<IEnumerable<Parent>> GetAll()
        {
            List<Parent> parents = Enumerable.Empty<Parent>().ToList();

            using (SqlConnection db = dbContext.GetDBConnection())
            {
                db.Open();
                string query = @"SELECT ID,
                                            FIRSTNAME,
                                            LASTNAME,
                                            PHONE
                                    FROM PARENT";
                using (SqlCommand command = new SqlCommand(query, db))
                {
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    
                    // Read records
                    while (reader.Read())
                    {
                        var parent = new Parent();
                        parent.Id = Convert.ToInt32(reader["ID"]);
                        parent.FirstName = Convert.ToString(reader["FIRSTNAME"]);
                        parent.LastName = Convert.ToString(reader["LASTNAME"]);
                        parent.Phone = Convert.ToString(reader["PHONE"]);

                        parents.Add(parent);
                    }
                }
                db.Close();
            }

            return parents;
        }
        

    }
}