using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class Product
    {
        private int productId;
        private String productName;
        private double price;

        public Product(int ProductId, String Productname, double Price)
        {
            this.productId = ProductId;
            this.productName = Productname;
            this.price = Price;
        }

        public int getProductId()
        {
            return this.productId;
        }
        public void setProductId(int ProductId)
        {
            this.productId = ProductId;
        }

        public String getProductName()
        {
            return this.productName;
        }
        public void setProductName(String ProductName)
        {
            this.productName = ProductName;
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
