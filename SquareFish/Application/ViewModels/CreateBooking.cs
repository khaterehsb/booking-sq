using SquareFish.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SquareFish.Application.ViewModels
{
    [Contract]
    public class CreateBooking
    {
        public int Price { get; set; }
        public DateTime? StartDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<int> Leaders { get; set; }
        [Required]
        public string Currency { get; set; }
    }
    [Contract]
    public class UpdateBooking
    {
        [Required]
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime? StartDate { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<int> Leaders { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public BookingStatus Status { get; set; }
    }
}
