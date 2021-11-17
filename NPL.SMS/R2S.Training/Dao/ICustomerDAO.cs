using R2S.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Dao
{
    interface ICustomerDAO
    {
         List<Customer> getAllCustomer();
        bool addCustomer(Customer customer);
        bool deleteCustomer(int customerId);
        bool updateCustomer(Customer customer);
    }
}
