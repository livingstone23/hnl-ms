using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.DB.Configuration
{
    public class OrderConfiguration
    {
        public OrderConfiguration(EntityTypeBuilder<Domain.Order> entityBuilder)
        {
            entityBuilder.HasKey(x => x.OrderId);
        }
    }
}
