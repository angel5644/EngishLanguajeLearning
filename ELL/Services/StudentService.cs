using System;
using System.Collections.Generic;
using ELL.Models;
using ELL.DBContext;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ELL.Services
{
    public class StudentService : ServiceBase<Student>
    {
        public StudentService() : base()
        {

        }

        public StudentService(ELLDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Student>> GetALlIncludeContact()
        {
            var students = this.dataContext.Students.Include(s => s.EmergencyContact);

            return await students.ToListAsync();
        }
    }
}