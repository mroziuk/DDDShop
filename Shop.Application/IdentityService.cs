using Shop.Domain.Exceptions;
using Shop.Domain.Model.Customer;
using Shop.Domain.Model.Customer.Repositories;
using Shop.Infrastructure.Repositories.NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    public class IdentityService
    {
        private ICustomerRepository customerRepository;
        public IdentityService()
        {
            customerRepository = new CustomerNH();
        }
        public void Register(Customer c)
        {
            var customer = customerRepository.WithEmail(c.Email);
            if(customer != null)
            {
                throw new EmailAlreadyExistException();
            }
            customerRepository.Add(c);
        }
        public bool isValidUser(string email, string passwors)
        {
            var customer = customerRepository.WithEmail(email);
            return customer != null && customer.Password == passwors;
        }
    }
}
