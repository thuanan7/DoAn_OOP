using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Them_DonBanModel : PageModel
    {
        private IXuLyDonBan _xuLyDonBan = new XuLyDonBan();
        public string chuoiThongBao;
        [BindProperty]
        public string ID1 { get; set; }
        [BindProperty]
        public int n1 { get; set; }
        [BindProperty]
        public string ID2 { get; set; }
        [BindProperty]
        public int n2 { get; set; }
        [BindProperty]
        public string ID3 { get; set; }
        [BindProperty]
        public int n3 { get; set; }

        public void OnGet()
        {
            chuoiThongBao = string.Empty;
            n1 = n2 = n3 = 0;
        }

        public void OnPost()
        {

            try
            {
                List<KienHang> ds = new List<KienHang>
                {
                    new KienHang(ID1, n1),
                    new KienHang(ID2, n2),
                    new KienHang(ID3, n3)
                };
                _xuLyDonBan.CreateDonBan(ds);
                chuoiThongBao = "Tạo Hóa Đơn Bán Hàng Thành Công!";
                Response.Redirect("./MH_DanhSach_DonBan");
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
            }
        }
    }
}
