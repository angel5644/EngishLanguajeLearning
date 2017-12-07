using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ELL.Models;
using ELL.DBContext;
using System.Threading.Tasks;
using ELL.Services;

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

    }
}