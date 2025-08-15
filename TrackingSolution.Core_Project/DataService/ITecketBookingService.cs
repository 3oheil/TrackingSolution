using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSolution.Core_Project.Domain;

namespace TrackingSolution.Core_Project.DataService
{
    public interface ITecketBookingService
    {
        void Save(TicketBooking ticketBooking);
    }
}
