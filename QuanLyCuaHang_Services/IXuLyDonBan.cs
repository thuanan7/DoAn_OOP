using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Services
{
    public interface IXuLyDonBan
    {
        void CreateDonBan(List<KienHang> ds);
        List<HoaDon> ReadListDonBan(string tuKhoa="");
        HoaDon ReadDonBanById(string id);
        void UpdateDonBan(HoaDon hOld, HoaDon hNew);
        void DeleteDonBan(string id);
    }
}
