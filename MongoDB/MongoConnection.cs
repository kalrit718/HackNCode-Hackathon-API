using BeFit_Server_API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BeFit_Server_API.MongoDB {
    public class MongoConnection {
        private readonly IConfiguration _config;

        private IMongoDatabase db;
        private string databaseName;
        private string collectionName;

        public MongoConnection(IConfiguration config) {
            _config = config;

            databaseName = _config.GetValue<string>("MongoDB:DataBaseName");
            collectionName = _config.GetValue<string>("MongoDB:CollectionName");

            var client = new MongoClient(_config.GetValue<string>("MongoDB:ConnectionString"));

            db = client.GetDatabase(databaseName);
        }

        public Post LoadRecordById(string id) {
            var collection = db.GetCollection<Post>(collectionName);
            var filter = Builders<Post>.Filter.Eq("Id", id);

            if (collection.Find(filter).Any()) {
                return collection.Find(filter).First();
            }
            else {
                throw new ArgumentException("[ERROR] - Invalid ID provided.");
            }

        }
    }
}
