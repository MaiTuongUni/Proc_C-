using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    interface IOrderDAO
    {
        List<Order> getAllOrdersByCustomerId(int cutomerId);

        bool addOrder(Order order);

        bool updateOrderTotal(int orderId);
    }
}
