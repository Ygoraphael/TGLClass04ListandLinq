using System;
using System.Collections.Generic;
using System.Linq;

namespace Class4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Moneyold m1 = new Moneyold((decimal)1.25M, "USD");
            Moneyold m2 = new Moneyold((decimal)3, "USD");

            Moneyold m3 = m1 + m2;*/

            Money m1 = new Money((decimal)2.25M, "USD");
            m1["EUR"] = 1;

            Console.WriteLine(m1["USD"]);

            List<Money> list1 = new List<Money>();
            list1.Add(new Money(1, "USD"));
            list1.Add(new Money(2, "USD"));

            var a = list1.Where(l => l["USD"] == 1.00M).ToList();

            var b = from l in list1 where l["USD"] == 1.00M select l;




            /*
            TestParams(1, "test");
            TestParams(1, "test", "a", "b", "c");

            string[] s = new[] { "a", "b", "c" };
            TestParams(1, "test", s );


            ArrayList al = new ArrayList();
            al.Add(m1);
            var v = (al[0] as Moneyold).Value;


            var l = new List<Moneyold>();
            l.Add(m1);
            var v2 = (l.[0] as Moneyold).Value;*/



            List<string> list = new List<string>
            {
                "Marc",
                "Bob",
                "Ana",
                "Lara",
                "Joe",
                "Ariel"
            };
            list.Insert(2, "Karl");

            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("---------------------");
            string s1 = list.Find(match: x => x[0] == 'A');
            Console.WriteLine("First 'A': " + s1);
            string s2 = list.FindLast(match: x => x[0] == 'A');
            Console.WriteLine("Last 'A': " + s2);
            int pos1 = list.FindIndex(x => x[0] == 'A');
            Console.WriteLine("First position 'A': " + pos1);
            int pos2 = list.FindLastIndex(x => x[0] == 'A');
            Console.WriteLine("Last position 'A': " + pos2);
            List<string> list2 = list.FindAll(x => x.Length == 5);
            Console.WriteLine("---------------------");

            foreach (string obj in list2)
            {
                Console.WriteLine(obj);
            }
            list.RemoveAt(1);
            Console.WriteLine("---------------------");

            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }
            list.Remove("Ana");
            Console.WriteLine("---------------------");

            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }
            list.RemoveAll(x => x[0] == 'M');
            Console.WriteLine("---------------------");

            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }
            list.RemoveRange(1, 3);
            Console.WriteLine("---------------------");

            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }


        }

        public static void TestParams(int i, string s, params string[] args)
        {
            Console.WriteLine(i);
            Console.WriteLine(s);

            foreach (var a in args)
            {
                Console.WriteLine(a);
            }
        }

        public class Money
        {
            public Dictionary<string, decimal> _values = new Dictionary<string, decimal>();

            public Money(decimal value, string currencycode)
            {
                _values.Add(currencycode, value);
            }

            public decimal this[string index]
            {
                get { return _values[index]; }
                set { _values[index] = value; }
            }
        }


        public class Moneyold
        {
            public decimal Value { get; private set; }
            public string CurrencyCode { get; }

            public Moneyold(Decimal value, string currencycode)
            {
                Value = value;
                CurrencyCode = currencycode;
            }
            public static Moneyold operator +(Moneyold m1, Moneyold m2)
            {
                if (m1.CurrencyCode != m2.CurrencyCode)
                {
                    throw new ArgumentException("Currency code are not equal.");
                }
                return new Moneyold(m1.Value + m2.Value, m1.CurrencyCode);
            }

            public void Add(Moneyold m)
            {
                if (this.CurrencyCode != m.CurrencyCode)
                {
                    throw new ArgumentException("Currency code are not equal.");
                }
                this.Value += m.Value;
            }
        }

    }
}
