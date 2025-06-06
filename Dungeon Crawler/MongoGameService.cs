using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

public class MongoGameService
{
    private readonly IMongoCollection<BsonDocument> _saves;

    public MongoGameService()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var db = client.GetDatabase("ArvinHedin"); // Ditt namn som databas
        _saves = db.GetCollection<BsonDocument>("GameSaves");
    }

    public async Task Save(string playerName, BsonDocument doc)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("PlayerName", playerName);
        await _saves.ReplaceOneAsync(filter, doc, new ReplaceOptions { IsUpsert = true });
    }

    public async Task<BsonDocument?> Load(string playerName)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("PlayerName", playerName);
        return await _saves.Find(filter).FirstOrDefaultAsync();
    }
}
