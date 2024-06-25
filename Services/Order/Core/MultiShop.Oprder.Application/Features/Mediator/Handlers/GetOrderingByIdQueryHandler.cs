using MediatR;
using MultiShop.Oprder.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Oprder.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Oprder.Application.Interfaces;
using MultiShop.Oprder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Oprder.Application.Features.Mediator.Handlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;
        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = values.OrderDate,
                OrderingId = values.OrderingId,
                TotalPrice = values.TotalPrice,
                UserId = values.UserId
            };
        }
    }
}
