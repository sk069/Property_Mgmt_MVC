using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Property_Mgmt_MVC.Models
{
    public class Property_oction
    {
        public int Id { get; set; }

        [Required]
        public Decimal Bid_Price { get; set; }

        public int Property_DetailId { get; set; }
        public Property_Detail Property_Detail { get; set; }

        public int Customer_DetailId { get; set; }

        public Customer_Detail Customer_Detail { get; set; }

        public int Dealer_DetailId { get; set; }

        public Dealer_Detail Dealer_Detail { get; set; }

    }
}

