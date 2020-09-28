using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3 {
    class Program {
        static void Main(string[] args) {

            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            #region 3-1-1
            //Console.WriteLine("\n--- 3.1.1 -----");
            //var exists = numbers.Exists(s => s % 8 == 0 || s % 9 == 0);

            //Console.WriteLine(exists);
            #endregion

            #region 3-1-2
            //Console.WriteLine("\n--- 3.1.2 -----");
            //numbers.ForEach(s => Console.WriteLine(s/2.0));
            #endregion

            #region 3-1-3
            //Console.WriteLine("\n--- 3.1.3 -----");
            //var wher = numbers.Where(s => s >= 50);
            //foreach (var item in wher) {
            //    Console.WriteLine(item); ;
            //}
            #endregion

            #region 3-1-4
            //Console.WriteLine("\n--- 3.1.4 -----");
            //List<int> lists = numbers.Select(s => s * 2).ToList();
            //foreach (var item in lists) {
            //    Console.WriteLine(item);
            #endregion


            var names = new List<string> {
                "Tokyo","New Delhi","Bangkok","London","Paris","Berlin","Canberra","Hong Kong",
            };

            #region 3-2-1
            Console.WriteLine("\n--- 3.2.1 -----");
            Console.WriteLine("都市名を入力。空行で終了");
            do {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    break;
                }

                int index = names.FindIndex(s => s == line);
                Console.WriteLine(index);
            } while (true);



            #endregion

            #region 3-2-2
            Console.WriteLine("\n--- 3.2.2 -----");
            var query = names.Count(s => s.Contains('o'));
            Console.WriteLine(query);
            #endregion

            #region 3-2-3
            Console.WriteLine("\n--- 3.2.3 -----");
            var list3 = names.Where(s => s.Contains('o')).ToArray();
            foreach (var item in list3) {
                Console.WriteLine(item);
            }
            #endregion

            #region 3-2-4
            Console.WriteLine("\n--- 3.2.4 -----");
            var list4 = names.Where(s => s.StartsWith("B")).Select(s => s.Length);
            foreach (var item in list4) {
                Console.WriteLine(item);
            }
            #endregion
        }






    }
}
