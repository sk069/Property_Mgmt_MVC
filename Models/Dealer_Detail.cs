﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Property_Mgmt_MVC.Models
{
    public class Dealer_Detail
    {
        public int Id { get; set; }

        [Required]
        public string Dealer_Name { get; set; }


        public string Dealer_Address { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
