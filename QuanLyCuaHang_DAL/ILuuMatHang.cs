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
        void CreateMatHang(MatHang mh, string idPrefix="");
        List<MatHang> ReadListMatHang();
        MatHang ReadMatHangById(string id);
    }
}
