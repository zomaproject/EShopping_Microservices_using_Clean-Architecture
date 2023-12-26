using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class AddSeedData<T> where T : BaseEntity
{
    public static void SeedData(IMongoCollection<T> collection, string fileName)
    {
        var exist = collection.Find(p => true).Any();
        if (exist) return;
        var path = Path.Combine("Data", "SeedData", $"{fileName}.json");
        var data = File.ReadAllText(path);
        var list = JsonSerializer.Deserialize<List<T>>(data);
        if (list != null)
        {
            collection.InsertManyAsync(list);
        }
    }
}