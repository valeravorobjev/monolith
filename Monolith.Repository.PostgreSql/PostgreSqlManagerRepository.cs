using Monolith.Repository.Common.Models;
using Monolith.Repository.Contracts;
using RandomNameGeneratorNG;

namespace Monolith.Repository.PostgreSql;

public class PostgreSqlManagerRepository: IManagerRepository
{
    private readonly PersonNameGenerator _generator;
    private readonly IList<Manager> _managers;

    public PostgreSqlManagerRepository()
    {
        _managers = new List<Manager>();
        _generator = new PersonNameGenerator();
    }

    public async ValueTask<string> CreateManagerAsync()
    {
        var manager = new Manager();
        manager.Id = Guid.NewGuid().ToString();
        manager.Name = _generator.GenerateRandomFirstAndLastName();;
        
        _managers.Add(manager);

        return await Task.FromResult(manager.Id);
    }

    public async ValueTask<Manager?> GetManagerAsync(string id)
    {
        var manager = _managers.FirstOrDefault(m => m.Id == id);
        return await ValueTask.FromResult(manager);
    }

    public async ValueTask<IList<Manager>> GetManagersAsync(int take, int skip)
    {
        var managers = _managers.OrderBy(m => m.Id).Skip(skip).Take(take).ToList();
        return await ValueTask.FromResult(managers);
    }
}