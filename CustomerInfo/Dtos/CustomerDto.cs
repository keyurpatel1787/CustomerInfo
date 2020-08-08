﻿using CustomerInfo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerInfo.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [Min18YearsMember]
        public DateTime Birthdate { get; set; }


        public MembershipTypeDto MembershipType { get; set; }
        public int MembershipTypeId { get; set; }


    }
}