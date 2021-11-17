using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class Customer
    {
        private int customerId;
        private String customerName;

        public Customer(int CustomerId, String CustomerName )
        {
            this.customerId = CustomerId;
            this.customerName = CustomerName;
        }

        public int getCustomerId()
        {
            return customerId;
        }
        public void setCustomerId(int CustomerId)
        {
            this.customerId = CustomerId;
        }

        public String getCustomerName()
        {
            return this.customerName;
        }
        public void setCustomerName(String CustomerName)
        {
            this.customerName = CustomerName;
        }
    }
}
