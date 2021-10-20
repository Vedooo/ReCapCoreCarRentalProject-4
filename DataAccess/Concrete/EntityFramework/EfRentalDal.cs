using Core.DataAccess.EntityRepository;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthWindContext>, IRentalDal
    {
        public List<CarRentDetailDto> GetCarsDetails()
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join cu in context.CustomerOfRents
                             on r.CustomerId equals cu.CustomerId
                             select new CarRentDetailDto
                             {
                                 CarId = c.CarId,
                                 RentId = r.CustomerId,
                                 CarName = c.Description,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };          
                return result.ToList();

            }
        }

        public List<CarRentDetailDto> GetCarsDetailsByIds(int carId)
        {
            var resultList = GetCarsDetails();
            return resultList.Where(c => c.CarId == carId).ToList();
        }
    }
}
