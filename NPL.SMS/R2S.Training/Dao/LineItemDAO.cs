using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.ConnectionManager;
using R2S.Training.Entities;

namespace R2S.Training.Dao
{
    class LineItemDAO : ILineItemDAO
    {
        ConnectionManagers db = null;
        public LineItemDAO()
        {
            db = new ConnectionManagers();
        }
        public bool addLineItem(LineItem lineItem)
        {
            try
            {
                db.addLineItem(lineItem);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public double ComputeOrderTotal(int orderId)
        {
            try
            {
                return double.Parse(db.computeOrderTotal(orderId).ToString());
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        public bool deleteLineItem(LineItem lineItem)
        {
            return db.deleleLineItemById(lineItem);
        }
        public List<LineItem> getAllItemsByOrderId(int orderId)
        {
            try
            {
                List<LineItem> listOrderItem = null;
                DataTable dt = db.getAllItemByOrderId(orderId);
                if (dt.Rows.Count > 0)
                {
                    listOrderItem = new List<LineItem>();
                    foreach (DataRow row in dt.Rows)
                    {
                        int productId = int.Parse(row["product_id"].ToString());
                        int quantity = int.Parse(row["quantity"].ToString());
                        double price = double.Parse(row["price"].ToString());

                        LineItem lineItem = new LineItem(orderId, productId, quantity, price);
                        listOrderItem.Add(lineItem);
                    }
                }
                return listOrderItem;
            }
            catch
            {
                return null;
            }
        }

        public bool updateLineItem(LineItem lineItem)
        {
            return db.updateLineItemById(lineItem);
        }
    }
}
