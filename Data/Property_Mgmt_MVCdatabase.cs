using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Property_Mgmt_MVC.Models;

namespace Property_Mgmt_MVC.Data
{
    public class Property_Mgmt_MVCdatabase : DbContext
    {
        public Property_Mgmt_MVCdatabase (DbContextOptions<Property_Mgmt_MVCdatabase> options)
            : base(options)
        {
        }

        public DbSet<Property_Mgmt_MVC.Models.Customer_Detail> Customer_Detail { get; set; }

        public DbSet<Property_Mgmt_MVC.Models.Dealer_Detail> Dealer_Detail { get; set; }

        public DbSet<Property_Mgmt_MVC.Models.Property_Detail> Property_Detail { get; set; }

        public DbSet<Property_Mgmt_MVC.Models.Property_oction> Property_oction { get; set; }
    }
}
