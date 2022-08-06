using System;

namespace Dataplace.Imersao.Core.Domain.Exections
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }

}
