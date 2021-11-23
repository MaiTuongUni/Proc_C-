using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.ConnectionManager;
using System.Data;
namespace R2S.Training.Dao
{
    class OrderDAO : IOrderDAO
    {
        ConnectionManagers db = null;
        public OrderDAO()
        {
            db = new ConnectionManagers();
        }
        public bool addOrder(Order order)
        {
            try
            {
                db.addOrder(order);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deketeOrderById(int order_id)
        {
            return db.deleteOrderById(order_id);
        }

        public List<Order> getAllOrdersByCustomerId(int cutomerId)
        {
            try
            {
                List<Order> listOrder= null;
                DataTable dt = db.getAllOrderByCutomerId(cutomerId);
                if (dt.Rows.Count > 0)
                {
                    listOrder = new List<Order>();
                    foreach (DataRow row in dt.Rows)
                    {
                        int productId = int.Parse(row["order_id"].ToString());
                        string dateTime = row["order_date"].ToString();
                        int customerId = int.Parse(row["customer_id"].ToString());
                        int employee_id = int.Parse(row["employee_id"].ToString());
                        double total = double.Parse(row["total"].ToString());
                        Order customer = new Order(productId,dateTime,customerId,employee_id,total);
                        listOrder.Add(customer);
                    }
                }
                return listOrder;
            }
            catch
            {
                return null;
            }
        }

        public Order getOrderById(int order_id)
        {
            try
            {
                Order order = null;
                DataTable dt = db.searchOrderById(order_id);
                if (dt.Rows.Count > 0)
                {
                        int productId = int.Parse(dt.Rows[0]["order_id"].ToString());
                        string dateTime = dt.Rows[0]["order_date"].ToString();
                        int customerId = int.Parse(dt.Rows[0]["customer_id"].ToString());
                        int employee_id = int.Parse(dt.Rows[0]["employee_id"].ToString());
                        double total = double.Parse(dt.Rows[0]["total"].ToString());
                    order = new Order(productId, dateTime, customerId, employee_id, total);
                }
                return order;
            }
            catch
            {
                return null;
            }
        }

        public bool updateOrderTotal(int orderId)
        {
            try
            {
                db.updateOrderTotal(orderId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
