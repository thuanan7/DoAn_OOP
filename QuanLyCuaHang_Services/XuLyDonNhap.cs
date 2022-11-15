using QuanLyCuaHang_DAL;
using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Services
{
    public class XuLyDonNhap : IXuLyDonNhap
    {
        private ILuuTruDonNhap _luuDonNhap = new LuuTruDonNhap();
        private ILuuMatHang _luuMatHang = new LuuMatHang();
        public void CreateDonNhap(List<Hang> ds)
        {
            HoaDon hd = new HoaDon();
            List<MatHang> dsMatHangCanCapNhat = new List<MatHang>();
            foreach (var hang in ds)
            {
                if (!string.IsNullOrEmpty(hang.IDMatHang))
                {
                    if (hang.SoLuong < 0)
                        throw new Exception("Số lượng không hợp lệ!");

                    MatHang mh = _luuMatHang.ReadMatHangById(hang.IDMatHang);
                    if (mh == null)
                        throw new Exception($"Không tìm thấy Id mặt hàng: {hang.IDMatHang}");

                    hd.DanhSachHang.Add(hang);
                    dsMatHangCanCapNhat.Add(mh);
                }
            }

            int idx = 0;
            foreach (var x in dsMatHangCanCapNhat)
            {
                _luuMatHang.UpdateSoLuongHangOfMatHang(x, hd.DanhSachHang[idx].SoLuong);
                idx++;
            }
            _luuDonNhap.CreateDonNhap(hd);
        }
        public List<HoaDon> ReadListDonNhap(string tuKhoa = "")
        {
            var dsDonNhap = _luuDonNhap.ReadListDonNhap();
            if (string.IsNullOrEmpty(tuKhoa))
                return dsDonNhap;

            var list = new List<HoaDon>();
            foreach (var item in dsDonNhap)
            {
                if (item.Id.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase))
                    list.Add(item);
            }
            return list;
        }
        public HoaDon ReadDonNhapById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            HoaDon h = _luuDonNhap.ReadDonNhapById(id);
            if (h == null)
                throw new Exception("Id không tồn tại!");

            return h;
        }
        public void UpdateDonNhap(HoaDon hOld, HoaDon hNew)
        {
            if (string.IsNullOrEmpty(hNew.Id))
                throw new Exception("Id không hợp lệ!");

            if (hNew.Id != hOld.Id)
            {
                HoaDon h = _luuDonNhap.ReadDonNhapById(hNew.Id);
                if (h != null)
                    throw new Exception("Id đã tồn tại!");
            }

            if (!hNew.DanhSachHang.SequenceEqual(hOld.DanhSachHang))
                throw new Exception("Không được phép thay đổi danh sách kiện hàng đã Nhập/Bán!");

            bool res = _luuDonNhap.UpdateDonNhap(hOld, hNew);
            if (!res)
                throw new Exception("Không tìm thấy Đơn Hàng để sửa!");
        }
        public void DeleteDonNhap(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            bool res = _luuDonNhap.DeleteDonNhap(id);
            if (!res)
                throw new Exception("Không tìm thấy Hoá Đơn Nhập để xóa!");
        }
    }
}
