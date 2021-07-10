using Customer.Domain;
using Customer.Persistence.DB;
using Customer.Service.EH.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Service.EH
{
    public class ClientEH : INotificationHandler<ClientCreateCommand>
    {
        private readonly ApplicationDbContext _context;

        public ClientEH(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Client
            {
                Name = notification.Name
            });

            await _context.SaveChangesAsync();
        }
    }
}
