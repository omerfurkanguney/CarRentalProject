using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAllByUserId(int UserId);
        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(int id);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int id);
    }
}
