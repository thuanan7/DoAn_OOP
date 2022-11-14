using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Xoa_MatHangModel : PageModel
    {
        public string chuoiThongBao = String.Empty;
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public MatHang mh = new();
        [BindProperty(SupportsGet = true)]
        public string ID { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(ID))
            {
                chuoiThongBao = "Id không hợp lệ!";
            }
            else
            {
                try
                {
                    mh = _xuLyMatHang.ReadMatHangById(ID);
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
                _xuLyMatHang.DeleteMatHang(ID);
                chuoiThongBao = "Xóa thành công!";
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
