using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class FindexManager : IFindexService
    {
        IFindexDal _findexDal;
        public FindexManager(IFindexDal findexDal)
        {
            _findexDal = findexDal;
        }
        public IResult Add(Findex findex)
        {
            _findexDal.Add(findex);
            return new SuccessResult(Messages.FindexAdded);
        }

       

        public IResult Delete(int id)
        {
            var result = _findexDal.Get(f => f.Id == id);
            _findexDal.Delete(result);
            return new SuccessResult(Messages.FindexDeleted);
        }

        public IDataResult<List<Findex>> GetAll()
        {
            return new SuccessDataResult<List<Findex>>(_findexDal.GetAll().ToList());
        }

        public IDataResult<List<Findex>> GetAllByUserId(int UserId)
        {
            return new SuccessDataResult<List<Findex>>(_findexDal.GetAll(f => f.UserId == UserId).ToList());
        }

        public IDataResult<Findex> GetById(int Id)
        {
            return new SuccessDataResult<Findex>(_findexDal.Get(f => f.Id == Id));
        }

        public IResult Update(Findex findex)
        {
            _findexDal.Update(findex);
            return new SuccessResult(Messages.FindexUpdated);
        }
    }
}
