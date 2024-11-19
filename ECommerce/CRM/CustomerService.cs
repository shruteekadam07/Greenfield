using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECommerceEntities;

namespace CRM
{
    public class CustomerService : ICustomerService  // inheritance used----> interfaces are always used for implementation
    {
        private List<Customer> _customerList;
        public CustomerService() {
            this._customerList = new List<Customer>();    // customer services class is maintaining the record of customers
        }
        public bool Delete(int id)
        {
            Customer thecustomer=this.Get(id);
            return this._customerList.Remove(thecustomer);

        }

        public Customer Get(int id)
        {
            foreach(Customer customer in _customerList)
            {
                if (customer.Id == id)
                    return customer;
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return _customerList;

        }

        public bool Insert(Customer customer)
        {
            this._customerList.Add(customer);
            return true;
        }

        public bool Update(Customer customer)
        {
            Customer thecustomer =this.Get(customer.Id);
            thecustomer.FirstName = customer.FirstName;
            thecustomer.LastName = customer.LastName;
            thecustomer.Email = customer.Email;
            return true;
            //this._customerList.Remove(thecustomer);
            //this._customerList.Add(thecustomer);

        }
    }
}
