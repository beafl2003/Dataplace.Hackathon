using Dataplace.Core.Comunications;
using Dataplace.Core.Domain.Notifications;
using Dataplace.Imersao.Core.Domain.Exections;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dataplace.Imersao.Core.Application.Behaviors
{
  

    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {


        private readonly IMediatorHandler _mediator;

        public ValidationBehaviour(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (DomainException ex)
            {
                await _mediator.RaiseEvent(new DomainNotification(ex.GetType().Name, ex.Message));
                return default;
            }
    
        }
    }
}
