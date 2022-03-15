using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<DtoCustomerDetail>> GetCustomerDetails();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(int id);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int id);
    }
}
