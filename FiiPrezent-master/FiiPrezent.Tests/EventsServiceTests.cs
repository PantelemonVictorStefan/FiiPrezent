using FiiPrezent.Services;
using Shouldly;
using Xunit;

namespace FiiPrezent.Tests
{
    public class EventsServiceTests
    {
        [Fact]
        public void WhenTryingToRegisterWithAnInvalidCodeReturnsError()
        {
            var service = new EventsService();
            var result = service.RegisterParticipant("bad code", "test participant");
            result.ShouldBeNull();
        }

        [Fact(Skip = "not implemented")]
        public void WhenTryingToRegisterWithAValidCodeReturnsSuccess()
        {

        }

        [Fact(Skip = "not implemented")]
        public void WhenTryingToRegisterWithAValidCodeAddsParticipantToEvent()
        {
            // either interaction testing with moq or use an in memory repo
        }
    }
}
