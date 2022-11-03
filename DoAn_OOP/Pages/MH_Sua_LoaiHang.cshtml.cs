using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Sua_LoaiHangModel : PageModel
    {
        public string chuoiThongBao = String.Empty;
        private IXuLyLoaiHang _xuLyLoaiHang = new XuLyLoaiHang();
        public LoaiHang lh = new();
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty]
        public string NewName { get; set; }
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
                LoaiHang loaiHang = new LoaiHang()
                {

                    Id = Id,
                    Name = NewName,
                };
                _xuLyLoaiHang.UpdateLoaiHang(loaiHang);
                lh = loaiHang;
                chuoiThongBao = "Sửa thành công!";
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
