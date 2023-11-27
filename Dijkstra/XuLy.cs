using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dijkstra
{
    struct Result
    {
        public double _tongTrongSo;
        public List<String> _map;
        public Result(Result a)
        {
            this._tongTrongSo = a._tongTrongSo;
            this._map = new List<string>(a._map);
        }
    }
    class XuLy
    {
        Input _InputData=new Input();
        List<Result> _ketQua = new List<Result>();
        public List<Result> ketQua
        {
            get
            {
                return _ketQua;
            }
            set
            {
                _ketQua = value;
            }
        }
       
        public Input InputData
        {
            get
            {
                return _InputData;
            }
            set
            {
                _InputData = value;
            }
        }      
        public void TinhToan(Dinh Root)
        {
            Result a = new Result ();// tao 1 bien kieu Result de tra ket qua ve danh sach ket qua
            List<string> check = new List<string> { _InputData.Root };//List chua cac dinh da xet
            a._map = new List<string> {_InputData.Root};//Khoi tao so do duong di ngan nhat         
            Root.Duyet(_InputData,this, check, a);//Tim cac duong di den dich
        } 
        public void Xuat()
        {
            Result min = new Result(ketQua[0]);
            foreach(Result i in ketQua)
            {
                if(i._tongTrongSo<min._tongTrongSo)
                {
                    min = i;
                }
            }
            Console.Write("Duong di ngan nhat: ");
            for(int i=0;i<min._map.Count;i++)
            {
                Console.Write("{0} ", min._map[i]);
            }
            Console.Write("\nDo dai duong di: {0}",min._tongTrongSo);
        }
    }
        
}
