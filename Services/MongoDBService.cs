using MongoDB.Driver;
using GrandLineBooks.Models;

namespace GrandLineBooks.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;

        public MongoDBService(IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDB:ConnectionString");
            var databaseName = configuration.GetValue<string>("MongoDB:DatabaseName");

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users =>
            _database.GetCollection<User>("Users");

        public IMongoCollection<Book> Books =>
            _database.GetCollection<Book>("Books");

        public IMongoCollection<Order> Orders =>
            _database.GetCollection<Order>("Orders");

        public IMongoCollection<Cart> Carts =>
            _database.GetCollection<Cart>("Carts");
    }
}