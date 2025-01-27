using Moq;
using GameStore.BL.Services;
using GameStore.DL.Interfaces;
using GameStore.Models.DTO;
using GameStore.BL.Interfaces;


namespace GameStore.Tests
{
    public class BlGameServiceUnitTest
    {
        private readonly Mock<IGameService> _gameServiceMock;
        private readonly Mock<ISellerRepository> _sellerRepositoryMock;

        public static List<Game> GameData = new List<Game>()
        {
          new Game()
            {
                Id = Guid.NewGuid().ToString(),
                SellerId = 1,
                Title = "Counter-Strike 2",
                ReleaseDate = new DateTime(2005,05,07),


            },
            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                SellerId = 2,
                Title = "Fortnite",
                ReleaseDate = new DateTime(2005,05,07),


            },


            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                SellerId = 1,
                Title = "FC25",
               ReleaseDate = new DateTime(2005,05,07)



            },

            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                SellerId = 3,
                Title = "PUBG",
                ReleaseDate = new DateTime(2005,05,07),


            },

            new Game()
            {
                Id = Guid.NewGuid().ToString(),
                SellerId = 4,
                Title = "Phasmophobia",
                ReleaseDate = new DateTime(2005,05,07),
            }
        };

        public static List<Seller> _sellers = new List<Seller>
        {
           new Seller()
            {
                Id = 1,
                Name = "Ivan"
            },
            new Seller()
            {
                Id = 2,
                Name = "Petur"
            },
            new Seller()
            {
                Id = 3,
                Name = "Gosho"
            },
            new Seller()
            {
                Id = 4,
                Name = "Stoqn"
            }
        };

        public BlGameServiceUnitTest()
        {
            _gameServiceMock = new Mock<IGameService>();
            _sellerRepositoryMock = new Mock<ISellerRepository>();
        }

        [Fact]
        public void CheckGameCount_OK()
        {
            //setup
            var input = 10;
            var sellerId = 1;
            var expectedCount = 12;

            var mockedGameRepository =
                new Mock<IGameRepository>();
            var mockedSellerRepository =
                new Mock<ISellerRepository>();

            mockedGameRepository.Setup(
                x =>
                    x.GetAllGamesBySeller(sellerId))
                .Returns(GameData.Where(g =>
                    g.SellerId == sellerId).ToList());

            //inject
            var gameService =
                new GameService(mockedGameRepository.Object);
            var sellerService =
                new SellerService(mockedSellerRepository.Object);
            var gameBlService =
                new GameBlService(sellerService, gameService);

            //act
            var result =
                gameBlService.GetAllGamesCount(input, sellerId);

            //Assert
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetAllGamesCount_WrongSellerId()
        {
            //setup
            var input = 10;
            var sellerId = 111;
            var expectedCount = 10;

            var mockedGameRepository =
                new Mock<IGameRepository>();
            var mockedSellerRepository =
                new Mock<ISellerRepository>();

            mockedGameRepository.Setup(
                    x =>
                        x.GetAllGamesBySeller(sellerId))
                .Returns(GameData.Where(g =>
                    g.SellerId == sellerId).ToList());

            //inject
            var gameService =
                new GameService(mockedGameRepository.Object);
            var sellerService =
                new SellerService(mockedSellerRepository.Object);
            var gameBlService =
                new GameBlService(sellerService, gameService);

            //act
            var result =
                gameBlService.GetAllGamesCount(input, sellerId);

            //Assert
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetAllGamesCount_NegativeInput()
        {
            //setup
            var input = -20;
            var sellerId = 111;
            var expectedCount = 0;

            var mockedGameRepository =
                new Mock<IGameRepository>();
            var mockedSellerRepository =
                new Mock<ISellerRepository>();

            mockedGameRepository.Setup(
                    x =>
                        x.GetAllGamesBySeller(sellerId))
                .Returns(GameData.Where(g =>
                    g.SellerId == sellerId).ToList());

            //inject
            var gameService =
                new GameService(mockedGameRepository.Object);
            var sellerService =
                new SellerService(mockedSellerRepository.Object);
            var gameBlService =
                new GameBlService(sellerService, gameService);

            //act
            var result =
                gameBlService.GetAllGamesCount(input, sellerId);

            //Assert
            Assert.Equal(expectedCount, result);
        }
    }
}
    
