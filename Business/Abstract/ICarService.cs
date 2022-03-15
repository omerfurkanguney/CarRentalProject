using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<DtoCarDetail>> GetCarsByColorId(int ColorId);
        IDataResult<List<DtoCarDetail>> GetCarsDetailByBrandId(int BrandId);
        IDataResult<List<DtoCarDetail>> GetCarDetail();
        IDataResult<List<DtoCarDetail>> GetCarDetailByCarId(int carId);

        IDataResult<List<DtoCarDetail>> GetbyBrandIdandColorId(int brandId, int colorId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);

    }
}
