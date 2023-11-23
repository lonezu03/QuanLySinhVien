using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doAn3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            var ds = new List();
            ds.Header = null;
            int chon = 0;
            var SVtmp = new sinhvien();
            ds.DocFile("doc.txt", ds);

            do
            {
                Console.WriteLine(new string('-', 103));
                Console.Write(new string('-', 39));
                Console.Write("MENU");
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("|{0,-40}|{1,-60}|", "1.Thêm sinh viên", "6.Tìm kiếm sinh viên bằng mssv");
                Console.WriteLine("|{0,-40}|{1,-60}|", "2.Thêm nhiều sinh viên", "7.Lọc danh sách sinh viên");
                Console.WriteLine("|{0,-40}|{1,-60}|", "3.Xem danh sách sinh viên", "8.Sắp xếp tăng dần theo MSSV(Bubble sort)");
                Console.WriteLine("|{0,-40}|{1,-60}|", "4.Lưu file!!", "9.Thoát menu");
                Console.WriteLine("|{0,-40}|{1,-60}|", "5.Xóa sinh viên khỏi danh sách sinh viên", "");
                Console.WriteLine(new string('-', 103));
                //Console.WriteLine("13.Độ dài của danh sách: ");
                Console.Write("\nNhap lựu chọn: ");
                int pre = 0;
                if (chon != 0)
                    pre = chon;
                chon = Int32.Parse(Console.ReadLine());
                Console.WriteLine("***********************************************************************************************************");
                switch (chon)
                {
                    case 1:
                        {
                            ds.themSV();
                            ds.xuatSV(ds.Header.Data);
                            ds.xuatDS();
                            break;
                        };
                    case 2:
                        {
                            ds.themNhieuSV();
                            break;
                        }
                    case 3:
                        {
                            ds.xuatDS();
                            break;
                        };
                    case 4:
                        {
                            ds.luuFile("doc.txt", ds.Header);
                            break;
                        };
                    case 5:
                        {
                            ds.Remove();
                            ds.luuFile("doc.txt", ds.Header);
                            break;
                        };
                    case 6:
                        {
                            
                            Node sv=ds.timsv();
                            if (sv == null)
                                Console.WriteLine("\nDanh sách không có sinh viên mà bạn cần tìm");
                            else {
                                Console.WriteLine("\nSinh Viên bạn cần tìm là: ");
                                ds.xuatSV(sv.Data);
                            }
                            break;
                        };
                    case 7:
                        {
                            ds.locSinhVienTheoYeuCau();
                            break;
                        };
           
                 
                    case 8:
                        {
                            ds.menububblesort();
                            ds.xuatDS();
                            break;
                        }
                 
                 
                    //case 9:
                    //    {
                    //        using (StreamWriter a = new StreamWriter("doc.txt"))
                    //        {
                                
                                
                                    
                    //                    var p = ds.Header;
                    //                    while (p != null)
                    //                    {
                    //                        a.WriteLine(p.Data.IdSV);
                    //                        a.WriteLine(p.Data.NameSV);
                    //                        a.WriteLine(p.Data.Lop);
                    //                        a.WriteLine(p.Data.NgayCTXH);
                    //                        a.WriteLine(p.Data.TinChi);
                    //                        a.WriteLine(p.Data.DiemLyThuyet);
                    //                        a.WriteLine(p.Data.DiemThucHanh);
                    //                        p = p.Next;
                    //                    }
                    //             Console.WriteLine("\nLưu file thành công");
                    //             return;
                    //        }
                    //        break;
                    //    }
                    default:
                        break;
                }
            } while (chon != 9);
            
        }
    }
}

   
