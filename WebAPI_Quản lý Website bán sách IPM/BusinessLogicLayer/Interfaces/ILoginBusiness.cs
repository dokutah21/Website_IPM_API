﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ILoginBusiness
    {
        LoginModel Login(string TenTaiKhoan, string MatKhau);
    }
}
