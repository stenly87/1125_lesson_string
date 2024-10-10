using System.Text;

namespace _1125_lesson_string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            goto lesson101024;
            // лекция "Строки в C#"
            // string - хранение строк
            // string userString = Console.ReadLine();
            // тип ссылочный
            // значение в переменной типа string неизменяемое
            // поэтому код "hello" + ", " + "world" - создаст в памяти 5 строк
            string result = "hello" + ", " + "world" + "!"; // 7 строк в памяти, при этому указатель result указывает на последнюю
            // мусорные (промежуточные) строки из памяти удаляются
            // когда попадутся сборщику мусора (Garbage Collector)
            string h = "hello";
            string w = "world";
            result = $"{h}, {w}!"; // более предпочтительный вариант
            // $ перед строкой включает интерполяцию строк, это уменьшает кол-во промежуточных строк

            // если есть задача по сложению множества строк, есть
            // спец класс StringBuilder

            StringBuilder sb = new StringBuilder();
            sb.Append(h).Append("☺");
            sb.Append(w).Append("!");
            result = sb.ToString(); // сгенерируется сразу строка из 4 подстрок

            char ch = result[0]; // получить отдельный символ по индексу
            int count = result.Length;
            if (count > 50)
                ch = result[50];
            foreach (char c in result)
            {
                Console.WriteLine(c);
            }
            int test = (int)ch; // код символа по таблице UTF8

            // result[0] = 'a'; // не скомпилируется, поскольку строка
            // является неизменяемым объектом

            // все строки существуют в памяти в единственном экземпляре
            // это позволяет экономить память и ускорять создание переменных
            // с повторным значением строки

            // true
            // несмотря на то, что string - ссылочный тип, два объекта 
            // с одинаковым значением будут выдавать true при сравнении
            if ("hello" == "hello")
            {
                Console.WriteLine("строка hello");
            }
            object o1 = "hello";
            object o2 = "hello";
            // сравнение ссылочных типов идет по ссылке
            // тут два разных объекта, указывают на разный адрес
            // в памяти, поэтому результат false
            if (o1 == o2)
            {

            }
            // строку можно получить из любого объекта с помощью
            // метода ToString. Данный метод присутствует на любом
            // объекта любого класса
            // пример распаковки типа object - мы получим значение hello
            result = o1.ToString();

            result = (new Program()).ToString();

            Console.WriteLine(result);
            object i;
            i = 1;
            i = "string";
            result = (string)i;

            // извлечение подстроки (1 арг - начальный индекс, 2 арг - сколько извлекать)
            string result2 = result.Substring(2, 3);
            Console.WriteLine(result);
            Console.WriteLine(result2);

            result = null; // строка не имеет значения, методы через точку вызовут падение приложения
            result = ""; // пустая строка, значение есть, методы через точку работают
            result = new string('$', 10); // получится "$$$$$$$$$$"
            result += "\r\n \t"; // добавить символ перехода на новую строку
            // \t - таб
            result2 = result.Replace("str", "rts"); // замена подстрок str на подстроку rts
            result2 = result.ToLower(); // к нижнему регистру
            result2 = result.ToUpper(); // к верхнему регистру
            result2 = result.Trim(); // обрезка пробелов слева и справа
            result2 = result.TrimEnd(); // обрезка пробелов справа
            result2 = result.TrimStart(); // обрезка пробелов слева
            result2 = result.PadLeft(30); // увеличить строку до 30 символов пробелами слева
            result2 = result.PadRight(30); // увеличить строку до 30 символов пробелами справа
            result2 = result.Remove(0, 3); // удалить часть строки с 0 в кол-ве 3 символов
            result2 = new string( result.Reverse().ToArray()); // переворот строки задом на перед

            // Join - объединяет массив строк с помощью указанного разделителя - запятой
            result = string.Join('☺', ["hello", "cruel", "world"]);
            Console.WriteLine(result);
            // принудительный вызов сборщика мусора
            // он найдет и убьет всех сирот TT
            // сироты это объекты, на которые никто не ссылается
            GC.Collect();

            // оаип практикум
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            // 1 вариант (с циклом)
            string textNew = string.Empty;
            for (int q = 0; q < text.Length; q++)
            {
                if (text[q] == ' ')
                    textNew += ", ";
                else
                    textNew += text[q];
            }
            //text = textNew;
            Console.WriteLine(textNew);

            // 2 вариант замена подстрок
            text = text.Replace(" ", ", ");
            Console.WriteLine(text);

            // метод Split разбивает строку на подстроки
            string[] arrayStrings = result.Split();
            char[] chars = [',', ' ', '!'];

            result = "Hello, cruel world!!! Lesson is over";
            // разбитие строки на подстроки с помощью нескольких разделителей
            // при этом, пустые ячейки будут удалены
            string[] stringParts = result.Split(chars,
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in stringParts)
            {
                Console.WriteLine(str);
            }

            // форматирование строк
            lesson101024:

            string sample = $"{"че-нибудь другое"} {11} {true}";
            // форматирование с аргументами, аргументы подставляются
            // согласно их индексам вместо {n}
            sample = string.Format("123 {0} {0} {1}", 10, 20);
            Console.WriteLine(sample);
            // двоичное представление числа
            sample = 123.ToString("b");
            Console.WriteLine(sample);

            // 16-ричное представление числа (x - в нижнем регистре, X - в верхем регистре)
            sample = 123111.ToString("x");
            Console.WriteLine(sample);
            // можно использовать форматирование в скобках при
            // выводе аргумента
            sample = string.Format("123 {0:b}", 1024);
            Console.WriteLine(sample);

            // можно округлить дробь (сократить остаток после
            // запятой, указав формат 
            sample = 123.111.ToString("N2");
            Console.WriteLine(sample);

            // аналог через string.Format (сокращение остатка)
            sample = string.Format("{0:N2}", 10000000024.5555);
            Console.WriteLine(sample);

            // добавляется символ рубля ₽
            // в консолях видимо не работает
            sample = string.Format("{0:c}", 10024.55);
            Console.WriteLine(sample);
            // тоже самое через ToString
            Console.WriteLine(123.ToString("c"));

            // представление процентов через ToString
            Console.WriteLine(0.15.ToString("p"));

            // представление дроби с основанием e через ToString
            Console.WriteLine(Math.Cos(Math.E).ToString("e"));

            // работа с временем
            // есть типы данных: DateTime, DateOnly, TimeOnly
            // текущее время в локальном часовом поясе
            DateTime time = DateTime.Now;
            Console.WriteLine(time.ToString());
            // текущее время в универсальном часовом поясе 
            // Владивосток = UTC+10
            time = DateTime.UtcNow;
            Console.WriteLine(time.ToString());
            // на типе DateTime доступен ряд методов для изменения даты
            // при этом методы возвращают новое значение, не изменяя старое
            time = time.AddHours(10);
            Console.WriteLine(time.ToString());

            // сохранить дату и время в число (8 байт)
            long l = time.ToBinary();
            // получить дату из числа
            time = DateTime.FromBinary(l);

            // при форматировании даты в виде строки можно использовать
            // множество аргументов для видоизменения результата
            // варианты можно посмотреть в подсказке
            Console.WriteLine(time.ToString("dd.MM.yyyy zzz"));
            // даты можно вычитать друг из друга
            // в результате получаем TimeSpan - промежуток, он может включать
            // любые значения времени, в т.ч. отрицательные
            TimeSpan span = time.Subtract(DateTime.UtcNow);            
            Console.WriteLine(span.TotalSeconds);

            // даты можно сравнивать
            // CompareTo возвращает число
            // отрицательное значит что time раньше чем DateTime.UtcNow
            // положительное значит что DateTime.UtcNow раньше чем time
            // 0 значит что DateTime.UtcNow равно time
            int compare = time.CompareTo(DateTime.UtcNow);
            Console.WriteLine(compare);
        }
    }
}
