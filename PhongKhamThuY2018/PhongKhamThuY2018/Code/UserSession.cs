﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhongKhamThuY2018.Code
{
    [Serializable]
    public class UserSession
    {
        public int UserID { get; set; }

        public string UserName { get; set; }
    }
}