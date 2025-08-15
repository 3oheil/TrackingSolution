using Moq;
using Shouldly;
using TrackingSolution.Core_Project.DataService;
using TrackingSolution.Core_Project.Domain;
using TrackingSolution.Core_Project.Handler;
using TrackingSolution.Core_Project.Model;

namespace TrackingSolution.Core.Test
{
    public class TicketBookingRequestHandlerTest
    {
        private readonly TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;
        private Mock<ITecketBookingService> _ticketBookingServiceMock;

        public TicketBookingRequestHandlerTest()
        {
            //// Arrange
            var _request = new TicketBookingRequest
            {
                CustomerName = "John Doe",
                Email = "TestEmail@gmail.com",
                EventId = 1,
                NumberOfTickets = 2
            };

            _ticketBookingServiceMock = new Mock<ITecketBookingService>();
            _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);

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
            TicketBooking savedBooking = null;
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>())).
                Callback<TicketBooking>(booking =>
                {
                    savedBooking = booking;
                });
            _handler.BookService(_request);

            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);

            savedBooking.ShouldNotBeNull();
            savedBooking.CustomerName.ShouldBe(_request.CustomerName);
            savedBooking.Email.ShouldBe(_request.Email);
            savedBooking.EventId.ShouldBe(_request.EventId);


        }
    }
}
