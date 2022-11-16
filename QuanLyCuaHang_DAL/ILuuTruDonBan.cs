using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_DAL
{
    public interface ILuuTruDonBan
    {
        void CreateDonBan(HoaDon h);
        List<HoaDon> ReadListDonBan();
        HoaDon ReadDonBanById(string id);
        bool UpdateDonBan(HoaDon hOld, HoaDon hNew);
        bool DeleteDonBan(string id);
    }
}
