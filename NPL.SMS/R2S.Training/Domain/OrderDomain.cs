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
        CustomerDAO customerDAO = null;
        EmpoloyeeDAO empoloyeeDAO = null;
        public OrderDomain()
        {
            orderDao = new OrderDAO();
            customerDAO = new CustomerDAO();
            empoloyeeDAO = new EmpoloyeeDAO();
        }

        public List<Order> getAllOrdersByCustomerId(int customerId)
        {
            return orderDao.getAllOrdersByCustomerId(customerId);
        }

        internal bool addOrder(Order order)
        {
            //Kiểm tra khách hàng có trong hệ thống hay không
            if(customerDAO.getCustomerById(order.getCustomerId()) == null)
            {
                return false;
            }

            //Kiểm kha nhân viên có trong hệ thống hay không
            if(empoloyeeDAO.getEmployeeById(order.getEmployeeId()) == null)
            {
                return false;
            }
            return orderDao.addOrder(order);
        }

        internal bool updateOrderTotal(int orderId)
        {
            //Kiểm tra đơn hàng có tồn tại hay không 
            if(orderDao.getOrderById(orderId) == null)
            {
                return false;
            }

            return orderDao.updateOrderTotal(orderId);
        }

    }
}
