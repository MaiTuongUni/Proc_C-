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
            dt = this.ExecuteQueryDataSet("select * from Customer where customer_id in(select customer_id from Orders)", CommandType.Text).Tables[0];
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
            dt = this.ExecuteQueryDataSet("select * from LineItem where order_id=" + orderid, CommandType.Text).Tables[0];
            return dt;
        }

        public double computeOrderTotal(int orderId)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("select dbo.search_ComputeOrderTotal(@order_id)", conn);
            comm.Parameters.AddWithValue("@order_id",orderId);
            comm.ExecuteScalar();
            double number = double.Parse(comm.ExecuteScalar().ToString());
            close();
            return number;
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
            comm = new SqlCommand("update_Customer", conn);
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

        public bool updateOrderTotal(double orderId)
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

        // Tìm kiếm khách hàng theo id
        public DataTable searchCustomerById(int customerId)
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from Customer where customer_id=" + customerId, CommandType.Text).Tables[0];
            return dt;
        }

        //Xóa đơn đặt hàng
        public bool deleteOrderById(int orderId)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("delete_OrderById", conn);
            comm.Parameters.Add(new SqlParameter("@order_id", orderId));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        //Tìm kiếm đơn đặt hàng theo id
        public DataTable searchOrderById(int orderId)
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from Orders where order_id=" + orderId, CommandType.Text).Tables[0];
            return dt;
        }

        //Cập nhật LineItem
        public bool updateLineItemById(LineItem lineItem)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("update_LineItemById", conn);
            comm.Parameters.Add(new SqlParameter("@order_id", lineItem.getOrderId()));
            comm.Parameters.Add(new SqlParameter("@product_id", lineItem.getProductId()));
            comm.Parameters.Add(new SqlParameter("@quantity", lineItem.getQuantity()));
            comm.Parameters.Add(new SqlParameter("@price", lineItem.getPrice()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        //Xóa LineItem theo id
        public bool deleleLineItemById(LineItem lineItem)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("delete_LineItemById", conn);
            comm.Parameters.Add(new SqlParameter("@order_id", lineItem.getOrderId()));
            comm.Parameters.Add(new SqlParameter("@product_id", lineItem.getProductId()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        public DataTable searchAllEmployee()
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from Employee", CommandType.Text).Tables[0];
            return dt;
        }
        //Tìm kiếm nhân viên theo id
        public DataTable searchemployeeByid(int employeeid)
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from Employee where employee_id=" + employeeid, CommandType.Text).Tables[0];
            return dt;
        }

        //Thêm mới employee 
        public bool addEmployyee(Employee employee)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("insert_Employee", conn);
            comm.Parameters.Add(new SqlParameter("@employee_id", employee.getEmployeeId()));
            comm.Parameters.Add(new SqlParameter("@employee_name", employee.getEmployeeName()));
            comm.Parameters.Add(new SqlParameter("@salary", employee.getSalary()));
            comm.Parameters.Add(new SqlParameter("@supervisor_id", employee.getSpvrId()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        //Cập nhật employee theo id
        public bool updateEmployeeById(Employee employee)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("update_Employee", conn);
            comm.Parameters.Add(new SqlParameter("@employee_id", employee.getEmployeeId()));
            comm.Parameters.Add(new SqlParameter("@employee_name", employee.getEmployeeName()));
            comm.Parameters.Add(new SqlParameter("@salary", employee.getSalary()));
            comm.Parameters.Add(new SqlParameter("@supervisor_id", employee.getSpvrId()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        //Tìm kiếm sản phẩm
        public DataTable searchProductById(int productId)
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from Product where product_id=" + productId, CommandType.Text).Tables[0];
            return dt;
        }

        //Thêm mới sản phẩm
        public bool insertProduct(Product product)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("insert_Product", conn);
            comm.Parameters.Add(new SqlParameter("@product_name", product.getProductName()));
            comm.Parameters.Add(new SqlParameter("@product_price", product.getPrice()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        //Cập nhật sản phẩm
        public bool updateProduct(Product product)
        {
            dt.Clear();
            open();
            comm = new SqlCommand("update_Product", conn);
            comm.Parameters.Add(new SqlParameter("@product_id", product.getProductId()));
            comm.Parameters.Add(new SqlParameter("@product_name", product.getProductName()));
            comm.Parameters.Add(new SqlParameter("@product_price", product.getPrice()));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            close();
            return true;
        }

        //Lấy tất cả sản phẩm có trong hệ thống
        public DataTable searchProduct()
        {
            dt.Clear();
            dt = this.ExecuteQueryDataSet("select * from Product", CommandType.Text).Tables[0];
            return dt;
        }

    }
}
