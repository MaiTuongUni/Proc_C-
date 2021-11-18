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
        public LineItemDomain()
        {
            lineItemDao = new LineItemDAO();
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
            return lineItemDao.addLineItem(lineItem);
        }
    }
}
