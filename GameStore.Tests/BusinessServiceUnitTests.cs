using Moq;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;

namespace GameStore.Tests
{
    public class BusinessServiceUnitTests
    {
        private readonly Mock<IGameRepository> 
            _gameRepositoryMock;
        private readonly Mock<IPlayerRepository> 
            _playerRepositoryMock;

        private List<Player> _players = new List<Player>()
        {
            new Player()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Ivan"
            },
            new Player()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Gosho"
            },
            new Player()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Petur"
            },
        };

        private List<Game> _games = new List<Game>()
        {
            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Counter-Strike 2",
                Year = 2012,
                Players = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Fortnite",
                Year = 2015,
                Players = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        public BusinessServiceUnitTests()
        {
            _gameRepositoryMock = new Mock<IGameRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
        }

        [Fact]
        public void GetAllGames_Ok()
        {
            //setup
            var expectedCount = 2;

            _gameRepositoryMock.Setup(x => 
                    x.GetAll())
                .Returns(_games);
            _playerRepositoryMock.Setup(x => 
                    x.GetById(It.IsAny<string>()))
                .Returns((string id) =>
                    _players.FirstOrDefault(x => x.Id == id));

            //inject
            var businessService = new BusinessService(
                _gameRepositoryMock.Object,
                _playerRepositoryMock.Object);

            //act
            var result = 
                businessService.GetAllGames();

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }
    }
}