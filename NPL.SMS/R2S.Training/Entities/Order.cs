using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class Order
    {
        private int orderId;
        private string orderDate;
        private int customerId;
        private int employeeId;
        private double total;

        public Order(int OrderId, string OrderDate, int CustomerId, int EmployeeId, double Total)
        {
            this.orderId = OrderId;
            this.orderDate = OrderDate;
            this.customerId = CustomerId;
            this.employeeId = EmployeeId;
            this.total = Total;
        }

        public int getOrderId()
        {
            return this.orderId;
        }
        public void setPrice(int OrderId)
        {
            this.orderId = OrderId;
        }

        public string getOrderDate()
        {
            return this.orderDate;
        }
        public void setOrderDate(string OrderDate)
        {
            this.orderDate = OrderDate;
        }

        public int getCustomerId()
        {
            return this.customerId;
        }
        public void setCutomerId(int customerId)
        {
            this.customerId = customerId;
        }


        public int getEmployeeId()
        {
            return this.employeeId;
        }
        public void setEmployeeId(int employeeId)
        {
            this.employeeId = employeeId;
        }

        public double getTotal() { return this.total; }
        public void setTotal(double total)
        {
            this.total = total;
        }
    }
}
