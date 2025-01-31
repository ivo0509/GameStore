using Moq;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using GameStore.BL.Interfaces;
using Microsoft.Extensions.Logging;


namespace GameStore.Tests
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _gameRepositoryMock;
        private readonly Mock<IPublisherRepository> _publisherRepositoryMock;

        private List<Game> _games = new List<Game>()
        {
            new Game()
             {
               Id = "9abda586-ff83-447f-b7e1-05dacb360c88",
               PublisherId = 1,
               Name = "Counter-Strike 2",
               ReleaseDate = DateTime.Now,
               Publishers = ["16b080b2-f3a0-4f4c-b664-eb75989f4480" ,
               "259ffdd2-0b1d-44d2-9782-a79f9ca0f8d3"]



            },
            new Game()
            {
                Id = "27015e6e-7f16-4d65-a589-a31a0066e782",
                PublisherId = 2,
                Name = "FC25",
                ReleaseDate = DateTime.Now,
                Publishers = [
                    "259ffdd2-0b1d-44d2-9782-a79f9ca0f8d3",
                    "2cfae51b-5395-446e-8679-5a5a8f1c6c3e"]
            },
            new Game()
            {
                Id = "5a4cfa98-4fdb-4414-b5fb-d23d56af1559",
                PublisherId = 3,
                Name = "Fortnite",
                ReleaseDate = DateTime.Now,
                Publishers = [
                    "53fa6997-8557-4c86-9927-82ba3c0843f3",
                    "16b080b2-f3a0-4f4c-b664-eb75989f4480"
                ]
            },


            new Game()
            {
                Id = "2c12f687-7c73-42d3-9d91-936416ffdced",
                PublisherId = 4,
                Name = "PUBG",
                ReleaseDate = DateTime.Now,
                Publishers = [
                    "53fa6997-8557-4c86-9927-82ba3c0843f3",
                    "bdfb76c3-f3e1-403b-b23b-c4bffbeaa6b3"
                ]
            }
        };

        private List<Publisher> _publishers = new List<Publisher>
        {
             new Publisher()
            {
                Id = "16b080b2-f3a0-4f4c-b664-eb75989f4480",
                Name = "Ivan"
            },
            new Publisher()
            {
                Id = "bdfb76c3-f3e1-403b-b23b-c4bffbeaa6b3",
                Name = "Velin"
            },
            new Publisher()
            {
                Id = "53fa6997-8557-4c86-9927-82ba3c0843f3",
                Name = "Hristo"
            },
            new Publisher()
            {
                Id = "2cfae51b-5395-446e-8679-5a5a8f1c6c3e",
                Name = "Dimitrichko"
            },
            new Publisher()
            {
                Id = "259ffdd2-0b1d-44d2-9782-a79f9ca0f8d3",
                Name = "Stoqn"
            },
            
        };

        public GameServiceTests()
        {
            _publisherRepositoryMock = new Mock<IPublisherRepository>();
            _gameRepositoryMock = new Mock<IGameRepository>();
        }

        [Fact]
        void GetGamesById_ReturnsData()
        {
            // Arrange
            var gameId = _games[0].Id;

            _gameRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _games.FirstOrDefault(x => x.Id == id));

            var gameService = new GameService(_gameRepositoryMock.Object, _publisherRepositoryMock.Object);

            // Act
            var result = gameService.GetById(gameId);

            // Assert
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

            //var logger = Mock.Of<ILogger<MoviesService>>();
            var loggerMock = new Mock<ILogger<GameService>>();
            ILogger<GameService> logger = loggerMock.Object;

            //Act
            var gameService = new GameService(
                _gameRepositoryMock.Object,
                _publisherRepositoryMock.Object);

            var result = gameService.GetById(gameId);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        void GetById_WrongGuidId()
        {
            //Arrange
            var gameId = "assegqf";

            _gameRepositoryMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns((string id) => _games.FirstOrDefault(g => g.Id == id));

            //var logger = Mock.Of<ILogger<MoviesService>>();
            var loggerMock = new Mock<ILogger<GameService>>();
            ILogger<GameService> logger = loggerMock.Object;

            //Act
            var gameService = new GameService(
                _gameRepositoryMock.Object,
                _publisherRepositoryMock.Object);

            var result = gameService.GetById(gameId);

            //Assert
            Assert.Null(result);
        }
    }
}
    
