using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {
    class Program {
        static void Main(string[] args) {
            var ymCollection = new YearMonth[] {
                new YearMonth(1980,1),
                new YearMonth(1990,4),
                new YearMonth(2000,7),
                new YearMonth(2010,9),
                new YearMonth(2020,12),
            };
            //4.2.2
            Console.WriteLine("----4.2.2----");
            foreach (var item in ymCollection) {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------------");

            //4.2.4
            Console.WriteLine("----4.2.4----");
            var yearmonth = FindFirst21C(ymCollection);
            var s = ymCollection == null ? "21世紀のデータはありません" : ymCollection.ToString();
            Console.WriteLine(yearmonth);
            Console.WriteLine("-------------");

            //4.2.5
            Console.WriteLine("----4.2.5----");
            var array = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            foreach (var ym in array) {
                Console.WriteLine(ym);
            }
        }
            //4.2.3
            static YearMonth FindFirst21C(YearMonth[] yms) {
                foreach (var ym in yms) {
                    if (ym.Is21Century) {
                        return ym;
                    }
                }
                return null;
            }

           
        
    }
}
