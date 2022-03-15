using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindexService 
    {
        IDataResult<List<Findex>> GetAllByUserId(int UserId);
        IResult Add(Findex findex);
        IResult Update(Findex findex);
        IResult Delete(int id);
        IDataResult<List<Findex>> GetAll();
        IDataResult<Findex> GetById(int id);
    }
}
