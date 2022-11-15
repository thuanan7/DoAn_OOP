using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Xoa_LoaiHangModel : PageModel
    {
        public string chuoiThongBao = String.Empty;
        public int soLuong = 0;
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public LoaiHang lh = new();
        public List<MatHang> dsMatHang = new List<MatHang>();
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(Id))
            {
                chuoiThongBao = "Id không hợp lệ!";
            }
            else
            {
                try
                {
                    lh = _xuLyLoaiHang.ReadLoaiHangById(Id);
                    dsMatHang = _xuLyMatHang.ReadListMatHangByCategoryId(Id);
                    soLuong = dsMatHang.Count;
                }
                catch (Exception ex)
                {
                    chuoiThongBao = ex.Message;
                }
            }
        }

        public void OnPost()
        {
            try
            {
                _xuLyLoaiHang.DeleteLoaiHang(Id);
                chuoiThongBao = "Xóa thành công!";
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
