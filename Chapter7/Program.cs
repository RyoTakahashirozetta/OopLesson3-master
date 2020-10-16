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
            Console.WriteLine("問題7.1.1");
            Exercise1_1(text); //問題7.1.1
            Console.WriteLine("\n問題7.1.2");
            Exercise1_2(text);//問題7.1.2

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

        static void Exercise1_2(string text) {
            var dict = new SortedDictionary<char, int>();
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
            foreach (var sort in dict) {
                Console.WriteLine($"'{sort.Key}'：{sort.Value}");
            }
        }
    }
}
