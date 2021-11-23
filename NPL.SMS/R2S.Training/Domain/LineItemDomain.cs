using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.Dao;
using R2S.Training.Entities;
namespace R2S.Training.Domain
{
    class LineItemDomain
    {
        LineItemDAO lineItemDao = null;
        OrderDAO orderDAO = null;
        ProductDAO productDAO = null;
        public LineItemDomain()
        {
            lineItemDao = new LineItemDAO();
            orderDAO = new OrderDAO();
            productDAO = new ProductDAO();
        }
         
        public List<LineItem> getAllItemByOrderId(int orderId)
        {
            return lineItemDao.getAllItemsByOrderId(orderId);
        }

        public double computeOrderTotal(int orderId)
        {
                return lineItemDao.ComputeOrderTotal(orderId);
        }

        public bool addLineItem(LineItem lineItem)
        {
            //Kiểm tra xem mã đơn đặt hàng có trong hệ thống hay không
            if(orderDAO.getOrderById(lineItem.getOrderId()) == null)
            {
                Console.WriteLine("Ma don hang khong dung");
                return false;
            }

            //Kiểm tra xem mã sản phẩm có tồn tại trong hệ thống hay không
            if(productDAO.searchProductById(lineItem.getProductId())==null)
            {
                Console.WriteLine("Ma san pham khong dung");
                 return false;
            }

            return lineItemDao.addLineItem(lineItem);
        }
    }
}
