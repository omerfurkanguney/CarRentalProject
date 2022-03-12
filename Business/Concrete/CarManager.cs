using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal,ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().ToList());
        }

        public IDataResult<List<DtoCarDetail>> GetbyBrandIdandColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id));
        }

        public IDataResult<List<DtoCarDetail>> GetCarDetail()
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<DtoCarDetail>> GetCarDetailByCarId(int carId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(c=>c.Id == carId));
        }

        public IDataResult<List<DtoCarDetail>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(c => c.ColorId == ColorId));
        }

        public IDataResult<List<DtoCarDetail>> GetCarsDetailByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<DtoCarDetail>>(_carDal.GetCarDetails(c => c.BrandId == BrandId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
