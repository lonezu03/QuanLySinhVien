using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace doAn3
{
    public class Node //where sinhvien : IComparable
        //public class Node<sinhvien> where sinhvien : IComparable
    {
        public  sinhvien Data { get; set; }
        public Node Next { get; set; }
        public Node()
        {
            Data = null;
            Next = null;
        }
        public Node( sinhvien a)
        {
            Data = a;
            Next = null;
        }
    }
    public class List
    {

        public int dem = -1;
        public Node Header { get; set; } = new Node();
        public  sinhvien tmp = new  sinhvien();

        private Node TimNode(string data)
        {
            if (Header != null)
            {
                var q = Header;
                var pNode = Header;
                while (pNode != null)
                {
                    if (pNode.Data.IdSV.CompareTo(data) == 0)
                        return pNode;
                    q = pNode;
                    pNode = pNode.Next;
                }
                return null;
            }
            else
                return null;
        }
        private Node FindPrevious(string data)
        {

            var q = Header;
            var pNode = Header;
            while (pNode != null)
            {
                if (pNode.Data.IdSV.CompareTo(data) == 0)
                    return q;
                q = pNode;
                pNode = pNode.Next;
            }
            return null;

        }
        private Node addlast( sinhvien data)
        {
            try { 
            var p = Header;
            var q = new Node(data);
            if (p == null)
            {
                Header = q; // Nếu danh sách rỗng, thiết lập Header thành q
            }
            else
            {
                var c = Header;
                while (c != null)
                {
                    if (c.Data.IdSV.CompareTo(data.IdSV) == 0)
                    {
                        Console.WriteLine("\n------------------------- Mã số sinh viên bị trùng !!!------------------------------------------");
                        return null;
                    }
                    c = c.Next;
                }
                p = Header;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = q;
            }
            tmp = q.Data;
            //cay.Add(data);
            return q;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void init()
        {
            Header= null;
        }
        private Node addfirst( sinhvien data)
        {
            var p = Header;
            var q = new Node(data);
            if (p != null)
            {
                q.Next = Header;
                Header = q;
            }
            else
                Header = q;
            return q;
        }
        private bool xetTrungmsv(string ma)
        {
            Node p = Header;
            while(p!=null)
            {
                if (p.Data.IdSV == ma)
                    return true;
                p=p.Next;
            }
            return false;
        }
        #region case 5 xóa sv

        public void xoaSV()
        {
            char d = 'a';
            do
            {
                Console.Write("\nNhập mã sinh viên mà bạn muốn xóa khỏi danh sách: ");
                string ma = Console.ReadLine();
                while (!xetTrungmsv(ma))
                {
                    char b;
                    do
                    {
                        Console.Write("\nMã số sinh viên không tồn tại ");
                        Console.Write("\nBạn có muốn nhập lại không ('y'xác nhận 'n' không): ");
                        b = char.Parse(Console.ReadLine());
                    } while (b != 'y' && b != 'n');
                    if (b == 'y')
                    {
                        Console.Write("\n Nhập mã của sinh viên: ");
                        ma = Convert.ToString(Console.ReadLine());
                    }
                    else
                        return;

                }
                Remove(ma);
                Console.Write("\nBạn có muốn xóa tiếp không (bất kì phím gì để tiếp tục,'n' để dừng lại): ");
                d = char.Parse(Console.ReadLine());
            } while (d != 'n');

        }
        public void Remove(string ma)
        {
            if (Header != null)
            {
                var p = Header;
                char a = 'A';
           

                if (Header.Data.IdSV != ma)
                {
                    var previousNode = FindPrevious(ma);
                    if (previousNode != null)
                    {
                        do
                        {
                            Console.Write("\nBạn có xác nhận('y' để xác nhận 'n' để hủy thao tác xóa): ");
                            a = char.Parse(Console.ReadLine());
                            if (a == 'n')
                                return;
                        } while (a != 'y');
                        tmp = previousNode.Data;
                        previousNode.Next = previousNode.Next.Next;
                        Node tam = Header;
                        luuFile("doc.txt", tam);
                    }
                    else
                    {
                        Console.WriteLine("\nKhông tìm thấy mã sinh viên bạn muốn xóa!!!");
                        return;
                    }
                }
                else
                {
                    do
                    {
                        Console.Write("\nBạn có xác nhận xóa hay không('y' để xác nhận 'n' để hủy thao tác xóa): ");
                        a = char.Parse(Console.ReadLine());
                        if (a == 'n')
                            return;
                    } while (a != 'y');
                    tmp = Header.Data;
                    Header = Header.Next;
                    Node tam = Header;
                    luuFile("doc.txt", tam);

                }
                Console.WriteLine("\nDanh sách sinh viên sau khi xóa là: ");
                xuatDS();
            }
            else
            {
                Console.WriteLine("\nDanh sách rỗng thao tác không được thực thi !!!");
                return;
            }
        }
        #endregion
        #region case 3 xuất ds sv
        public void xuatSV( sinhvien a)
        {
            Console.WriteLine($"| {a.IdSV,10} | {a.NameSV,20} | {a.Lop,8} | {a.TinChi,8} | {a.NgayCTXH,10} | {a.DiemLyThuyet,14} | {a.DiemThucHanh,14} |{a.diemTB,7}|");
        }
        public void xuatDS()
        {

            // Console.WriteLine("\nXuất danh sách đây:");
            Console.WriteLine(new string('-', 113));
            Console.WriteLine($"| {"ID",10} | {"Name",20} | {"Lop",8} | {"TinChi",8} | {"NgayCTXH",10} | {"DiemLyThuyet",14} | {"DiemThucHanh",14} |{"DiemTB",7}|");
            Console.WriteLine(new string('-', 113));

            Node p = Header;
            while (p != null)
            {
                xuatSV(p.Data);
                p = p.Next;
            }
            Console.WriteLine(new string('-', 113));
            Console.WriteLine();
        }
#endregion
        #region case 1 thêm sv
        public void themSV()
        {
            try
            {
                char d='a';
                do { 
                var a = new sinhvien();
                Console.WriteLine(new string('-', 113));
                Console.WriteLine($"| {"ID",10} | {"Name",20} | {"Lop",8} | {"TinChi",8} | {"NgayCTXH",10} | {"DiemLyThuyet",14} | {"DiemThucHanh",14} |{"DiemTB",7}|");
                Console.WriteLine(new string('-', 113));
                Console.Write("\n Nhập mã của sinh viên: ");
                a.IdSV = Convert.ToString(Console.ReadLine());
                while (xetTrungmsv(a.IdSV))
                {
                    char b;
                    do
                    {
                        Console.WriteLine("\n------------------------- Mã số sinh viên bị trùng !!!------------------------------------------");
                        Console.Write("\nBạn có muốn nhập lại không ('y'xác nhận 'n' không): ");
                        b = char.Parse(Console.ReadLine());
                    } while (b != 'y' && b != 'n');
                    if (b == 'y')
                    {
                        Console.Write("\n Nhập mã của sinh viên: ");
                        a.IdSV = Convert.ToString(Console.ReadLine());
                    }
                    else
                        return;

                }
                Console.Write("\n Nhập Tên của sinh viên: ");
                a.NameSV = Convert.ToString(Console.ReadLine());
                Console.Write("\n Nhập Lớp của sinh viên: ");
                a.Lop = Convert.ToString(Console.ReadLine());
                Console.Write("\n Nhập số ngày công tác xã hội chỉ sinh viên đã đạt đc: ");
                a.NgayCTXH = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n Nhập số tín chỉ sinh viên đã đạt đc: ");
                a.TinChi = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n Nhập điểm lý thuyêt của sinh viên: ");
                a.DiemLyThuyet = Convert.ToDouble(Console.ReadLine());
                Console.Write("\n Nhập điểm thực hành của sinh viên: ");
                a.DiemThucHanh = Convert.ToDouble(Console.ReadLine());
                addlast(a);
                Node c = Header;
                luuFile("doc.txt", c);
                    Console.Write("\nBạn có muốn thêm tiếp không (bất kì phím gì để tiếp tục,'n' để dừng lại): ");
                    d=char.Parse(Console.ReadLine());
                }while(d!='n');

        }
            catch (Exception)
            { return; }
}
        #endregion
        #region case 2 thêm nhiều sv
        //public void themNhieuSV()
        //{
        //    var a = new  sinhvien();
        //    Console.WriteLine(new string('-', 113));
        //    Console.WriteLine($"| {"ID",10} | {"Name",20} | {"Lop",8} | {"TinChi",8} | {"NgayCTXH",10} | {"DiemLyThuyet",14} | {"DiemThucHanh",14} |");
        //    Console.WriteLine(new string('-', 113));
        //    do
        //    {
        //        a = new  sinhvien();
        //        Console.Write("\n Nhập mã của sinh viên(exit để thoát): ");
        //        a.IdSV = Convert.ToString(Console.ReadLine());
        //        if (a.IdSV == "exit")
        //            break;
        //        Console.Write("\n Nhập Tên của sinh viên: ");
        //        a.NameSV = Convert.ToString(Console.ReadLine());
        //        Console.Write("\n Nhập Lớp của sinh viên: ");
        //        a.Lop = Convert.ToString(Console.ReadLine());
        //        Console.Write("\n Nhập số ngày công tác xã hội chỉ sinh viên đã đạt đc: ");
        //        a.NgayCTXH = Convert.ToInt32(Console.ReadLine());
        //        Console.Write("\n Nhập số tín chỉ sinh viên đã đạt đc: ");
        //        a.TinChi = Convert.ToInt32(Console.ReadLine());
        //        Console.Write("\n Nhập điểm lý thuyêt của sinh viên: ");
        //        a.DiemLyThuyet = Convert.ToDouble(Console.ReadLine());
        //        Console.Write("\n Nhập điểm thực hành của sinh viên: ");
        //        a.DiemThucHanh = Convert.ToDouble(Console.ReadLine());
        //        addlast(a);

        //        xuatDS();
        //    } while (a.IdSV != "exit");
        //}
        #endregion
        #region lưu, đọc File
        public void luuFile(string filename, Node head)
        {               
            
            using (StreamWriter a = new StreamWriter(filename)) { 
           
                        var p = head;
                while (p != null)
                {
                    a.WriteLine(p.Data.IdSV);
                    a.WriteLine(p.Data.NameSV);
                    a.WriteLine(p.Data.Lop);
                    a.WriteLine(p.Data.NgayCTXH);
                    a.WriteLine(p.Data.TinChi);
                    a.WriteLine(p.Data.DiemLyThuyet);
                    a.WriteLine(p.Data.DiemThucHanh);
                    p = p.Next;
                }
                Console.WriteLine("\nLưu file thành công");
                return;
               // a.Close();
            }
        }
        public void DocFile(string fileName, List ds)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                while (!r.EndOfStream)
                {
                    var a = new  sinhvien();
                    a.IdSV = r.ReadLine();
                    a.NameSV = r.ReadLine();
                    a.Lop = r.ReadLine();
                    a.NgayCTXH = double.Parse(r.ReadLine());
                    a.TinChi = Int32.Parse(r.ReadLine());
                    a.DiemLyThuyet = double.Parse(r.ReadLine());
                    a.DiemThucHanh = double.Parse(r.ReadLine());
                    ds.addlast(a);
                }
            }
        }
        #endregion

        public void backThem()
        {
            Console.WriteLine("\n Bạn đã chọn hoàn tác sau khi thêm !!!");

            var previousNode = FindPrevious(tmp.IdSV);
            if (previousNode != null)
            {
                previousNode.Next = previousNode.Next.Next;
            }
        }
        public void backXoa()
        {
            addlast(tmp);
        }
        #region case 8 xắp sếp bubblesort
        public void menububblesort()
        {
          
           int chon;
            do
            {
                Console.WriteLine(new string('-', 82));
                Console.WriteLine("|{0,-80}|", "menu BubbleSort!!!");
                Console.WriteLine(new string('-', 82));
                Console.WriteLine("|{0,-80}|", "1. xắp sếp theo mã sinh viên");
                Console.WriteLine("|{0,-80}|", "2.xắp sếp theo họ và tên sinh viên");
                Console.WriteLine("|{0,-80}|", "3.xắp sếp theo lớpg");
                Console.WriteLine("|{0,-80}|", "4.xắp sếp theo số ngày công tác xã hội đã đạt được");
                Console.WriteLine("|{0,-80}|", "5.xắp sếp theo số tín chỉ đã hoàn thành");
                Console.WriteLine("|{0,-80}|", "6.xắp sếp theo điểm trung bình tất cả môn lý thuyết của sinh viên");
                Console.WriteLine("|{0,-80}|", "7.xắp sếp theo điểm trung bình tất cả môn thực hành của sinh viên");
                Console.WriteLine("|{0,-80}|", "8.xắp sếp theo điểm trung bình tất cả môn thực hành và lý thuyết của sinh viên");
                Console.WriteLine(new string('-', 82));
                Console.WriteLine("\nBạn muốn xắp sếp theo thuộc tính nào của sinh viên ");
                
                chon = Convert.ToInt32(Console.ReadLine());
            } while (chon < 0 || chon > 8);
            int chonKieuXep;
            do
            {
                Console.WriteLine("1. Chọn kiểu xếp từ bé đến lớn ");
                Console.WriteLine("2. Chọn kiểu xếp từ lớn đến bé ");

                chonKieuXep = Convert.ToInt32(Console.ReadLine());

            } while (chonKieuXep < 0 || chonKieuXep > 3);
            if (chonKieuXep == 1) { 
            switch (chon)
            {
                case 1:
                    {
                        BubbleSort(xepByIdSV);
                        break;
                    }
                case 2:
                    {
                        BubbleSort(xepByTen);
                        break;
                    }
                case 3:
                    {
                        BubbleSort(xepByLop);
                        break;
                    }
                case 4:
                    {
                        BubbleSort(xepBySoNgayCTXH);
                        break;
                    }
                case 5:
                    {
                        BubbleSort(xepByTinChi);
                        break;
                    }
                case 6:
                    {
                        BubbleSort(xepByDiemLT);
                        break;
                    }
                case 7:
                    {
                        BubbleSort(xepByDiemTH);
                        break;
                    }
                    case 8:
                        {
                            BubbleSort(xepByDiemTB);
                            break;
                        }
                default:
                    {
                        Console.WriteLine("\nLựa chọn không hợp lệ !!!");
                        break;
                    }
            }
            }
            else
            {
                switch (chon)
                {
                    case 1:
                        {
                            BubbleSortLonDenBe(xepByIdSV);
                            break;
                        }
                    case 2:
                        {
                            BubbleSortLonDenBe(xepByTen);
                            break;
                        }
                    case 3:
                        {
                            BubbleSortLonDenBe(xepByLop);
                            break;
                        }
                    case 4:
                        {
                            BubbleSortLonDenBe(xepBySoNgayCTXH);
                            break;
                        }
                    case 5:
                        {
                            BubbleSortLonDenBe(xepByTinChi);
                            break;
                        }
                    case 6:
                        {
                            BubbleSortLonDenBe(xepByDiemLT);
                            break;
                        }
                    case 7:
                        {
                            BubbleSortLonDenBe(xepByDiemTH);
                            break;
                        }
                    case 8:
                        {
                            BubbleSortLonDenBe(xepByDiemTB);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nLựa chọn không hợp lệ !!!");
                            break;
                        }
                }
            }

        }

        public void BubbleSort(Func<doAn3.sinhvien, doAn3.sinhvien, int> compareFunc)//truyền vào là 1 tham chiếu tới 1 hàm khác nhập vào 2 sv và trả về 1 số nguyên 
        {
            bool swapped;
            do
            {
                swapped = false;
                Node p = Header;
                Node prev = null;

                while (p != null && p.Next != null)
                {
                    if (compareFunc(p.Data, p.Next.Data) > 0)// dùng Delegate Func để so sánh 7 thuộc tính khác nhau bằng 1 hàm bubblesort chung
                    {
                        // Swap node data
                        Node temp = p.Next;
                        p.Next = temp.Next;
                        temp.Next = p;

                        if (prev == null)
                        {
                            Header = temp;
                        }
                        else
                        {
                            prev.Next = temp;
                        }

                        prev = temp;
                        swapped = true;
                    }
                    else
                    {
                        prev = p;
                        p = p.Next;
                    }
                }
            } while (swapped);
        }
        public void BubbleSortLonDenBe(Func<doAn3.sinhvien, doAn3.sinhvien, int> compareFunc)//truyền vào là 1 tham chiếu tới 1 hàm khác nhập vào 2 sv và trả về 1 số nguyên 
        {
            bool swapped;
            do
            {
                swapped = false;
                Node p = Header;
                Node prev = null;

                while (p != null && p.Next != null)
                {
                    if (compareFunc(p.Next.Data, p.Data) > 0)// dùng Delegate Func để so sánh 7 thuộc tính khác nhau bằng 1 hàm BubbleSort chung
                    {
                        // Swap node data
                        Node temp = p.Next;
                        p.Next = temp.Next;
                        temp.Next = p;

                        if (prev == null)
                        {
                            Header = temp;
                        }
                        else
                        {
                            prev.Next = temp;
                        }

                        prev = temp;
                        swapped = true;
                    }
                    else
                    {
                        prev = p;
                        p = p.Next;
                    }
                }
            } while (swapped);
        }
        public int xepByIdSV(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            return a.IdSV.CompareTo(b.IdSV);
        }
        public int xepByTen(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            // Tách tên thành các từ
            string[] arrSVA = a.NameSV.Split(' '); 
            string[]  arrSVB= b.NameSV.Split(' '); 
            // Lấy từ cuối của chuỗi từ
            string TenCuaA = arrSVA[arrSVA.Length - 1]; 
            string TenCuaB = arrSVB[arrSVB.Length - 1]; 
                //lấy chữ cuối
            char chuCaiDauA = char.ToUpper(TenCuaA[0]); 
            char chuCaiDauB = char.ToUpper(TenCuaB[0]); 
            // So sánh 
            return chuCaiDauA.CompareTo(chuCaiDauB);
        }

        public int xepByLop(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            return a.Lop.CompareTo(b.Lop);
        }
        public int xepBySoNgayCTXH(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            return a.NgayCTXH.CompareTo(b.NgayCTXH);
        }
        public int xepByTinChi(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            return a.TinChi.CompareTo(b.TinChi);
        }
        public int xepByDiemLT(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            return a.DiemLyThuyet.CompareTo(b.DiemLyThuyet);
        }
        public int xepByDiemTH(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            return a.DiemLyThuyet.CompareTo(b.DiemLyThuyet);
        }
        public int xepByDiemTB(doAn3.sinhvien a, doAn3.sinhvien b)
        {
            return a.diemTB.CompareTo(b.diemTB);
        }

        public void QuickSort()
        {
            Header = QuickSort(Header);
        }
        #endregion
        #region quicksort và heapsort
        private Node QuickSort(Node head)
        {
            if (head.Data == null || head.Next == null)//điều khiện dừng đệ qui là khi node đó rỗng hay không có đuôi
                return head;

             sinhvien pivotValue = head.Data;//lấy node đầu để so bé hơn lớn hơn

            Node dsNho = new Node();
            Node dsBang = new Node();
            Node dsLon = new Node();

            Node p = head;
            while (p != null)
            {
                int compareResult = p.Data.IdSV.CompareTo(pivotValue.IdSV);
                if (compareResult < 0)//bé hơn vào ds lesser
                {
                    InsertTail(dsNho, p.Data);
                }
                else if (compareResult == 0)
                {
                    InsertTail(dsBang, p.Data);
                }
                else//lớn hơn vào greater
                {
                    InsertTail(dsLon, p.Data);
                }
                p = p.Next;
            }

            dsNho = QuickSort(dsNho);
            dsLon = QuickSort(dsLon);

            return ConcatenateLists(dsNho, dsBang, dsLon);//nối 3 chuỗi lại 
        }

        // Các phương thức hỗ trợ

        private void InsertTail(Node list,  sinhvien data)
        {
            if (list.Data != null)
            {
                var p = list;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = new Node(data);
            }
            else
            {
                list.Data = data;
            }
        }
        private Node ConcatenateLists(Node a, Node b, Node c)
        {
            if (a.Data == null && b.Data == null && c.Data == null)//trường hợp 3 ds đều null
            {
                return null;
            }
            if (a.Data == null)//trường hợp ds a =null
            {
                if (b.Data == null && c.Data == null)//a,b,c đều null
                {
                    return null;
                }
                if (b.Data == null)//a,b đều null thì trả về c
                {
                    return c;
                }
                if (c.Data == null)//a,c null thì trả về b
                {
                    return b;
                }
                //th a null b và c khác null
                Node temp = b;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = c;
                return b;
            }
            //th a khác null
            Node tail = a;
            while (tail.Next != null)
            {
                tail = tail.Next;
            }
           
            if (b.Data != null) //a , b  khác null
            {
                tail.Next = b;
                while (tail.Next != null)
                {
                    tail = tail.Next;
                }
            }
            // a,b,c khác null
            if (c.Data != null)
            {
                tail.Next = c;
            }
            return a;
        }
        public int Length()// tìm số lượng sv trong ds
        {
            int de = 0;
            var p = Header;
            while (p != null)
            {
                de++;
                p = p.Next;
            }
            return de;
        }

        public void HeapSort()
        {
            int length = Length();
            for (int i = length / 2 - 1; i >= 0; i--)//tạo 1 tree ảo 
            {
                Heapify(length, i);
            }

            for (int i = length - 1; i >= 0; i--)//xếp tree ảo theo quy luật heapify
            {
                Node p = Header;
                Node prev = null;
                for (int j = 0; j < i; j++)
                {
                    prev = p;
                    p = p.Next;
                }
                Swap(p, Header);

                Heapify(i, 0);

                if (prev == null)
                {
                    Header = p;
                }
                else
                {
                    prev.Next = p;
                }
            }
        }

        private void Heapify(int length, int rootIndex)
        {
            int NodeGoc = rootIndex;
            int NodeTrai = 2 * rootIndex + 1;
            int NodePhai = 2 * rootIndex + 2;

            if (NodeTrai < length && FindNodeAtIndex(NodeTrai).Data.CompareTo(FindNodeAtIndex(NodeGoc).Data) > 0)
            {
                NodeGoc = NodeTrai;
            }

            if (NodePhai < length && FindNodeAtIndex(NodePhai).Data.CompareTo(FindNodeAtIndex(NodeGoc).Data) > 0)
            {
                NodeGoc = NodePhai;
            }

            if (NodeGoc != rootIndex)
            {
                Node NodeGocNode = FindNodeAtIndex(NodeGoc);
                Swap(NodeGocNode, FindNodeAtIndex(rootIndex));

                Heapify(length, NodeGoc);
            }
        }
        private Node FindNodeAtIndex(int index)//tìm node bằng số thứ tự của cây ảo
        {
            var p = Header;
            for (int i = 0; i < index; i++)
            {
                p = p.Next;
            }
            return p;
        }
        private void Swap(Node a, Node b)
        {
             sinhvien temp = a.Data;
            a.Data = b.Data;
            b.Data = temp;
        }
        #endregion

    
        #region case 6 tìm 
        public Node timsv()
        {
            string ma;
            Node sv=null;
            Console.WriteLine("\n Nhập mã số sinh viên muốn tìm: ");
            ma = Console.ReadLine();
            if (TimNode(ma) != null)
            {
                sv = TimNode(ma);
                Console.WriteLine(sv.Data.NameSV);
                return sv;
            }
            else
            {
                Console.WriteLine("\nDanh sách không có sinh viên mà bạn cần tìm");

                char b = 'A';
                do
                {
                    Console.Write("\nBạn có muốn nhập lại không ('y'xác nhận 'n' không): ");
                    b = char.Parse(Console.ReadLine());

                } while (b != 'n'&&b!='y');
                if (b == 'y')
                {
                   return timsv();
                }
            }
            return sv;
        }
        #endregion

        #region case 7 lọc
        //case 7
        public void locSVTheoKhoa(Node head, List lsTheoLop)
        {
            if (head != null)
            {
                string lop;
                var p = head;
                Console.Write("\nNhập lớp mà bạn muốn lọc danh sách theo: ");
                lop = Console.ReadLine();
                while (p != null)
                {
                    if (p.Data.Lop.CompareTo(lop) == 0)
                        lsTheoLop.addlast(p.Data);
                    p = p.Next;
                }
                Console.WriteLine("\nDanh sách sinh viên lop " + lop + ": ");
                //lsTheoLop.xuatDS();
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");
            return;
        }
        public void locSVDuDKTotNghiep(Node head, List lsTotNghiep)
        {
            if (head != null)
            {
                var p = head;
                while (p != null)
                {
                    if (p.Data.NgayCTXH >= 10 && p.Data.TinChi >= 150)
                        lsTotNghiep.addlast(p.Data);
                    p = p.Next;
                }
                Console.Write("\nDanh sách sinh viên đủ điều kiện tốt nghiệp là:");
                Console.WriteLine("\nĐiều kiện tốt nghiệp là ngày ctxh đủ 10 ngày và số tín chỉ đủ hoặc hơn 150");
                //lsTotNghiep.xuatDS();
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");

        }
        public void locTen(Node head,List dstheoTen)
        {
            
            if (head != null)
            {
                string ten;
                
                var p = head;
                Console.Write("\nNhập tên sinh viên mà bạn muốn lọc: ");
                ten = Console.ReadLine();
                while (p != null)
                {
                    string[] arrSVA = p.Data.NameSV.Split(' ');
                    string TenCuaP = arrSVA[arrSVA.Length - 1];
                    if (TenCuaP.CompareTo(ten)==0)
                        dstheoTen.addlast(p.Data);
                    p = p.Next;
                }
               // Console.WriteLine("\nDanh sách sinh viên lop " + lop + ": ");
                //lsTheoLop.xuatDS();
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");
            return;
        }
         public void locSVGioi(Node head,List dsGioi)
        {
            if (head != null)
            {
                var p = head;
                Console.Write("\nBạn chọn lọc theo sinh viên có điểm trung bình là giỏi (LT+TH)>8.5đ ");

                while (p != null)
                {
                    if (p.Data.diemTB >= 8.5)
                        dsGioi.addlast(p.Data);
                    p = p.Next;
                }
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");
            return;
        }
        public void locSVKha(Node head,List dsKha)
        {
            if (head != null)
            {
                var p = head;
                Console.WriteLine("\nBạn chọn lọc theo sinh viên có điểm trung bình là Khá (Đtb>7 và <8.5) ");

                while (p != null)
                {
                    if (p.Data.diemTB >= 7&&p.Data.diemTB<8.5)
                        dsKha.addlast(p.Data);
                    p = p.Next;
                }
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");
            return;
        }
        public void locSVTB(Node head,List dsTB)
        {
            if (head != null)
            {
                var p = head;
                Console.WriteLine("\nBạn chọn lọc theo sinh viên có điểm trung bình là Khá (Đtb>7 và <8.5) ");

                while (p != null)
                {
                    if (p.Data.diemTB >= 5&&p.Data.diemTB<7)
                        dsTB.addlast(p.Data);
                    p = p.Next;
                }
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");
            return;
        }
        public void locSVYeu(Node head,List dsYeu)
        {
            if (head != null)
            {
                var p = head;
                Console.Write("\nBạn chọn lọc theo sinh viên có điểm trung bình là Yếu (LT+TH)<5 ");

                while (p != null)
                {
                    if (p.Data.diemTB <5)
                        dsYeu.addlast(p.Data);
                    p = p.Next;
                }
            }
            else
                Console.WriteLine("\nDanh sách sinh viên rỗng thao tác không được thực thi!!!");
            return;
        }


        public void locSinhVienTheoYeuCau()
        {
            int chon;
            do
            {
                Console.WriteLine(new string('-', 62));
                Console.WriteLine("Chọn kiểu mà bạn muốn lọc danh sách!!!");
                Console.WriteLine(new string('-', 62));
                Console.WriteLine("|{0,-60}|", "1.Lọc theo lớp");
                Console.WriteLine("|{0,-60}|", "2.Lọc theo tên");
                Console.WriteLine("|{0,-60}|", "3.Lọc những sinh viên đủ điều kiện ra trường");
                Console.WriteLine("|{0,-60}|", "4.Lọc những sinh viên có điểm trung bình loại giỏi");
                Console.WriteLine("|{0,-60}|", "5.Lọc những sinh viên có điểm trung bình loại khá");
                Console.WriteLine("|{0,-60}|", "6.những sinh viên có điểm trung bình loại trung bình");
                Console.WriteLine("|{0,-60}|", "7.những sinh viên có điểm trung bình loại yếu");
                Console.WriteLine(new string('-', 62));
                Console.WriteLine("Nhập lựa chọn:");
                chon = Convert.ToInt32(Console.ReadLine());


            } while (chon < 0 || chon > 7);
            switch (chon)
            {
                case 1:
                    {
                        List dstemp=new List();
                        dstemp.init();
                        locSVTheoKhoa(Header, dstemp);
                        dstemp.xuatDS();
                        XoaDanhSach(dstemp);
                        break;
                    } 
                case 2:
                    {
                        List dstemp=new List();
                        dstemp.init();
                        locTen(Header, dstemp);
                        dstemp.xuatDS();
                        XoaDanhSach(dstemp);
                        break;
                    } 

                case 3:
                    {
                        List dstemp=new List();
                        dstemp.init();
                        locSVDuDKTotNghiep(Header, dstemp);
                        dstemp.xuatDS();
                        XoaDanhSach(dstemp);
                        break;
                    }
                        case 4:
                    {
                        List dstemp=new List();
                        dstemp.init();
                        locSVGioi(Header, dstemp);
                        dstemp.xuatDS();
                        XoaDanhSach(dstemp);
                        break;
                    }
                        case 5:
                    {
                        List dstemp=new List();
                        dstemp.init();
                        locSVKha(Header, dstemp);
                        dstemp.xuatDS();
                        XoaDanhSach(dstemp);
                        break;
                    }  
                case 6:
                    {
                        List dstemp=new List();
                        dstemp.init();
                        locSVTB(Header, dstemp);
                        dstemp.xuatDS();
                        XoaDanhSach(dstemp);
                        break;
                    }
                        case 7:
                    {
                        List dstemp=new List();
                        dstemp.init();
                        locSVYeu(Header, dstemp);
                        dstemp.xuatDS();
                        XoaDanhSach(dstemp);
                        break;
                    }
                default:
                    {
                        break;
                    }


            }
        }
        #endregion
        public void XoaDanhSach(List ds)
        {
            Node p = ds.Header;
            Node q;

            while (p != null)
            {
                q = p.Next;
                p = null; // Giải phóng từng nút
                p = q;
            }

            ds.Header = null;//giải phóng header
        }
    }
}