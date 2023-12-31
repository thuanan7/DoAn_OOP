﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_Services
{
    public interface IXuLyMatHang
    {
        void CreateMatHang(string categoryId, string name, string company, int year, DateTime exp);
        List<MatHang> ReadListMatHang(string tuKhoa="");
        List<MatHang> ReadListMatHangByCategoryId(string categoryId);
        MatHang ReadMatHangById(string id);
        void UpdateMatHang(MatHang mh);
        void DeleteMatHang(string id);
    }
}
