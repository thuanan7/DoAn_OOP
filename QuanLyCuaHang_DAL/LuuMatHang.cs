using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuanLyCuaHang_Entities;

namespace QuanLyCuaHang_DAL
{
    public class LuuMatHang : ILuuMatHang
    {
        private string filePath = "./files/MatHang.txt";
        private void LuuListSanPham(List<MatHang> ds)
        {
            StreamWriter sw = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds);
            sw.Write(json);
            sw.Close();
        }

        private string CreateIdMatHang(string categoryId)
        {
            var dsMatHang = ReadListMatHang();
            int max = 0;
            foreach (var s in dsMatHang)
            {
                string[] arr = s.Id.Split('_');
                int x = int.Parse(arr[1]);
                if (s.CategoryId == categoryId && x > max)
                    max = x;
            }
            max++;
            return categoryId + "_" + max.ToString();
        }

        public void CreateMatHang(MatHang mh)
        {
            var dsMatHang = ReadListMatHang();
            mh.Id = CreateIdMatHang(mh.CategoryId);
            dsMatHang.Add(mh);
            LuuListSanPham(dsMatHang);
        }

        public List<MatHang> ReadListMatHang()
        {
            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            sr.Close();

            return JsonConvert.DeserializeObject<List<MatHang>>(json);
        }
        public MatHang ReadMatHangById(string id)
        {
            var ds = ReadListMatHang();
            foreach (MatHang h in ds)
            {
                if (h.Id == id)
                    return h;
            }
            return null;
        }

        public List<MatHang> ReadListMatHangByCategoryId(string categoryId)
        {
            var dsMatHang = ReadListMatHang();
            List<MatHang> lst = new List<MatHang>();
            foreach (var s in dsMatHang)
            {
                if (s.CategoryId == categoryId) lst.Add(s);
            }
            return lst;
        }
        public bool UpdateMatHang(MatHang mh)
        {
            var dsMatHang = ReadListMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].Id == mh.Id)
                {
                    if (mh.CategoryId != dsMatHang[i].CategoryId)
                        mh.Id = CreateIdMatHang(mh.CategoryId);

                    dsMatHang[i] = mh;
                    LuuListSanPham(dsMatHang);
                    return true;
                }
            }
            return false;
        }
        public void UpdateCategoryMatHang(LoaiHang lh)
        {
            var dsMatHang = ReadListMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].CategoryId == lh.Id)
                {
                    dsMatHang[i].Category = lh.Name;
                }
            }
            LuuListSanPham(dsMatHang);
        }
        public bool UpdateSoLuongHangOfMatHang(MatHang mh, int soLuong)
        {
            var dsMatHang = ReadListMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].Id == mh.Id)
                {
                    int res = dsMatHang[i].SoLuong + soLuong;
                    if (res < 0)
                        return false;

                    dsMatHang[i].SoLuong = res;
                }
            }
            LuuListSanPham(dsMatHang);
            return true;
        }
        public bool DeleteMatHang(string id)
        {
            var dsMatHang = ReadListMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].Id == id)
                {
                    dsMatHang.RemoveAt(i);
                    LuuListSanPham(dsMatHang);
                    return true;
                }
            }
            return false;
        }
        public void DeleteMatHangByCategoryId(string categoryId)
        {
            var dsMatHang = ReadListMatHang();
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (dsMatHang[i].CategoryId == categoryId)
                {
                    dsMatHang.RemoveAt(i);
                    i--;
                }
            }
            LuuListSanPham(dsMatHang);
        }
    }
}
