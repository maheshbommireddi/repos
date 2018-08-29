using SprintZero.Core.Entities;
using SprintZero.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintZero.BusinessService.Mappers
{
   public static class CustomerMapper
    {
        public static CustomerEntity ToEntity(this CustomerModel model)
        {
            return (model == null) ? null :
                new CustomerEntity
                {
                    Id = model.Id,
                    FirstName = model.FirstName ,
                    LastName = model.LastName ,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber ,
                    BirthData = model.BirthData,
                    EmailAddress = model.EmailAddress
                };
        }


        public static CustomerModel ToModel(this CustomerEntity entity)
        {
            return (entity == null) ? null :
                new CustomerModel
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    StreetAddress = entity.StreetAddress,
                    City = entity.City,
                    State = entity.State,
                    ZipCode = entity.ZipCode,
                    PhoneNumber = entity.PhoneNumber,
                    BirthData = entity.BirthData,
                    EmailAddress = entity.EmailAddress
                };
        }

        }
    }
