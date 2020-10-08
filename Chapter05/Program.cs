using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5 {
    class Program {
        static void Main(string[] args) {
            //5.1
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();
            if (String.Compare(str1,str2,true) == 0) {
                Console.WriteLine("等しい");
            }
            else {
                Console.WriteLine("等しくない");
            }
            //5.2
            Console.WriteLine("----5.2----");
            Console.WriteLine("数値文字列");
            var line = Console.ReadLine();
            int num;
            if (int.TryParse(line,out num)) {
                Console.WriteLine(num.ToString("#,#"));
            }
            
            //5.3.1
            string str = "Jackdaws love my big sphinx of quartz";
            Console.WriteLine("----5.3.1----");
            var count = str.Count(s => s .Equals(' '));
            Console.WriteLine("空白数:{0}",count);

            //5.3.2
            Console.WriteLine("----5.3.2----");
            var replaced = str.Replace("big", "small");
            Console.WriteLine(replaced);

            //5.3.3
            Console.WriteLine("----5.3.3----");
            string[] words = str.Split(' ');
            Console.WriteLine(words.Length);

            //5.3.4
            Console.WriteLine("----5.3.4----");
            for (int i = 0; i < words.Length; i++) {
                if (words[i].Length <= 4) {
                    Console.WriteLine(words[i]);
                }
            }

            //5.3.5
            Console.WriteLine("----5.3.5----");
            var sb = new StringBuilder();
            foreach (var word in words) {
                sb.Append(word+" ");
            }
            var text = sb.ToString();
            Console.WriteLine(text);

            //5.4
            Console.WriteLine("----5.4----");
            string novel = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            string[] Array = novel.Split('=',';');
            for (int i = 0; i < Array.Length; i+=2) {

                Console.WriteLine(ToJapanese(Array[i])+Array[i+1]);
            }
            
        }
        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家　:";
                case "BestWork":
                    return "代表作:";
                case "Born":
                    return "誕生年:";
                default:
                    return "";
            }
        }
    }
}
