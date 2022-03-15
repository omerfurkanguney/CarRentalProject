using Business.Abstract;
using Business.Constant;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }
        public IResult Add(Rental rental)
        {
            IResult results = BusinessRules.Run(CheckIfCarInUse(rental.CarId));
            if (results != null)
            {
                return results;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);
            _rentalDal.Delete(result);
            return new SuccessResult(Messages.RentalDeleted);
        }

        //public IResult Delete(Rental rental)
        //{
        //    IResult results = BusinessRules.Run(CheckIfDelete(rental.Id));
        //    if (results != null)
        //    {
        //        return results;
        //    }

        //    _rentalDal.Delete(rental);
        //    return new SuccessResult(Messages.RentalDeleted);
        //}

        //bu metot çagrıldıgında arac teslim edildi.
        //teslim edilme tarihi verildi.
        public IResult Deliver(Rental rental)
        {
            IResult results = BusinessRules.Run(CheckIfDeliver(rental.Id));
            if (results != null)
            {
                return results;
            }

            return new SuccessResult(Messages.RentalDelivered);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),
               Messages.RentalGetAllSuccess);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));

        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
        }

        public IDataResult<RentalDetailDto> GetRentalDetailByCarId(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId).LastOrDefault();
            return new SuccessDataResult<RentalDetailDto>(result, Messages.RentalGetAllSuccess);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetailByUserId(int userId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.UserId == userId).ToList();
            return new SuccessDataResult<List<RentalDetailDto>>(result, Messages.RentalGetAllSuccess);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckIfCarInUse(int carId)
        {
            //bu degerlere sahip bir sey döndürüyorsa arac kullanımdadır
            var results = _rentalDal.GetAll(r => r.CarId == carId);
            foreach (var result in results)
            {
                if (result.ReturnDate == null || result.RentDate > result.ReturnDate)
                {
                    return new ErrorResult(Messages.RentalCheckIsCarReturnError);
                }
            }

            return new SuccessResult();

        }

        private IResult CheckIfDelete(int Id)
        {
            var result = _rentalDal.Get(p => p.Id == Id);
            if (result == null)
            {
                return new ErrorResult(Messages.NoRecording);
            }

            return new SuccessResult();
        }

        private IResult CheckIfDeliver(int rentalId)
        {
            var result = _rentalDal.Get(p => p.Id == rentalId);
            if (result.ReturnDate != null)
            {
                return new ErrorResult(Messages.NoRecording);
            }
            result.ReturnDate = DateTime.Now.Date;
            Update(result);
            return new SuccessResult();
        }
    }
}
