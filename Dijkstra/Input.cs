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
        void DocDsDinh()
        {
            XmlNodeList lsdinh = InputData.SelectNodes("Input/DsDinh/Dinh");
            foreach (XmlNode i in lsdinh)
            {
                Dinh temp = new Dinh();
                temp.name = i["name"].InnerText;
                _DsDinh.Add(temp);
            }
        }
        void DocDsCanh()
        {
            XmlNodeList lscanh = InputData.SelectNodes("Input/DsCanh/Canh");
            foreach (XmlNode i in lscanh)
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
                _DsTrongSo.Add(a);
            }
        }
        void DocRootEnd()
        {
            XmlNode rootend = InputData.SelectSingleNode("Input");
            _Root = rootend["Root"].InnerText;
            _End = rootend["End"].InnerText;
        }
        public void DocFile(string xmlfile)
        {
            try
            {
                InputData.Load(xmlfile);
                DocDsDinh();
                DocDsCanh();
                DocRootEnd();       
            }
            catch
            {
                Console.WriteLine("Khong the doc file");
            }
            SapXep();
        }
    }
}
