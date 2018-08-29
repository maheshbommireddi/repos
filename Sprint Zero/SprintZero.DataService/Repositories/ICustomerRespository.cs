using SprintZero.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.DataService.Repositories
{
    public interface ICustomerRespository 
    {
        List<CustomerEntity> GetAllCustomerEntities();
        CustomerEntity GetCustomerEntity(int? id);
       void  AddCoustomerEntity(CustomerEntity customer);
        void EditCustomerEntity(CustomerEntity customer);
        void DeleteCustomerById(int? Id);

       void AddTestCoustomerEntity(CustomerEntity customer);
    }


}
