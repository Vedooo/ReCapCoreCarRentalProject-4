using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Results.DataResultOptions.DataResults;
using Core.Utilities.Results.ResultOptions.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class EfRentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public EfRentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = IsCarAvaible(rental.CarId);
            if (result.Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalInfoAdded);
            }
            else
            {
                return new ErrorResult(result.Message);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalProcessDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.MaintainanceTimeRental);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int rentId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentId == rentId));
        }

        public IDataResult<List<CarRentDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarRentDetailDto>>(_rentalDal.GetCarsDetails());
        }

        public IDataResult<List<CarRentDetailDto>> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<List<CarRentDetailDto>>(_rentalDal.GetCarsDetailsByIds(carId),Messages.RentalsDetailsListedById);
        }

        public IResult IsCarAvaible(int carId)
        {
            if (IsCarAvaible(carId).Success)
            {
                if (IsCarReturned(carId).Success)
                {
                    return new SuccessResult(Messages.RentalInfoAdded);
                }
                return new ErrorResult(Messages.UnavaibleRentProcess);
            }
            return new SuccessResult(Messages.RentalInfoAdded);
        }

        public IResult IsCarEverRented(int carId)
        {
            if (_rentalDal.GetAll(r => r.CarId == carId).Any())
            {
                return new SuccessResult(Messages.CarRentedBefore);
            }
            return new ErrorResult(Messages.CarDidntRentBefore);
        }

        public IResult IsCarReturned(int carId)
        {
            if (_rentalDal.GetAll(r => (r.CarId == carId) && (r.ReturnDate == null)).Any())
            {
                return new ErrorResult(Messages.CarIsNotHere);
            }
            return new SuccessResult(Messages.CarIsHere);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalProcessUpdated);
        }
    }
}
