using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ELL.Models;
using ELL.DBContext;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace ELL.Services
{
    public class PaymentService : ServiceBase<Payment>
    {
        public PaymentService() : base()
        {

        }

        public PaymentService(ELLDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Payment>> GetALlIncludeStudent()
        {
            var payments = this.dataContext.Payments.Include(p => p.Student);

            return await payments.ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByStudentId(int studentId)
        {
            var payments = await this.dataContext.Payments.Include(p => p.Student)
                                                         .Where(p => p.StudentId == studentId)
                                                         .ToListAsync();

            return payments;
        }
    }
}