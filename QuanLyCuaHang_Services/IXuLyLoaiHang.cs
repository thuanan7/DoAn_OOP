using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Services
{
    public interface IXuLyLoaiHang
    {
        void CreateLoaiHang(string id, string name);
        List<LoaiHang> ReadListLoaiHang(string tuKhoa="");
        LoaiHang ReadLoaiHangById(string id);
        void UpdateLoaiHang(LoaiHang lh);
        void DeleteLoaiHang(string id);
    }
}
