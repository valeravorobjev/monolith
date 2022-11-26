namespace Monolith.Repository.Contracts;

/// <summary>
/// Работа с транзакциями
/// </summary>
public interface ITransactionBuilder
{
    /// <summary>
    /// Расчитать сумму выплат для менеджера
    /// </summary>
    /// <param name="managerId">Идентификатор менеджера</param>
    /// <param name="values">Текущие выплаты</param>
    /// <returns></returns>
    public ValueTask<double> CalculateAsync(string managerId, double[] values);
}