using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace doAn3
{
    [Serializable]
    public class sinhvien : IComparable<sinhvien>
    {
        private string m_idSV;
        private string m_nameSV;
        private string m_lop;
        private int m_ngayCTXH;
        private int m_tinChi;

        private double m_diemLyThuyet;
        private double m_diemThucHanh;

        public string IdSV { get => m_idSV; set => m_idSV = value; }
        public string NameSV { get => m_nameSV; set => m_nameSV = value; }
        public string Lop { get => m_lop; set => m_lop = value; }
        public int NgayCTXH { get => m_ngayCTXH; set => m_ngayCTXH = value; }
        public int TinChi { get => m_tinChi; set => m_tinChi = value; }
        public double DiemLyThuyet { get => m_diemLyThuyet; set => m_diemLyThuyet = value; }
        public double DiemThucHanh { get => m_diemThucHanh; set => m_diemThucHanh = value; }

        public sinhvien(string idSV, string nameSV, string lop, int ngayCTXH, int tinChi, double diemLyThuyet, double diemThucHanh)
        {
            m_idSV = idSV;
            m_nameSV = nameSV;
            m_lop = lop;
            m_ngayCTXH = ngayCTXH;
            m_tinChi = tinChi;
            m_diemLyThuyet = diemLyThuyet;
            m_diemThucHanh = diemThucHanh;
        }
        public sinhvien()
        {
            m_idSV = "";
            m_nameSV = "";
            m_lop = "";
            m_ngayCTXH = -1;
            m_tinChi = -1;
            m_diemLyThuyet = -1;
            m_diemThucHanh = -1;
        }

        public int CompareTo(sinhvien other)
        {
            // Thực hiện phép so sánh dựa trên tiêu chí của bạn và trả về kết quả.
            // Ví dụ: so sánh theo m_idSV.
            return this.m_idSV.CompareTo(other.m_idSV);
        }
        public void xuat()
        {
            Console.Write("Ma SV: " + IdSV);
            Console.Write("Ten SV: " + NameSV);
            Console.Write("Khoa: " + Lop);
            Console.Write("So tin chi: " + TinChi);
            Console.Write("Ngay CTXH: " + NgayCTXH);
            Console.Write("Diem Ly thuyet: " + DiemLyThuyet);
            Console.Write("Diem thuc hanh: " + DiemThucHanh);
            Console.WriteLine();
        }
    }
    


}

