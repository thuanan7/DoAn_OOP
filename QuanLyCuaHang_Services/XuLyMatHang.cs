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
        public MatHang ReadMatHangById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            MatHang matHang = _luuMatHang.ReadMatHangById(id);
            if (matHang == null)
                throw new Exception("Id không tồn tại!");

            return matHang;
        }
        public void UpdateMatHang(MatHang mh)
        {
            if (string.IsNullOrEmpty(mh.CategoryId))
                throw new Exception("Id Loại Hàng không hợp lệ!");
            if (string.IsNullOrEmpty(mh.Name))
                throw new Exception("Tên không hợp lệ!");
            if (string.IsNullOrEmpty(mh.Company))
                throw new Exception("Công Ty không hợp lệ!");
            if (mh.Year < 1900)
                throw new Exception("Năm sản xuất không hợp lệ!");
            if (mh.Exp.Year < mh.Year) 
                throw new Exception("Hạn Sử Dụng không hợp lệ!");


            ILuuLoaiHang _luuLoaiHang = new LuuLoaiHang();
            LoaiHang lh = _luuLoaiHang.ReadLoaiHangById(mh.CategoryId);
            if (lh == null)
                throw new Exception("Id Loại Hàng không tôn tại!");

            mh.Category = lh.Name;

            bool res = _luuMatHang.UpdateMatHang(mh);
            if (!res)
                throw new Exception("Không tìm thấy Mặt Hàng để sửa!");
        }
        public void DeleteMatHang(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            bool res = _luuMatHang.DeleteMatHang(id);
            if (!res)
                throw new Exception("Không tìm thấy Mặt Hàng để xóa!");
        }
    }
}
