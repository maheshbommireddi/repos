using SprintZero.Core.Entities;
using SprintZero.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.BusinessService.Services
{
    public interface ICustomerListService
    {
        List<CustomerModel> GetAllCustomerModel();

        void  AddCustomer(CustomerEntity customerEntity);
        CustomerModel GetCustomerById(int? id);

        void EditCustomerEntity(CustomerEntity customer);

        void DeleteCustomerById(int? Id);
    }
}
