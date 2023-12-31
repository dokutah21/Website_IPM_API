﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ILoaiTaiKhoanBusiness
    {

        List<LoaiTaiKhoanModel> getAll_LTK();

        LoaiTaiKhoanModel GetDatabyID(string id);

        bool Create(LoaiTaiKhoanModel model);

        bool Update(LoaiTaiKhoanModel model);

        bool Delete(int id);

        bool DeleteMultiple(string id);

        public List<LoaiTaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string PhanQuyen, string TenChucDanh);
    }
}
