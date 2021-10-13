namespace SquareFish.Core
{
    public class BookingLeader:BaseEntity<int>
    {
        public int LeaderId { get; set; }
        public Leader Leader { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
