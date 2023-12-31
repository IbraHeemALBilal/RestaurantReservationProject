﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Views
{
    public class EmployeeWithRestaurantDetails
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
    }
}
