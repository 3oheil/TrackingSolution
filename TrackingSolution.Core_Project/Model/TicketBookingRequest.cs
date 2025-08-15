namespace TrackingSolution.Core_Project.Model
{
    public class TicketBookingRequest
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
        public int NumberOfTickets { get; set; }
    }
}