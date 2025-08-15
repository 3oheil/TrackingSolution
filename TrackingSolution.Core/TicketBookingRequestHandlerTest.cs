using Shouldly;
using TrackingSolution.Core_Project.Handler;
using TrackingSolution.Core_Project.Model;

namespace TrackingSolution.Core.Test
{
    public class TicketBookingRequestHandlerTest
    {
        private readonly TicketBookingRequestHandler _handler;
        public TicketBookingRequestHandlerTest()
        {
            _handler = new TicketBookingRequestHandler();
        }

        [Fact]
        public void Should_Return_TicketBookingRequest_When_ValidInput()
        {
            //// Arrange
            var handler = new TicketBookingRequestHandler();
            var request = new TicketBookingRequest
            {
                CustomerName = "John Doe",
                Email = "TestEmail@gmail.com",
                EventId = 1,
                NumberOfTickets = 2
            };

            //Act
            ServiceBookingResult result = handler.BookService(request);

            // Assertation
            Assert.NotNull(result);
            Assert.Equal(request.CustomerName, result.CustomerName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.EventId, result.EventId);
            Assert.Equal(request.NumberOfTickets, result.NumberOfTickets);

            // Assert by Shouldly
            result.ShouldNotBeNull();
            result.CustomerName.ShouldBe(request.CustomerName);
            result.Email.ShouldBe(request.Email);
            result.EventId.ShouldBe(request.EventId);
            result.NumberOfTickets.ShouldBe(request.NumberOfTickets);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            // Shouldly
            var exception = Should.Throw<ArgumentNullException>(() => _handler.BookService(null));
            exception.ParamName.ShouldBe("request");
            // Assertiation
            Assert.Throws<ArgumentNullException>(() => _handler.BookService(null));
        }

        [Fact]
        public void Should_Save_Ticket_Booking_Request()
        {

        }
    }
}
