using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Entities
{
    public class Hang
    {
        public string  IDMatHang { get; set; }
        public int SoLuong { get; set; }
        public Hang(string id, int soluong)
        {
            IDMatHang= id;
            SoLuong = soluong;
        }
    }

    public class HoaDon
    {
        public string Id { get; set; }
        public DateTime NgayTao { get; set; }
        public List<Hang> DanhSachHang { get; set; }
        public HoaDon()
        {
            Id = string.Empty;
            NgayTao= DateTime.Now;
            DanhSachHang = new List<Hang>();
        }
    }
}
