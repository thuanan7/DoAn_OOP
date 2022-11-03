using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang_Entities
{
    public class LoaiHang
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public LoaiHang()
        {
            Id = string.Empty;
            Name = string.Empty;
        }
    }
}
