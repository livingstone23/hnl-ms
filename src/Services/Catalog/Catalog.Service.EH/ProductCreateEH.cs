using Catalog.Domain;
using Catalog.Persistence.DB;
using Catalog.Service.EH.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalog.Service.EH
{
    public class ProductCreateEH: INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        public ProductCreateEH(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Handle(ProductCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = notification.Name,
                Description = notification.Description,
                Price = notification.Price
            });

            await _context.SaveChangesAsync();
        }





    }
}
