using Shouldly;
using TrackingSolution.Core_Project.Domain;
using TrackingSolution.Core_Project.Handler;
using TrackingSolution.Core_Project.Model;

namespace TrackingSolution.Core.Test
{
    public class TicketBookingRequestHandlerTest
    {
        private readonly TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;

        public TicketBookingRequestHandlerTest()
        {
            //// Arrange
            _handler = new TicketBookingRequestHandler();
            var _request = new TicketBookingRequest
            {
                CustomerName = "John Doe",
                Email = "TestEmail@gmail.com",
                EventId = 1,
                NumberOfTickets = 2
            };
        }

        [Fact]
        public void Should_Return_TicketBookingRequest_When_ValidInput()
        {
            

            //Act
            ServiceBookingResult result = _handler.BookService(_request);

            // Assertation
            Assert.NotNull(result);
            Assert.Equal(_request.CustomerName, result.CustomerName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.EventId, result.EventId);
            Assert.Equal(_request.NumberOfTickets, result.NumberOfTickets);

            // Assert by Shouldly
            result.ShouldNotBeNull();
            result.CustomerName.ShouldBe(_request.CustomerName);
            result.Email.ShouldBe(_request.Email);
            result.EventId.ShouldBe(_request.EventId);
            result.NumberOfTickets.ShouldBe(_request.NumberOfTickets);
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
