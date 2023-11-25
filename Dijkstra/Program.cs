using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {       
        static void Main(string[] args)
        {
            XuLy xlds = new XuLy();
            xlds.InputData.DocFile("InputDataFile.xml");
            xlds.TinhToan(xlds.InputData.FindPoint(xlds.InputData.Root));
            xlds.Xuat();
            Console.ReadLine();   
        }
    }
}
