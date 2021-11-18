using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.Entities;
namespace R2S.Training.Dao
{
    interface IProductDAO
    {
        List<Product> searchAllProduct();

        Product searchProductById(int product_id);
        bool addProduct(Product product);

        bool updateProduct(Product product);
    }
}
