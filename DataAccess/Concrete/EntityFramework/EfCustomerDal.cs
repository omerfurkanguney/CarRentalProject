using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDatabaseContext>, ICustomerDal
    {
        public List<DtoCustomerDetail> GetCustomersDetail()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from u in context.Users
                             join cus in context.Customers
                             on u.Id equals cus.UserId
                             select new DtoCustomerDetail
                             {
                                 UserId = u.Id,
                                 UserName = u.FirstName + " " + u.LastName,
                                 Email = u.Email,
                                 CompanyName = cus.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
