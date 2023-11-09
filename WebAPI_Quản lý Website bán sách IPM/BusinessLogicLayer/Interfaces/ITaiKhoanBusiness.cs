﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ITaiKhoanBusiness
    {
        TaiKhoanModel GetDatabyID(string id);

        bool Create(TaiKhoanModel model);

        bool Update(TaiKhoanModel model);

        bool Delete(int id);

        public List<TaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string TenTaiKhoan);
    }
}
