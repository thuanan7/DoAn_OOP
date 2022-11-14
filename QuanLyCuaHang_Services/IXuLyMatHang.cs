using System;
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
    }
}
