using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_DAL
{
    internal interface ILuuLoaiHang
    {
        void CreateLoaiHang(LoaiHang lh);
        List<LoaiHang> ReadListLoaiHang();
        LoaiHang ReadLoaiHangById(string id);
        bool UpdateLoaiHang(LoaiHang lh);
        bool DeleteLoaiHang(string id);
    }
}
