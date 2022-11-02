namespace QuanLyCuaHang_Entities
{
    public class MatHang
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public DateTime Exp { get; set; }
        public int SoLuong { get; set; } 
        
        public MatHang()
        {
            Id = "0";
            Name = "null";
            Category = "null";
            Company = "null";
            Year = 0;
            Exp = DateTime.MinValue;
            SoLuong = 0;
        }
    }
}