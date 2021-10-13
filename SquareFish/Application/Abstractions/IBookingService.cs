using SquareFish.Application.Dtos;
using SquareFish.Core;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SquareFish.Application
{
    public interface IBookingService
    {
        Task<Booking> Create(int price, DateTime? startDate, string name, List<int> leaders, string currency);
        Task<Booking> Update(int id, int price, DateTime? startDate, string name, BookingStatus status, string currency);
        Task<bool> Delete(int id);
        Task<PagedResults<BookingDto>> Get(int result, int page, DateTime? startDate, int? status);
    }
}
