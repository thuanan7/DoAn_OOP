using QuanLyCuaHang_DAL;
using QuanLyCuaHang_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Services
{
    public class XuLyDonBan : IXuLyDonBan
    {
        private ILuuTruDonBan _luuDonBan = new LuuTruDonBan();
        private ILuuMatHang _luuMatHang = new LuuMatHang();
        public void CreateDonBan(List<KienHang> ds)
        {
            HoaDon hd = new HoaDon();
            List<MatHang> dsMatHangCanCapNhat = new List<MatHang>();
            foreach (var kienHang in ds)
            {
                if (!string.IsNullOrEmpty(kienHang.IDMatHang))
                {
                    if (kienHang.SoLuong < 0)
                        throw new Exception("Số lượng không hợp lệ!");

                    MatHang mh = _luuMatHang.ReadMatHangById(kienHang.IDMatHang);
                    if (mh == null)
                        throw new Exception($"Không tìm thấy Id mặt hàng: {kienHang.IDMatHang}");

                    //Đơn bán  khác đơn nhập chỗ này
                    int res = mh.SoLuong - kienHang.SoLuong;
                    if (res < 0)
                        throw new Exception($"Id mặt hàng: {mh.Id} không đủ số lượng để bán!");
                    //

                    hd.DanhSachHang.Add(kienHang);
                    dsMatHangCanCapNhat.Add(mh);
                }
            }

            int idx = 0;
            foreach (var x in dsMatHangCanCapNhat)
            {
                //Đơn bán  khác đơn nhập chỗ này thay dấu trừ 
                _luuMatHang.UpdateSoLuongHangOfMatHang(x, -hd.DanhSachHang[idx].SoLuong);
                idx++;
            }
            _luuDonBan.CreateDonBan(hd);
        }
        public List<HoaDon> ReadListDonBan(string tuKhoa = "")
        {
            var dsDonBan = _luuDonBan.ReadListDonBan();
            if (string.IsNullOrEmpty(tuKhoa))
                return dsDonBan;

            var list = new List<HoaDon>();
            foreach (var item in dsDonBan)
            {
                if (item.Id.Contains(tuKhoa.Trim(), StringComparison.OrdinalIgnoreCase))
                    list.Add(item);
            }
            return list;
        }
        public HoaDon ReadDonBanById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            HoaDon h = _luuDonBan.ReadDonBanById(id);
            if (h == null)
                throw new Exception("Id không tồn tại!");

            return h;
        }
        public void UpdateDonBan(HoaDon hOld, HoaDon hNew)
        {
            if (string.IsNullOrEmpty(hNew.Id))
                throw new Exception("Id không hợp lệ!");

            if (hNew.Id != hOld.Id)
            {
                HoaDon h = _luuDonBan.ReadDonBanById(hNew.Id);
                if (h != null)
                    throw new Exception("Id đã tồn tại!");
            }

            if (!hNew.DanhSachHang.SequenceEqual(hOld.DanhSachHang))
                throw new Exception("Không được phép thay đổi danh sách kiện hàng đã Nhập/Bán!");

            bool res = _luuDonBan.UpdateDonBan(hOld, hNew);
            if (!res)
                throw new Exception("Không tìm thấy Đơn Hàng để sửa!");
        }
        public void DeleteDonBan(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id không hợp lệ!");

            bool res = _luuDonBan.DeleteDonBan(id);
            if (!res)
                throw new Exception("Không tìm thấy Hoá Đơn Bán để xóa!");
        }
    }
}
