using LiteDB;
using Monolith.Repository.Common.Models;
using Monolith.Repository.Contracts;
using RandomNameGeneratorNG;

namespace Monolith.Repository.MongoDb;

public class MongoDbManagerRepository: IManagerRepository
{
    private readonly PersonNameGenerator _generator;

    private const string DB_NAME = "monolith.db";
    private const string COLLECTION = "managers";

    public MongoDbManagerRepository()
    {
        _generator = new PersonNameGenerator();
    }

    public async ValueTask<string> CreateManagerAsync()
    {
        var manager = new Manager();
        manager.Id = Guid.NewGuid().ToString();
        manager.Name = _generator.GenerateRandomFirstAndLastName();;

        using var db = new LiteDatabase(DB_NAME);
        var col = db.GetCollection<Manager>(COLLECTION);

        col.Insert(manager);
        
        return await Task.FromResult(manager.Id);
    }

    public async ValueTask<Manager?> GetManagerAsync(string id)
    {
        using var db = new LiteDatabase(DB_NAME);
        var col = db.GetCollection<Manager>(COLLECTION);

        var manager = col.Query().Where(m => m.Id == id).FirstOrDefault();
        return await ValueTask.FromResult(manager);
    }

    public async ValueTask<IList<Manager>> GetManagersAsync(int take, int skip)
    {
        using var db = new LiteDatabase(DB_NAME);
        var col = db.GetCollection<Manager>(COLLECTION);
        
        var managers = col.Query().OrderBy(m => m.Id).Skip(skip).Limit(take).ToList();
        return await ValueTask.FromResult(managers);
    }
}