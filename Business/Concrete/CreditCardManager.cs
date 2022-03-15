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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCard;
        public CreditCardManager(ICreditCardDal creditCard)
        {
            _creditCard = creditCard;
        }
        public IResult Add(CreditCard creditCard)
        {
            _creditCard.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

      

        public IResult Delete(int id)
        {
            var result = _creditCard.Get(cc => cc.Id == id);
            _creditCard.Delete(result);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll().ToList());
        }

        public IDataResult<List<CreditCard>> GetAllByUserId(int UserId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll(c => c.UserId == UserId).ToList());

        }

        public IDataResult<CreditCard> GetById(int Id)
        {
            return new SuccessDataResult<CreditCard>(_creditCard.Get(c => c.Id == Id));
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCard.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
