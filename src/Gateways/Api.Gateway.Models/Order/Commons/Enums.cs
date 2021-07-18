using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Order.Commons
{
    public class Enums
    {
        public enum OrderStatus
        {
            Cancel,
            Pending,
            Approved
        }

        public enum OrderPayment
        {
            CreditCard,
            PayPal,
            BankTransfer
        }
    }
}
