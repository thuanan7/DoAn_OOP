using QuanLyCuaHang_DAL;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_Services
{
    public class XuLyCuaHang : IXuLyCuaHang
    {
        private LuuLoaiHang _luuLoaiHang = new LuuLoaiHang();
        public void CreateLoaiHang(string id, string name)
        {
            var dsLoaiHang = _luuLoaiHang.ReadLoaiHang();
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
    }
}