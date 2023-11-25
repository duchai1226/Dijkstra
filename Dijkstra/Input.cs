using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dijkstra
{
    struct Canh
    {
        public Dinh dinhdau;
        public Dinh dinhcuoi;
        public double TrongSo;
    }
    class Input
    {
        XmlDocument InputData = new XmlDocument();
        string _Root; //Dinh bat dau
        string _End; //Dinh can toi
        List<Dinh> _DsDinh=new List<Dinh>();
        List<Canh> _DsTrongSo=new List<Canh>(); // 1 phan tu se co dang (A,B,n) voi n la so nguyen
        public string Root
        {
            get
            {
                return _Root;
            }
            set
            {             
                    Root = value;
            }
        }
        public string End
        {
            get
            {
                return _End;
            }
            set
            {
                End = value;
            }
        }
        public List<Dinh> DsDinh
        {
            get
            {
                return _DsDinh;
            }
            set
            {
                DsDinh = value;
            }
        }
        public List<Canh> DsTrongSo
        {
            get
            {
                return _DsTrongSo;
            }
            set
            {
                DsTrongSo = value;
            }

        }
        public void SapXep()
        {
            _DsDinh = _DsDinh.OrderBy(t => t.name).ToList();
        }
        public Dinh FindPoint(string name)
        {
            Dinh a=new Dinh();
            for (int i = 0; i < DsDinh.Count(); i++)
            {
                if (DsDinh[i].name == name)
                {
                    a= DsDinh[i];
                    break;
                }
            }
            return a;
        }
        public void DocFile(string xmlfile)
        {
            try
            {
                InputData.Load(xmlfile);
                XmlNodeList lsdinh = InputData.SelectNodes("Input/DsDinh/Dinh");
                XmlNodeList lscanh = InputData.SelectNodes("Input/DsCanh/Canh");
                foreach(XmlNode i in lsdinh)
                {
                    Dinh temp = new Dinh();
                    temp.name = i["name"].InnerText;
                    _DsDinh.Add(temp);
                }
                foreach(XmlNode i in lscanh)
                {
                    Canh a = new Canh();
                    Dinh b1 = new Dinh();
                    Dinh b2 = new Dinh();
                    a.TrongSo = double.Parse(i["trongso"].InnerText);
                    XmlNode temp = i.SelectSingleNode("dinhdau");
                    b1.name = temp["name"].InnerText;
                    a.dinhdau = b1;                 
                    temp = i.SelectSingleNode("dinhcuoi");
                    b2.name = temp["name"].InnerText;
                    a.dinhcuoi = b2;
                    //a.TrongSo = int.Parse(lscanh[i].SelectSingleNode("Canh/trongso").InnerText);
                    _DsTrongSo.Add(a);
                }
                XmlNode rootend = InputData.SelectSingleNode("Input");
                _Root = rootend["Root"].InnerText;
                _End = rootend["End"].InnerText;
            }
            catch
            {
                Console.WriteLine("Khong the doc file");
            }
            SapXep();
        }
        public void Nhap()
        {
            int n=0;
            Console.Write("Nhap so dinh: ");           
            n=int.Parse(Console.ReadLine());
            Console.WriteLine("\nNhap cac dinh:");
            for(int i=0;i<n;i++)
            {
                Dinh temp = new Dinh();
                Console.Write("Nhap ten dinh: ");
                temp.name = Console.ReadLine();
                _DsDinh.Add(temp);
            }
            Console.Write("Nhap so canh: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap cac canh:");
            for (int i = 0; i < n; i++)
            {
                Canh a = new Canh();
                Dinh c = new Dinh();
                Console.Write("Nhap ten dinh dau: ");
                c.name = Console.ReadLine();
                a.dinhdau = c;
                Console.Write("Nhap ten dinh cuoi: ");
                c.name = Console.ReadLine();
                a.dinhcuoi = c;
                Console.Write("Nhap trong so cua canh: ");
                int b = int.Parse(Console.ReadLine());
                a.TrongSo = b;
                _DsTrongSo.Add(a);
            }
            Console.Write("Nhap dinh bat dau: ");
            _Root = Console.ReadLine();
            Console.Write("Nhap dinh ket thuc: ");
            _End = Console.ReadLine();
        }
    }
}
