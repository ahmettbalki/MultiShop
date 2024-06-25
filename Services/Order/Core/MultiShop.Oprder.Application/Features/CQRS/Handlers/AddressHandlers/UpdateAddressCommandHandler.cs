using MultiShop.Oprder.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Oprder.Application.Interfaces;
using MultiShop.Oprder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Oprder.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.Detail1 = command.Detail1;
            values.Detail2 = command.Detail2;
            values.Name = command.Name;
            values.Surname = command.Surname;
            values.District = command.District;
            values.City = command.City;
            values.UserId = command.UserId;
            values.Country = command.Country;
            values.Phone = command.Phone;
            values.Description = command.Description;
            values.Email = command.Email;
            values.ZipCode = command.ZipCode;
            await _repository.UpdateAsync(values);
        }
    }
}
