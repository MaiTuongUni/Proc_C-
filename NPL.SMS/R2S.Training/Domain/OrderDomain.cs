using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.Dao;
using R2S.Training.Entities;
namespace R2S.Training.Domain
{
    class OrderDomain
    {
        OrderDAO orderDao = null;
        public OrderDomain()
        {
            orderDao = new OrderDAO();
        }

        public List<Order> getAllOrdersByCustomerId(int customerId)
        {
            return orderDao.getAllOrdersByCustomerId(customerId);
        }

        internal bool addOrder(Order order)
        {
            return orderDao.addOrder(order);
        }

        internal bool updateOrderTotal(int orderId)
        {
            return orderDao.updateOrderTotal(orderId);
        }

    }
}
