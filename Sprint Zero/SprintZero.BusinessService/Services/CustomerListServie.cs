using SprintZero.Core.Models;
using SprintZero.DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprintZero.BusinessService.Mappers;
using SprintZero.Core.Entities;

namespace SprintZero.BusinessService.Services
{

    
    public class CustomerListServie : ICustomerListService
    {
        private  CustomerRespository _repository;

        public CustomerListServie(CustomerRespository Repository)
        {
            _repository = Repository;
        }

        public List<CustomerModel> GetAllCustomerModel()
        {
            return _repository.GetAllCustomerEntities().Select(i => i.ToModel()).ToList();
        }

        public CustomerModel GetCustomerById(int? id)
        {
            return _repository.GetCustomerEntity(id).ToModel();
        }

        public void AddCustomer(CustomerEntity customer)
        {
             _repository.AddCoustomerEntity(customer);
        }
         public void EditCustomerEntity(CustomerEntity customer)
        {
            _repository.EditCustomerEntity(customer);
        }

        public void DeleteCustomerById(int? Id)
        {
            _repository.DeleteCustomerById(Id);
        }
    }

   

}
