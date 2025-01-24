using Castle.Core.Logging;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;

namespace GameStore.Tests
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _gameRepositoryMock;
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;

        private List<Player> _players = new List<Player>
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
                Year = 2017,
                Players = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        public GameServiceTests()
        {
            _gameRepositoryMock = new Mock<IGameRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
        }

        [Fact]
        void GetById_Ok()
        {
            //Arrange
            var gameId = _games[0].Id;

            _gameRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _games.FirstOrDefault(g => g.Id == id));

            //var logger = Mock.Of<ILogger<GamesService>>();
            var loggerMock = new Mock<ILogger<GamesService>>();
            ILogger<GamesService> logger = loggerMock.Object;

            //Act
            var gameService = new GamesService(
                _gameRepositoryMock.Object,
                logger,
                _playerRepositoryMock.Object);

            var result = gameService.GetById(gameId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(gameId, result.Id);
        }

        [Fact]
        void GetById_NotExistingId()
        {
            //Arrange
            var gameId = Guid.NewGuid().ToString();

            _gameRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _games.FirstOrDefault(g => g.Id == id));

            //var logger = Mock.Of<ILogger<GamesService>>();
            var loggerMock = new Mock<ILogger<GamesService>>();
            ILogger<GamesService> logger = loggerMock.Object;

            //Act
            var gameService = new GamesService(
                _gameRepositoryMock.Object,
                logger,
                _playerRepositoryMock.Object);

            var result = gameService.GetById(gameId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        void GetById_WrongGuidId()
        {
            //Arrange
            var gameId = "avbbfd";

            _gameRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _games.FirstOrDefault(g => g.Id == id));

            //var logger = Mock.Of<ILogger<GamesService>>();
            var loggerMock = new Mock<ILogger<GamesService>>();
            ILogger<GamesService> logger = loggerMock.Object;

            //Act
            var gameService = new GamesService(
                _gameRepositoryMock.Object,
                logger,
                _playerRepositoryMock.Object);

            var result = gameService.GetById(gameId);

            //Assert
            Assert.Null(result);
        }
    }
}
