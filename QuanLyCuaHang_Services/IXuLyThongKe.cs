using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Services
{
    public interface IXuLyThongKe
    {
        List<MatHang> ThongKeMatHangConTrongKho();
        List<MatHang> ThongKeMatHangHetHan();
    }
}
