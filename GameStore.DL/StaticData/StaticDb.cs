using GameStore.Models.DTO;

namespace GameStore.DL.StaticData
{
    internal static class StaticDb
    {
       public static List<Seller> SellersData { get; set; } = new List<Seller>()
       {
           new Seller()
            {
               Id = 1,
               Name = "Ivan"
           },
           new Seller()
           {
               Id = 2,
               Name = "Gosho"
           },
           new Seller()
         {
               Id = 3,
               Name = "Petur"
           },
          new Seller()
           {
              Id = 4,
               Name = "Stoqn"
            },
           new Seller()
           {
             Id = 5,
              Name = "Dimitur"
            },
           new Seller() 
           {
            Id = 6,
            Name = "Vasil"
           }
    
       };

    public static List<Game> GameData { get; set; } = new List<Game>()
      {  
        new Game()
        {
            Id = "1",
            SellerId = 1,
           Title = "Counter-Strike 2",
            ReleaseDate = DateTime.Now,
           
    
           
        },
        new Game()
        {
            Id = "2",
            SellerId = 2,
            Title = "Fortnite",
            ReleaseDate = DateTime.Now,
            
        },
       new Game()
        {
        Id = "3",
        SellerId = 4,
         Title = "FC25",
         ReleaseDate = DateTime.Now,
        
        },
        new Game()
        {
          Id = "4",
          SellerId = 5,
        Title = "PUBG",
        ReleaseDate = DateTime.Now,
        
         },
         
        new Game()
        {
           Id = "5",
           SellerId = 6,
          Title = "Phasmophobia",
           ReleaseDate = DateTime.Now,
          
       }
    };

   }
}
