using QuanLyCuaHang_DAL;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_Services
{
    public class XuLyLoaiHang : IXuLyLoaiHang
    {
        private LuuLoaiHang _luuLoaiHang = new LuuLoaiHang();
        public void CreateLoaiHang(string id, string name)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            if (string.IsNullOrEmpty(name))
                throw new Exception("Tên không hợp lệ!");

            var dsLoaiHang = _luuLoaiHang.ReadListLoaiHang();
            foreach (var item in dsLoaiHang)
            {
                if(item.Id == id)
                    throw new Exception("Id Loại Hàng đã tồn tại!");
            }

            LoaiHang lh = new LoaiHang()
            {
                Id = id,
                Name = name
            };
            _luuLoaiHang.CreateLoaiHang(lh);
        }

        public List<LoaiHang> ReadListLoaiHang(string tuKhoa="")
        {
            var dsLoaiHang = _luuLoaiHang.ReadListLoaiHang();
            if (string.IsNullOrEmpty(tuKhoa))
                return dsLoaiHang;

            var list = new List<LoaiHang>();
            foreach (var item in dsLoaiHang)
            {
                if (item.Name.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase))
                    list.Add(item);
            }
            return list;
        }

        public LoaiHang ReadLoaiHangById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            LoaiHang loaiHang = _luuLoaiHang.ReadLoaiHangById(id);
            if (loaiHang == null)
                throw new Exception("Id không tồn tại!");

            return loaiHang;
        }
        public void UpdateLoaiHang(LoaiHang lh)
        {
            if (string.IsNullOrEmpty(lh.Id))
                throw new Exception("Id không hợp lệ!");

            if (string.IsNullOrEmpty(lh.Name))
                throw new Exception("Tên không hợp lệ!");

            bool res = _luuLoaiHang.UpdateLoaiHang(lh);
            if (!res)
                throw new Exception("Không tìm thấy Loại Hàng để sửa!");
        }
        public void DeleteLoaiHang(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            bool res = _luuLoaiHang.DeleteLoaiHang(id);
            if (!res)
                throw new Exception("Không tìm thấy Loại Hàng để xóa!");
        }
    }
}