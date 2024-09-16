using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models.Domain;

namespace WebApplication1.Data
{
    public class oneDbContext: DbContext
    {
        //about onedbcontext
        //This class is responsible for interacting with the database and managing the entity objects during runtime.
        //This means the class is responsible for creating, retrieving, updating, and deleting entity objects in memory.

        public oneDbContext(DbContextOptions<oneDbContext> dbContextOptions): base(dbContextOptions) 
        {
            //The constructor takes an instance of DbContextOptions<oneDbContext> as a parameter and passes it to the base class constructor.
            //This allows you to configure the DbContext with options like the connection string, database provider, etc.
        }

        //DbSet<T> is a class provided by Entity Framework Core that represents a collection of entities of type T
        //within the DbContext. It provides methods for querying and saving instances of T to the database.
        //Essentially, DbSet<T> allows you to work with entities as if they were collections, enabling operations like adding,
        //updating, deleting, and querying.

        public DbSet<Difficulty>Difficulties { get; set; }
        public DbSet<Region>Regions { get; set; }
        public DbSet<Walk> walks { get; set; }
        public DbSet<Image>Images { get; set; }


        //A model class represents the data structure and business logic for a specific entity within your application.
        //It defines the properties and relationships that an entity has.
        //A DbSet<T> property in your DbContext class represents a collection of entities of type T that can be queried or saved to the database.
        //It serves as a gateway to perform CRUD operations on entities of that type.
        //Purpose: It provides an abstraction for querying and manipulating data in the database.
        //DbSet<T> is used to interact with the database context and manage the lifecycle of entities.

        protected override void OnModelCreating(ModelBuilder modelBuilder)      //This method is used to configure the model and seed initial data into the database. 
        {
            //Configuration: ModelBuilder is used to configure the model's behavior and structure, such as defining
            //relationships between entities, setting up constraints, and configuring table and column names.
           // Schema Definition: It helps to translate your C# classes into a relational database schema, including table names,
           // column names, primary keys, foreign keys, and other constraints.
            base.OnModelCreating(modelBuilder);

            var difficulties=new List<Difficulty>() { 
                new Difficulty()
                {
                    Id=Guid.Parse("789bcbdc-47eb-46f5-8bad-f83cd0a89368"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("af0bc228-ef5d-4dd5-b6c4-7a31ac7dfbc6"),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("24a79aac-6dbf-4f61-935a-2e96ee930e29"),
                    Name="Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);        //The HasData method is used to seed initial data into the database. 

            var regions = new List<Region>()
            {
                new Region
                {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageURL = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageURL = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageURL = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageURL = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageURL = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageURL = null
                },

            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
