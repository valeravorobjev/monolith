using Monolith.Repository.Common.Models;

namespace Monolith.Repository.Contracts;

/// <summary>
/// Работа с менеджерами
/// </summary>
public interface IManagerRepository
{
    /// <summary>
    /// Создать нового менеджера
    /// </summary>
    /// <returns>Возвращает идентификатор менеджера</returns>
    public ValueTask<string> CreateManagerAsync();
    /// <summary>
    /// Возвращает менеджера
    /// </summary>
    /// <param name="id">Идентификатор менеджера</param>
    /// <returns></returns>
    public ValueTask<Manager?> GetManagerAsync(string id);
    /// <summary>
    /// Возвращает список менеджеров
    /// </summary>
    /// <param name="take">Сколько записей взять</param>
    /// <param name="skip">Сколько пропустить</param>
    /// <returns></returns>
    public ValueTask<IList<Manager>> GetManagersAsync(int take, int skip);
}