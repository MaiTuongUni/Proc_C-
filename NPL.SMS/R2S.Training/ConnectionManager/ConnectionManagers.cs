using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

using R2S.Training.PropertyManager;
using R2S.Training.Entities;

namespace R2S.Training.ConnectionManager
{
    class ConnectionManagers
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        DataTable dt = new DataTable();
        public ConnectionManagers()
        {
            conn = new SqlConnection(PropertyManagers.connectionString);
            comm = conn.CreateCommand();
        }

        public SqlConnection open()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }
        public SqlConnection close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close(); conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public bool MyExecuteNonQuery(string strSQL, CommandType ct)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }

        public DataTable getAllCustomer()
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select customer_id, customer_name from Customer", CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable getAllOrderByCutomerId(int customerId)
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from Orders where customer_id=" + customerId, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable getAllItemByOrderId(int orderid)
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from OrderItem where order_id=" + orderid, CommandType.Text).Tables[0];
            return dt;
        }

        public DataTable computeOrderTotal(int orderId)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("select * from dbo.search_ComputeOrderTotal(@order_id)", conn);
            comm.Parameters.Add(new SqlParameter("@order_id", orderId));
            comm.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(comm);
            da.Fill(dt);
            close();
            return dt;
        }

        public bool addCustmer(Customer customer)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("add_Customer", conn);
            comm.Parameters.Add(new SqlParameter("@customer_name", customer.getCustomerName()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        public bool deleteCustmer(int customerId)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("delete_Customer", conn);
            comm.Parameters.Add(new SqlParameter("@customer_id", customerId));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        public bool updateCustmer(Customer customer)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("delete_Customer", conn);
            comm.Parameters.Add(new SqlParameter("@customer_id", customer.getCustomerId()));
            comm.Parameters.Add(new SqlParameter("@customer_name", customer.getCustomerName()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        public bool addOrder(Order order)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("insert_Order", conn);
            comm.Parameters.Add(new SqlParameter("@order_date", DateTime.Now));
            comm.Parameters.Add(new SqlParameter("@customer_id", order.getCustomerId()));
            comm.Parameters.Add(new SqlParameter("@employee_id", order.getEmployeeId()));
            comm.Parameters.Add(new SqlParameter("@total", order.getTotal()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        public bool addLineItem(LineItem lineItem)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("insert_LineItem", conn);
            comm.Parameters.Add(new SqlParameter("@order_id", lineItem.getOrderId()));
            comm.Parameters.Add(new SqlParameter("@product_id", lineItem.getProductId()));
            comm.Parameters.Add(new SqlParameter("@quantity", lineItem.getQuantity()));
            comm.Parameters.Add(new SqlParameter("@price", lineItem.getPrice()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        public bool updateOrderTotal(int orderId)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("update_TotalOrder", conn);
            comm.Parameters.Add(new SqlParameter("@order_id", orderId));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

    }
}
