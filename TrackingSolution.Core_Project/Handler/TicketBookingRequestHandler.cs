using TrackingSolution.Core_Project.Model;

namespace TrackingSolution.Core_Project.Handler
{
    public class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler(DataService.ITecketBookingService @object)
        {

        }

        public ServiceBookingResult BookService(TicketBookingRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            return new ServiceBookingResult
            {
                CustomerName = request.CustomerName,
                Email = request.Email,
                EventId = request.EventId,
                NumberOfTickets = request.NumberOfTickets
            };
        }
    }
}