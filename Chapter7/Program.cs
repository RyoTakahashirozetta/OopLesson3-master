using Chapter7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7 {
    class Program {
        static void Main(string[] args) {

            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text); //問題7.1.1


        }
        static void Exercise1_1(string text) {
            var dict = new Dictionary<char, int>();

            foreach (var t in text.ToUpper()) {
                if ('A' <= t && t <= 'Z') {
                    if (dict.ContainsKey(t)) {
                        dict[t]++;
                    }
                    else {
                        dict[t] = 1;
                    }
                }
            }
            var sorts = dict.OrderBy(s => s.Key);
            foreach (var sort in sorts) {
                Console.WriteLine($"'{sort.Key}'：{sort.Value}");
            }
             
        }
    }
}
