using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {
            //整数の例
            var numbers = new List<int> { 19, 17, 15, 24, 12, 25, 14, 20, 12, 28, 19, 30, 24 };

            var strings = numbers.Distinct().Select(n => n.ToString("0000")).ToArray();
            foreach (var str in strings) {
                Console.Write(str + " ");
            }


            numbers.Distinct().OrderBy(n => n).ToList().ForEach(n=> Console.WriteLine(n));

            Console.WriteLine();
            //文字列の例
            var words = new List<string> {
                "Microsoft","Apple","Google","Oracle","Facebook"
            };
            var lower = words.Select(name => name.ToLower()).ToArray();

            //オブジェクトの例
            var books = Books.GetBooks();

            //タイトルリスト
            var titles = books.Select(n => n.Title);
            foreach (var title in titles) {
                Console.Write(title +" ");
            }

            //ページ数の多い順に並べ替え（または金額の高い順）
            Console.WriteLine();
            books.OrderByDescending(n => n.Pages).ToList().ForEach(n => Console.WriteLine($"\n{n.Title} {n.Pages}ページ"));
            Console.WriteLine("\n----------------------");
            books.OrderByDescending(n => n.Price).ToList().ForEach(n => Console.WriteLine($"\n{n.Title} {n.Price}円"));

        }
    }
}
