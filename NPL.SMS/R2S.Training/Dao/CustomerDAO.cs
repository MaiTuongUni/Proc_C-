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
    class CustomerDAO : ICustomerDAO
    {
        ConnectionManagers db = null;
        public CustomerDAO()
        {
            db = new ConnectionManagers();
        }
        public bool addCustomer(Customer customer)
        {
            try
            {
                db.addCustmer(customer);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool deleteCustomer(int customerId)
        {
            try
            {
                db.deleteCustmer(customerId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customer> getAllCustomer()
        {
            try
            {
                List<Customer> listCustomer = null;
                DataTable dt = db.getAllCustomer();
                if (dt.Rows.Count > 0)
                {
                    listCustomer = new List<Customer>();
                    foreach (DataRow row in dt.Rows)
                    {
                        Customer customer = new Customer(int.Parse(row["customer_id"].ToString()), row["customer_name"].ToString());
                        listCustomer.Add(customer);
                    }
                }
                return listCustomer;
            }
            catch
            {
                return null;
            }
        }

        public bool updateCustomer(Customer customer)
        {
            try
            {
                db.updateCustmer(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
