using AutoMapper;
using CustomerInfo.Dtos;
using CustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerInfo.App_Start
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Customer, CustomerDto>();

          //  Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

           
        }
    }
}