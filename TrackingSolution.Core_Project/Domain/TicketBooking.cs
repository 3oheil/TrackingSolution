using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSolution.Core_Project.Domain
{
    public class TicketBooking
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
