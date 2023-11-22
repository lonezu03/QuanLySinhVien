using System;
using System.Collections.Generic;
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
            var ds = new taoList<doAn3.sinhvien>();
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
                Console.WriteLine("|{0,-40}|{1,-60}|", "1.Thêm sinh viên", "7.Hoàn tác vụ");
                Console.WriteLine("|{0,-40}|{1,-60}|", "2.Thêm nhiều sinh viên", "8.Lọc sinh viên theo lớp");
                Console.WriteLine("|{0,-40}|{1,-60}|", "3.Xem danh sách sinh viên", "9.xếp sinh viên đủ điều kiện tốt nghiệp)");
                Console.WriteLine("|{0,-40}|{1,-60}|", "4.Lưu file!!", "10.Sắp xếp tăng dần theo MSSV(Bubble sort)");
                Console.WriteLine("|{0,-40}|{1,-60}|", "5.Đọc file", "11.Sắp xếp tăng dần theo MSSV(quick sort)");
                Console.WriteLine("|{0,-40}|{1,-60}|", "6.Xóa sinh viên khỏi danh sách sinh viên", "12.Sắp xếp tăng dần theo MSSV(heap sort)");

                Console.WriteLine("|{0,-40}|{1,-60}|", "", "15.Thoát menu");
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
                            ds.themSV(ds);
                            ds.xuatDS();
                           
                            ds.luuFile("doc.txt",ds);
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
                            ds.luuFile("doc.txt", ds);
                            break;
                        };
                    case 5:
                        {
                            ds.DocFile("doc.txt", ds);
                            Console.WriteLine("\nDanh sách sinh viên sau khi đọc file là: ");
                            ds.xuatDS();
                            break;
                        };
                    case 6:
                        {
                   
                            ds.Remove();
       
                            ds.luuFile("doc.txt", ds);
                           
                            break;
                        };
                    case 7:
                        {
                            if (pre == 1)
                            {
                                ds.backThem();
                                Console.WriteLine("\nDanh sách sau khi hoàn tác là: !!!");
                                ds.xuatDS();
                            }
                            else if (pre == 6)
                            {
                                ds.backXoa();
                                Console.WriteLine("\nDanh sách sau khi hoàn tác là: !!!");
                                ds.xuatDS();
                            }
                            else
                                Console.WriteLine("\nLưu ý chỉ được hoàn tác sau khi đã thêm hoặc xóa !!!");
                            break;
                        };
                    case 8:
                        {
                            var dsLop = new taoList<doAn3.sinhvien>();
                            dsLop.Header = null;
                            ds.xepSVTheoKhoa(ds, dsLop);

                            break;
                        };
                    case 9:
                        {
                            var dsTotnghiep = new taoList<doAn3.sinhvien>();
                            dsTotnghiep.Header = null;
                            ds.xepSVDuDKTotNghiep(ds, dsTotnghiep);
                            break;
                        };
                    case 10:
                        {
                            ds.BubbleSort();
                            ds.xuatDS();
                            break;
                        }
                    case 11:
                        {
                            ds.QuickSort();
                            //ds.xuatSV(ds.Header.Data);
                            
                            ds.xuatDS();
                            break;
                        }
                    case 12:
                        {
                            ds.HeapSort();
                            
                            ds.xuatDS();
                            break;
                        }
                    default:
                        break;
                }
            } while (chon != 15);
        }
    }
}

   
