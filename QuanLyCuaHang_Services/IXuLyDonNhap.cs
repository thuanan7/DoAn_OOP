using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Services
{
    public interface IXuLyDonNhap
    {
        void CreateDonNhap(List<KienHang> ds);
        List<HoaDon> ReadListDonNhap(string tuKhoa="");
        HoaDon ReadDonNhapById(string id);
        void UpdateDonNhap(HoaDon hOld, HoaDon hNew);
        void DeleteDonNhap(string id);
    }
}
