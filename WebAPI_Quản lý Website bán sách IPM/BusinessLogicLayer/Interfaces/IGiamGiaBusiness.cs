﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IGiamGiaBusiness
    {
        GiamGiaModel GetDatabyID(string id);

        bool Create(GiamGiaModel model);

        bool Update(GiamGiaModel model);

        bool Delete(int id);

        public List<GiamGiaModel> Search(int pageIndex, int pageSize, out long total, string TenMaGiamGia, int SoTienGiam);
    }
}
