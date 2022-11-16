using QuanLyCuaHang_DAL;
using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Services
{
    public class XuLyThongKe : IXuLyThongKe
    {
        private ILuuMatHang _luuMatHang = new LuuMatHang();
        public List<MatHang> ThongKeMatHangConTrongKho()
        {
            var dsMatHang = _luuMatHang.ReadListMatHang();
            var resList = new List<MatHang>();
            foreach (var h in dsMatHang)
            {
                if (h.SoLuong > 0)
                    resList.Add(h);
            }
            return resList;
        }
        public List<MatHang> ThongKeMatHangHetHan()
        {
            var dsMatHang = _luuMatHang.ReadListMatHang();
            var resList = new List<MatHang>();
            foreach (var h in dsMatHang)
            {
                if (h.Exp.CompareTo(DateTime.Today) < 0)
                    resList.Add(h);
            }
            return resList;
        }
    }
}
