using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCShoesShop.Models
{
    public class Giohang
    {
        ShoesShopEntities data = new ShoesShopEntities();
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhbia { get; set; }
        public Double dDongia { get; set; }
        public int iSoluong { get; set; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        // Khởi tạo giỏ hàng theo mã sách được truyền vào với số lượng
        public Giohang(int Masp)
        {
            iMasp = Masp;
            SAN_PHAM SP = data.SAN_PHAM.Single(n => n.MaSP == iMasp);
            sTensp = SP.TenSP;
            sAnhbia = SP.Images;
            dDongia = double.Parse(SP.DonGia.ToString());
            iSoluong = 1;
        }
    }
}