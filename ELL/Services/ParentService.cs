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
    public class ParentService : ServiceBase<EmergencyContact>
    {
        public ParentService() : base()
        {

        }

        public ParentService(ELLDBContext dbContext) : base(dbContext)
        {

        }

    }
}