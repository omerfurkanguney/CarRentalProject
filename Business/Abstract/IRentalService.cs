using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService
    {
        IResult Deliver(Rental rental);
        IDataResult<RentalDetailDto> GetRentalDetailByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalsDetailByUserId(int userId);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetail();
        IDataResult<Rental> GetByCarId(int carId);

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);

    }
}
