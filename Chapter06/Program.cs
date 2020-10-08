using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, -5, 4, 2, 5, 4, 2, -4, -1, 6, 4 };
            Console.WriteLine($"平均値:{numbers.Average()}");
            Console.WriteLine($"合計:{numbers.Sum()}");
            Console.WriteLine($"最小値:{numbers.Where(n=>n>0).Min()}");
            Console.WriteLine($"最大値:{numbers.Max()}");

            bool exists = numbers.Any(n => n % 7 == 0);

            var results = numbers.Where(n => n > 0).Take(3);

            foreach (var result in results) {
                Console.Write(result + " ");
            }
            Console.WriteLine();
            var books = Books.GetBooks();
            Console.WriteLine($"本の平均価格:{books.Average(x=> x.Price):f0}円");
            Console.WriteLine($"本の合計価格:{books.Sum(x=> x.Price)}円");
            Console.WriteLine($"本のページが最大:{books.Max(x => x.Pages)}P");
            Console.WriteLine($"高価な本:{books.Max(x => x.Price)}円");
            Console.WriteLine($"タイトルに「物語」がある冊数:{books.Count(x=>x.Title.Contains("物語"))}冊");

            //600ページを超える書籍があるか？(Any)
            Console.WriteLine(books.Any(n=>n.Pages > 600) ? "存在する" : "存在しない");
            //すべてが200ページ以上の書籍か？(All)
            Console.WriteLine(books.All(n=>n.Pages >= 200) ? "yes":"no");
            //400ページを超える本は何冊目か？
            var number = books.FirstOrDefault(n=>n.Pages > 400);
            Console.WriteLine($"{books.IndexOf(number)+1}冊目");

            //本の値段が400円以上のものを3冊表示
            books.Where(n => n.Price >= 400).Take(3).ToList().ForEach(n => Console.WriteLine(n.Title));
            
        }
    }
}
