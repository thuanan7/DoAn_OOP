using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_DAL;

namespace QuanLyCuaHang_Services
{
    public class XuLyMatHang : IXuLyMatHang
    {
        private ILuuMatHang _luuMatHang = new LuuMatHang();
        public void CreateMatHang(string categoryId, string name, string company, int year, DateTime exp)
        {
            if (string.IsNullOrEmpty(categoryId))
                throw new Exception("Id Loại Hàng không hợp lệ!");
            if (string.IsNullOrEmpty(name)) 
                throw new Exception("Tên không hợp lệ!");
            if (string.IsNullOrEmpty(company))
                throw new Exception("Công Ty không hợp lệ!");
            if (year < 1900)
                throw new Exception("Năm sản xuất không hợp lệ!");
            if (exp.Year < year) 
                throw new Exception("Hạn Sử Dụng không hợp lệ!");
            
            ILuuLoaiHang _luuLoaiHang = new LuuLoaiHang();
            LoaiHang lh = _luuLoaiHang.ReadLoaiHangById(categoryId);
            if (lh == null)
                throw new Exception("Id Loại Hàng không tôn tại!");

            MatHang mh = new MatHang()
            {
                CategoryId = categoryId,
                Category = lh.Name,
                Name = name,
                Company= company,
                Year = year,
                Exp = exp
            };
            _luuMatHang.CreateMatHang(mh, categoryId);
        }
        public List<MatHang> ReadListMatHang(string tuKhoa = "")
        {
            var dsMatHang = _luuMatHang.ReadListMatHang();
            if (string.IsNullOrEmpty(tuKhoa))
                return dsMatHang;

            var list = new List<MatHang>();
            foreach (var item in dsMatHang)
            {
                if (item.Name.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase))
                    list.Add(item);
            }
            return list;
        }
    }
}
