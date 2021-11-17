using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class LineItem
    {
        private int orderId;
        private int productId;
        private int quantity;
        private double price;

        public LineItem(int OrderId, int ProductId, int Quantity, double Price)
        {
            this.orderId = OrderId;
            this.productId = ProductId;
            this.quantity = Quantity;
            this.price = Price;
        }

        public int getOrderId()
        {
            return this.orderId;
        }
        public void setOrderId(int OrderId)
        {
            this.orderId = OrderId;
        }

        public int getProductId()
        {
            return this.productId;
        }
        public void setProductId(int ProductId)
        {
            this.productId = ProductId; 
        }

        public int getQuantity()
        {
            return this.quantity;
        }
        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public double getPrice()
        {
            return this.price;
        }
        public void setPrice(double Price)
        {
            this.price = Price;
        }
    }
}
