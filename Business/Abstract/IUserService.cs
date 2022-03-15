using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
      User GetByEmail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(int id);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);


    }
}
