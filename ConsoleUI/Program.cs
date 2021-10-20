using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfRentalManager rentalManager = new EfRentalManager(new EfRentalDal());

            var result = rentalManager.GetCarDetail();
            foreach (var detail in result.Data)
            {
                Console.WriteLine("{0} / {1} / {2} / {3} / {4}",detail.CarId,detail.RentId,detail.CarName,detail.RentDate,detail.ReturnDate);
            }

            Console.ReadLine();
        }
        
    }
}
