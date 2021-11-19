using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.Dao;
namespace R2S.Training.Domain
{
    class CustomerDomain
    {
        CustomerDAO customerDao = null;
        public CustomerDomain()
        {
            customerDao = new CustomerDAO();
        }
        internal List<Customer> GetAllCustomer()
        {
            return customerDao.getAllCustomer();
        }

        internal bool AddCustomer(Customer customer)
        {
            return customerDao.addCustomer(customer);
        }

        internal bool DeleleCustomer(int customerId)
        {
            return customerDao.deleteCustomer(customerId);
        }

        internal bool UpdateCustomer(Customer customer)
        {
            if (customerDao.getCustomerById(customer.getCustomerId()) == null)
            {
                return false;
            }
            return customerDao.updateCustomer(customer);
        }
    }
}
