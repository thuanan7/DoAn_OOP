using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_DAL
{
    public interface ILuuTruDonNhap
    {
        void CreateDonNhap(HoaDon h);
        List<HoaDon> ReadListDonNhap();
        HoaDon ReadDonNhapById(string id);
        bool UpdateDonNhap(HoaDon hOld, HoaDon hNew);
        bool DeleteDonNhap(string id);
    }
}
