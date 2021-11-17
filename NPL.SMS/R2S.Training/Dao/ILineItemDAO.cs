using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    interface ILineItemDAO
    {
        List<LineItem> getAllItemsByOrderId(int orderId);
        double ComputeOrderTotal(int orderId);

        bool addLineItem(LineItem lineItem);
    }
}
