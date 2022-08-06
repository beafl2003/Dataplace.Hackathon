namespace Dataplace.Imersao.Core.Domain.Exections
{
    public class ValueLowerThanZeroDomainException : DomainException
    {
        public ValueLowerThanZeroDomainException(string message) : base(message)
        {
        }
    }

}
