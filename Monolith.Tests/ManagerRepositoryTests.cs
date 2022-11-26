using Monolith.Repository.ClickHouse;
using Monolith.Repository.Contracts;

namespace Monolith.Tests;

public class ManagerRepositoryTests
{
    private readonly IManagerRepository _managerRepository;

    public ManagerRepositoryTests()
    {
        _managerRepository = new ClickHouseManagerRepository();
    }
    
    
    [Fact]
    public async Task CreateManagerAsyncTest()
    {
        var result = await _managerRepository.CreateManagerAsync();
        Assert.NotNull(result);

        var ok = Guid.TryParse(result, out _);
        Assert.True(ok);
    }
    
    [Fact]
    public async Task GetManagerAsyncTest()
    {
        var id = await _managerRepository.CreateManagerAsync();
        
        var result = await _managerRepository.GetManagerAsync(id);
        Assert.NotNull(result);
        Assert.NotEmpty(result.Id);
        Assert.NotEmpty(result.Name);
        Assert.Equal(id, result.Id);
    }
    
    [Fact]
    public async Task GetManagersAsyncTests()
    {
        for (int i = 0; i < 12; i++)
        {
            await _managerRepository.CreateManagerAsync();
        }
        
        var result = await _managerRepository.GetManagersAsync(10, 2);
        
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(10, result.Count);
    }
}