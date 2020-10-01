using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4 {
    class Program {
        static void Main(string[] args) {
            string code = "12345";

            var massage = GetMassage(code) ?? DefaultMassage();
            Console.WriteLine(massage);
        }

        //スタブ
        private static object DefaultMassage() {
            return "DefaultMassage";
        }
        //スタブ
        private static object GetMassage(string code) {
            return "123";
        }
    }
}
