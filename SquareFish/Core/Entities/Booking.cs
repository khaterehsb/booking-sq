using SquareFish.Core;
using SquareFish.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquareFish.Core
{


    public enum BookingStatus
    {
        pendding = 0,
        verified = 1,
        canceled = 2
    }
    public class Booking : BaseEntity<int>
    {
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public BookingStatus Status { get; private set; }
        public DateTime? StartDate { get; private set; }
        public int Price { get; private set; }
        public string Currency { get; private set; }
        public ICollection<BookingLeader> BookingLeader { get; private set; }
        public void ChangeStatus()
        {

        }
        public static Booking Create(int price, DateTime? startDate, string name, string currency)
        {
            var item = new Booking();

            if (startDate != null && ((DateTime)startDate).Date > DateTime.Now.Date)
                item.StartDate = (DateTime)startDate;
            else if (startDate != null && ((DateTime)startDate).Date < DateTime.Now.Date)
                throw new InvalidInputException($"StartDate must be greater than today");

            item.Price = price;

            if (string.IsNullOrEmpty(name))
                throw new InvalidInputException($"Name must have value");

            item.Currency = currency;
            item.Status = BookingStatus.pendding;
            item.CreatedAt = DateTime.Now;
            return item;
        }
        public void Update(int price, DateTime? startDate, string name, BookingStatus status, string currency)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidInputException($"Name must have value");

            //if (leaders == null || leaders.Count > 0)
            //    throw new InvalidInputException($"Leaders must have value");
            //Leaders = leaders;
            if (Status == BookingStatus.verified && status == BookingStatus.pendding)
                throw new InvalidAppOperationException($"Invalid booking status");

            StartDate = startDate;
            Price = price;
            Currency = currency;
            Name = name;
            Status = status;
        }
    }
}
