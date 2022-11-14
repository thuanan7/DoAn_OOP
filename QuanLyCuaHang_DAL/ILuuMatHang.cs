using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_DAL
{
    public interface ILuuMatHang
    {
        void CreateMatHang(MatHang mh);
        List<MatHang> ReadListMatHang();
        MatHang ReadMatHangById(string id);
        bool UpdateMatHang(MatHang mh);
        void UpdateCategoryMatHang(LoaiHang lh);
        bool DeleteMatHang(string id);
    }
}
