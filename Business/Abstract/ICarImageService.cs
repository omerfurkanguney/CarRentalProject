using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService 
    {
        IDataResult<List<CarImage>> GetAllImagesByCarId(int CarId);

        IResult Add(CarImage carImage);
        IResult Update(CarImage carImage);
        IResult Delete(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
    }
}
