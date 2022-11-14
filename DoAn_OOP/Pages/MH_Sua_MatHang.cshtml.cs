using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuanLyCuaHang_Entities;
using QuanLyCuaHang_Services;

namespace Web_QuanLyCuaHang_OOP.Pages
{
    public class MH_Sua_MatHangModel : PageModel
    {
        public string chuoiThongBao = String.Empty;
        private IXuLyMatHang _xuLyMatHang = new XuLyMatHang();
        public MatHang mh = new();
        [BindProperty(SupportsGet = true)]
        public string ID { get; set; }
        [BindProperty]
        public string NewCategoryID { get; set; }
        [BindProperty]
        public string NewName { get; set; }
        [BindProperty]
        public string NewCompany { get; set; }
        [BindProperty]
        public int NewYear { get; set; }
        [BindProperty]
        public DateTime NewExp { get; set; }
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
                MatHang MatHang = new MatHang()
                {
                    Id = ID,
                    CategoryId = NewCategoryID,
                    Name = NewName,
                    Company = NewCompany,
                    Year = NewYear,
                    Exp = NewExp,
                    SoLuong = mh.SoLuong
                };
                _xuLyMatHang.UpdateMatHang(MatHang);
                mh = MatHang;
                Response.Redirect($"./MH_Sua_MatHang?Id={mh.Id}");
            }
            catch (Exception ex)
            {
                chuoiThongBao = ex.Message;
                try
                {
                    mh = _xuLyMatHang.ReadMatHangById(ID);
                }
                catch (Exception ex2)
                {
                    chuoiThongBao = ex2.Message;
                }
            }
        }
    }
}
