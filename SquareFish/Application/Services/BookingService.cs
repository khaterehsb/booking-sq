using Microsoft.EntityFrameworkCore;
using SquareFish.Application.Dtos;
using SquareFish.Core;
using SquareFish.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquareFish.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingLeaderRepository _bookingLeaderRepository;
        private readonly ILeaderRepository _leaderRepository;

        public BookingService(IBookingRepository bookingRepository, IBookingLeaderRepository bookingLeaderRepository, ILeaderRepository leaderRepository)
        {
            _bookingRepository = bookingRepository;
            _bookingLeaderRepository = bookingLeaderRepository;
            _leaderRepository = leaderRepository;
        }

        public async Task<Booking> Create(int price, DateTime? startDate, string name, List<int> leaders, string currency)
        {
            if (leaders == null || leaders.Count > 0)
                throw new InvalidInputException($"Leaders must have value");

            var booking = Booking.Create(price, startDate, name, currency);
            await _bookingRepository.AddAsync(booking);
            var tasks = new List<Task>();
            foreach (var item in leaders)
            {
                tasks.Add(_bookingLeaderRepository.AddAsync(new BookingLeader
                {
                    LeaderId = item,
                    BookingId = booking.Id
                }));
            }
            Task.WaitAll(tasks.ToArray());
            return booking;
        }

        public async Task<bool> Delete(int id)
        {
            await _bookingRepository.DeleteAsync(id);
            await _bookingLeaderRepository.DeleteAsync(x => x.BookingId == id);
            return true;
        }

        public async Task<PagedResults<BookingDto>> Get(int result, int page, DateTime? startDate, int? status)
        {
            var res = await _bookingRepository.BrowseAsync(x =>
                                                   (status == null || (int)x.Status == Convert.ToInt32(status) &&
                                                   (startDate == null || x.StartDate.Value.Date == startDate.Value.Date)),
                                                  new PagedQuery(page, result, "CreatedAt", "desc"),
                                                  c => c.Include(a => a.BookingLeader));
            var dtoList = new List<BookingDto>();
            foreach (var item in res.Items)
            {
                var leaders = await _leaderRepository.GetAsync(x => item.BookingLeader.Select(c => c.LeaderId).ToList().Contains(x.Id));
                dtoList.Add(BookingDto.Convert(item, leaders));
            }

           return PagedResults<BookingDto>.Create(dtoList, res.CurrentPage, res.PageSize, res.PageCount, res.RowCount);
        }


        public async Task<Booking> Update(int id, int price, DateTime? startDate, string name, BookingStatus status, string currency)
        {
            var item = await _bookingRepository.GetAsync(id);
            item.Update(price, startDate, name, status, currency);
            await _bookingRepository.UpdateAsync(item);
            return item;
        }
    }
}
