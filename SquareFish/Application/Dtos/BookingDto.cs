using SquareFish.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquareFish.Application.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public BookingStatus Status { get;  set; }
        public DateTime? StartDate { get;  set; }
        public int Price { get;  set; }
        public string Currency { get;  set; }
        public List<LeadersDto> Leaders { get; set; }
        public static BookingDto Convert(Booking booking, List<Leader> leaders)
        {
            var dto = new BookingDto
            {
                Id= booking.Id,
                CreatedAt = booking.CreatedAt,
                Currency = booking.Currency,
                Name = booking.Name,
                Price = booking.Price,
                StartDate = booking.StartDate,
                Status = booking.Status,
                Leaders = new List<LeadersDto>()
            };
            leaders.ForEach(x => dto.Leaders.Add(new LeadersDto { Name = x.Name, Id = x.Id }));
            return dto;
        }
    }
}
