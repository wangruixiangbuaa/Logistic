﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.Logistic.PM.Model
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string Account { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int Sex { get; set; }

        public int RoleId { get; set; }

        public int IsDelete { get; set; }

        public string ImagePath { get; set; }
        public DateTime CheckInTime { get; set; }

        public DateTime AlertTime { get; set; }
    }
}
