namespace FastDeliveriApi.Exceptions;

public class CreditLimitException : ApplicationException
{
    public CreditLimitException(string name) : base($"{name} no se puede incrementar el límite del crédito")
    {
    }
}