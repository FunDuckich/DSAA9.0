using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace DSAA9._0
{
    public class Tasks
    {
        #region Пр2, II 1

        public static void Pr2Ii1()
        {
            Console.Write("Введите число: ");
            double num = double.Parse(Console.ReadLine());
            Console.Write(num % 2 == 0 ? "Число чётное" : "Число нечётное");
        }

        #endregion

        #region Пр3, IV 1

        public static void Pr3Iv1()
        {
            Console.Write("Введите число A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число B >= A: ");
            int b = int.Parse(Console.ReadLine());

            // Именно цикл for, т.к. с ним проще работать при известных границах
            for (int num = b; num >= a; num--)
            {
                Console.Write(num * num + " ");
            }
        }

        #endregion

        #region Пр5, II 8

        private static int AmountOfOddDigits(int n)
        {
            int num = n;
            int res = 0;
            while (num > 0)
            {
                res += (num % 10) % 2 != 0 ? 1 : 0;
                num /= 10;
            }

            return res;
        }

        public static void Pr5Ii8A()
        {
            Console.Write("Введите число A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b = int.Parse(Console.ReadLine());

            for (int num = a; num <= b; num++)
            {
                Console.WriteLine($"{num} - {AmountOfOddDigits(num)}");
            }
        }

        public static void Pr5Ii8B()
        {
            Console.Write("Введите число A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b = int.Parse(Console.ReadLine());

            for (int num = a % 2 == 0 ? a : a + 1; num <= b; num += 2)
            {
                if (AmountOfOddDigits(num) == 0)
                {
                    Console.Write(num + " ");
                }
            }
        }

        public static void Pr5Ii8C()
        {
            Console.Write("Введите число A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b = int.Parse(Console.ReadLine());

            int[] ans = new int[(b - a + 2) / 2];
            int idx = 0;
            int maxAmountOfOddDigits = int.MinValue;
            for (int i = a % 2 != 0 ? a : a + 1; i <= b; i += 2)
            {
                int currentAmount = AmountOfOddDigits(i);

                if (currentAmount > maxAmountOfOddDigits)
                {
                    maxAmountOfOddDigits = currentAmount;
                    idx = 0;
                }

                if (currentAmount == maxAmountOfOddDigits)
                {
                    ans[idx] = i;
                    idx++;
                }
            }

            for (int i = 0; i < idx; i++)
            {
                Console.Write(ans[i] + " ");
            }
        }

        public static void Pr5Ii8D()
        {
            Console.Write("Введите число A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b = int.Parse(Console.ReadLine());
            int number = a;
            int amountOfDigits = 0;

            while (number > 0)
            {
                number /= 10;
                amountOfDigits++;
            }

            if (amountOfDigits >= b)
            {
                while (true)
                {
                    a++;
                    if (AmountOfOddDigits(a) == b)
                    {
                        Console.WriteLine(a);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < b; i++)
                {
                    Console.Write(1);
                }
            }
        }

        #endregion

        #region Пр5, III 7

        public static void Pr5Iii7()
        {
            double SmthInteresting(double x, int n)
            {
                if (n == 0)
                {
                    return 1;
                }

                if (n < 0)
                {
                    return 1 / SmthInteresting(x, Math.Abs(n));
                }

                return x * SmthInteresting(x, n - 1);
            }

            Console.Write("Введите вещественное число x: ");
            double xX = double.Parse(Console.ReadLine());
            Console.Write("Введите целое число n: ");
            int nN = int.Parse(Console.ReadLine());

            Console.WriteLine(SmthInteresting(xX, nN));
        }

        #endregion

        #region Пр5, IV 7

        public static void Pr5Iv7()
        {
            void NumberReverser(int num)
            {
                int ost = num % 10;
                int obr = num / 10;
                Console.Write(ost);
                if (obr > 0)
                {
                    NumberReverser(obr);
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.Write("Введите число A: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число B: ");
            int b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                NumberReverser(i);
            }
        }

        #endregion

        #region Пр7, IV 1

        public static void Pr7Iv1()
        {
            Console.Write("Введите целое число n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            int[] ans = new int[n];
            Console.WriteLine("Введите массив из целых чисел, разделённый пробелами, рамером n, n:");
            for (int i = 0; i < n; i++)
            {
                string[] stroke = Console.ReadLine().Split();
                ans[i] = int.MinValue;

                for (int j = 0; j < n; j++)
                {
                    int num = int.Parse(stroke[j]);
                    ans[i] = num > ans[i] ? num : ans[i];
                }
            }

            foreach (int val in ans)
            {
                Console.Write(val);
                Console.Write(" ");
            }
        }

        #endregion

        #region Пр7, VI 6

        public static void Pr7Vi6()
        {
            Console.Write("Введите целое число n: ");
            int n = int.Parse(Console.ReadLine());
            int m = n;
            Console.WriteLine("");
            Console.WriteLine("Введите массив из целых чисел, разделённый пробелами, рамером n, n:");
            int[][] massive = new int[n][];
            HashSet<int> strokesForDeleting = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                massive[i] = new int[m];
                bool noEvenInStoke = true;
                string[] stroke = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    massive[i][j] = int.Parse(stroke[j]);
                    if (massive[i][j] % 2 == 0)
                    {
                        noEvenInStoke = false;
                    }
                }

                if (noEvenInStoke)
                {
                    strokesForDeleting.Add(i);
                }
            }

            foreach (int stokeForDeleting in strokesForDeleting)
            {
                for (int i = stokeForDeleting; i < n - 1; i++)
                {
                    massive[i] = massive[i + 1];
                }

                n--;
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                foreach (int num in massive[i])
                {
                    Console.Write(num + " ");
                }

                Console.WriteLine();
            }
        }

        #endregion

        #region Пр8, III 1

        public static void Pr8Iii1()
        {
            char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\t', '\r' };
            Console.Write("Введите строку: ");
            string[] words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Введите подстроку: ");
            string substring = Console.ReadLine();

            StringBuilder ans = new StringBuilder();
            foreach (string word in words)
            {
                if (word.Contains(substring))
                {
                    ans.Append(word);
                    ans.Append(' ');
                }
            }

            Console.WriteLine(ans);
        }

        #endregion

        #region Пр9, II 1

        public static void Pr9Ii1()
        {
            using (StreamReader inFile = new StreamReader(@"C:\Users\petro\RiderProjects\DSAA\DSAA\f.txt"))
            {
                using (StreamWriter outGFile = new StreamWriter(@"C:\Users\petro\RiderProjects\DSAA\DSAA\g.txt", false))
                {
                    using (StreamWriter outHFile =
                           new StreamWriter(@"C:\Users\petro\RiderProjects\DSAA\DSAA\h.txt", false))
                    {
                        string line;
                        while ((line = inFile.ReadLine()) != null)
                        {
                            foreach (Match match in Regex.Matches(line, @"-?\d+"))
                            {
                                int num = int.Parse(match.Value);
                                if (num % 2 == 0)
                                {
                                    outGFile.WriteLine(num);
                                }
                                else
                                {
                                    outHFile.WriteLine(num);
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Пр14, I 1

        private readonly struct SPoint
        {
            private readonly int _x, _y;
            private readonly double _distance;

            public SPoint(int x, int y)
            {
                this._x = x;
                this._y = y;
                this._distance = Math.Sqrt(_x * _x + _y * _y);
            }

            public double GetDistance()
            {
                return _distance;
            }

            public override string ToString()
            {
                return "(" + _x + ", " + _y + ")";
            }
        }

        public static void Pr14I1()
        {
            using (StreamReader inp = new StreamReader(@"C:\Users\petro\RiderProjects\DSAA\DSAA\Pr14I1(in).txt"))
            {
                string line;
                ArrayList points = new ArrayList();
                char[] seps = new[] { ' ', '\n', '\t', '\r' };
                while ((line = inp.ReadLine()) != null)
                {
                    string[] split = line.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                    points.Add(new SPoint(int.Parse(split[0]), int.Parse(split[1])));
                }

                ArrayList answ = new ArrayList();
                double maxDistance = double.MinValue;
                foreach (SPoint point in points)
                {
                    if (point.GetDistance() > maxDistance)
                    {
                        answ.Clear();
                        maxDistance = point.GetDistance();
                        answ.Add(point);
                    }
                    else if (point.GetDistance().Equals(maxDistance))
                    {
                        answ.Add(point);
                    }
                }

                foreach (SPoint point in answ)
                {
                    Console.WriteLine(point);
                }
            }
        }

        #endregion

        #region Пр14, II 1

        private readonly struct Student : IComparable<Student>
        {
            private readonly string _fullName;
            private readonly DateTime _birthDay;
            private readonly string _address;
            private readonly string _school;

            public Student(string fullName, DateTime birthDay, string address, string school)
            {
                this._fullName = fullName;
                this._birthDay = birthDay;
                this._address = address;
                this._school = school;
            }

            public DateTime GetBirthDay()
            {
                return _birthDay;
            }

            public string GetSchool()
            {
                return _school;
            }

            public int CompareTo(Student other)
            {
                return DateTime.Compare(this._birthDay, other.GetBirthDay());
            }

            public override string ToString()
            {
                return _fullName + ", окончивший школу " + _school + ", родился " + _birthDay.Date.Day + "." +
                       (_birthDay.Date.Month < 10 ? ("0" + _birthDay.Date.Month) : _birthDay.Date.Month.ToString()) +
                       "." + _birthDay.Date.Year +
                       ", проживает по адресу: " + _address;
            }
        }

        public static void Pr14Ii1()
        {
            using (StreamReader inF = new StreamReader(@"C:\Users\petro\RiderProjects\DSAA\DSAA\Pr14Ii1(in).txt"))
            {
                using (StreamWriter outFw =
                       new StreamWriter(@"C:\Users\petro\RiderProjects\DSAA\DSAA\Pr14Ii1(out).txt"))
                {
                    ArrayList students = new ArrayList();
                    string line;
                    while ((line = inF.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        string[] date = data[1].Trim().Split('.');
                        DateTime currentBirthDay =
                            new DateTime(int.Parse(date[2].Trim()), int.Parse(date[1].Trim()),
                                int.Parse(date[0].Trim()));
                        students.Add(new Student(data[0].Trim(), currentBirthDay, data[2].Trim(), data[3].Trim()));
                    }

                    Console.Write("Введите школу: ");
                    string inSchool = Console.ReadLine();
                    List<Student> inCurrentSchool = new List<Student>();
                    foreach (Student student in students)
                    {
                        if (student.GetSchool().Equals(inSchool))
                        {
                            inCurrentSchool.Add(student);
                        }
                    }

                    inCurrentSchool.Sort();
                    foreach (Student student in inCurrentSchool)
                    {
                        outFw.WriteLine(student);
                    }
                }
            }
        }

        #endregion

        #region Пр15, I 11 и 12

        public static void Pr15I11And12()
        {
            using (StreamReader inF = new StreamReader(@"C:\Users\petro\RiderProjects\DSAA\DSAA\Pr15I11(in).txt"))
            {
                using (StreamWriter outF =
                       new StreamWriter(@"C:\Users\petro\RiderProjects\DSAA\DSAA\Pr15I11(out).txt", false))
                {
                    List<int> nums = new List<int>();
                    string line;
                    while ((line = inF.ReadLine()) != null)
                    {
                        nums.Add(int.Parse(line));
                    }

                    var invertedPositivesLinq =
                        from num in nums
                        where num > 0 && (int)Math.Log10(num) + 1 == 2
                        select -num;

                    var invertedNegativesMethods =
                        nums.Where(num => num < 0 && (int)Math.Log10(-num) + 1 == 3).Select(num => -num);

                    outF.WriteLine("Linq");
                    foreach (var item in invertedPositivesLinq)
                    {
                        outF.WriteLine(item);
                    }

                    outF.WriteLine("\nMethods");
                    foreach (var item in invertedNegativesMethods)
                    {
                        outF.WriteLine(item);
                    }
                }
            }
        }

        #endregion

        #region Пр15, II 11 и 12

        private readonly struct InventoryProduct
        {
            private readonly string _type;
            private readonly int _cost;
            private readonly string _sort;
            private readonly int _count;

            public InventoryProduct(string type, int cost, string sort, int count)
            {
                this._type = type;
                this._cost = cost;
                this._sort = sort;
                this._count = count;
            }

            public int GetCount()
            {
                return _count;
            }

            public string GetItemType()
            {
                return _type;
            }

            public override string ToString()
            {
                return _type + " " + _sort + " по цене " + _cost + " находится на складе в количестве " + _count +
                       " штук";
            }
        }

        public static void Pr15Ii11And12()
        {
            using (StreamReader inF = new StreamReader(@"C:\Users\petro\RiderProjects\DSAA\DSAA\Pr15Ii11(in).txt"))
            {
                using (StreamWriter outF =
                       new StreamWriter(@"C:\Users\petro\RiderProjects\DSAA\DSAA\Pr15Ii11(out).txt", false))
                {
                    List<InventoryProduct> warehouseItems = new List<InventoryProduct>();
                    string line;
                    while ((line = inF.ReadLine()) != null)
                    {
                        string[] itemData = line.Split(' ');
                        InventoryProduct item = new InventoryProduct(itemData[0], int.Parse(itemData[1]), itemData[2],
                            int.Parse(itemData[3]));
                        warehouseItems.Add(item);
                    }

                    Console.Write("Введите границу кол-ва товара: ");
                    int borderCount = int.Parse(Console.ReadLine());

                    var filteredItemsLinq =
                        from item in warehouseItems
                        where item.GetCount() < borderCount
                        orderby item.GetCount()
                        select item;

                    var filteredItemsMethods =
                        warehouseItems.Where(item => item.GetCount() > borderCount).OrderBy(item => item.GetItemType());

                    outF.WriteLine("Linq");
                    foreach (var item in filteredItemsLinq)
                    {
                        outF.WriteLine(item);
                    }

                    outF.WriteLine("\nMethods");
                    foreach (var item in filteredItemsMethods)
                    {
                        outF.WriteLine(item);
                    }
                }
            }
        }

        #endregion


        #region Пр17, 10

        private class DateOperator
        {
            private DateTime _date;

            public DateOperator()
            {
                this._date = DateTime.Today;
            }

            public DateOperator(int day, int month, int year)
            {
                this._date = new DateTime(year, month, day);
            }

            public DateOperator(DateOperator other)
            {
                this._date = other.Date;
            }

            public DateTime Date
            {
                get => _date;
                set => this._date = value;
            }

            public bool IsYearBissextile => DateTime.IsLeapYear(_date.Year);

            public DateTime PreviousDate => _date.AddDays(-1);

            public DateTime NextDate => _date.AddDays(1);

            public int DaysUntilNextMonth => DateTime.DaysInMonth(_date.Year, _date.Month) - _date.Day;

            public DateTime this[int dayShift] => _date.AddDays(dayShift);

            public static bool operator !(DateOperator thisDate)
            {
                return DateTime.DaysInMonth(thisDate.Date.Year, thisDate.Date.Month) != thisDate.Date.Day;
            }

            public static bool operator true(DateOperator thisDate)
            {
                return thisDate.Date.DayOfYear == 1;
            }

            public static bool operator false(DateOperator thisDate)
            {
                return thisDate.Date.DayOfYear != 1;
            }

            public static bool operator &(DateOperator thisDate, DateOperator otherDate)
            {
                return thisDate.Equals(otherDate);
            }

            public override string ToString()
            {
                return _date.ToShortDateString();
            }

            public override int GetHashCode()
            {
                return _date.Day.GetHashCode() + _date.Month.GetHashCode() + _date.Year.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                {
                    return false;
                }

                if (this == obj)
                {
                    return true;
                }

                if (obj is DateOperator other)
                {
                    return _date.Equals(other.Date);
                }

                return false;
            }
        }

        public static void Pr1710()
        {
            using (StreamReader inF = new StreamReader(@"C:\Users\petro\RiderProjects\DSAA9.0\DSAA9.0\Pr1710(in).txt"))
            {
                using (StreamWriter outF =
                       new StreamWriter(@"C:\Users\petro\RiderProjects\DSAA9.0\DSAA9.0\Pr1710(out).txt", false))
                {
                    List<DateOperator> dates = new List<DateOperator>();
                    string line;
                    while ((line = inF.ReadLine()) != null)
                    {
                        string[] data = line.Split('.');
                        dates.Add(new DateOperator(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2])));
                    }

                    DateOperator copy = new DateOperator(dates[0]);
                    outF.WriteLine(copy + " - копия " + dates[0]);
                    outF.WriteLine("Хэш " + dates[0] + " - " + dates[0].GetHashCode());
                    outF.WriteLine("Хэш " + copy + " - " + copy.GetHashCode());
                    outF.WriteLine("Результат Equals между ними: " + copy.Equals(dates[0]));
                    DateOperator today = new DateOperator();
                    outF.WriteLine("Сегодня - " + today + ", вчера - " + today.PreviousDate + ", завтра - " +
                                   today.NextDate);
                    outF.WriteLine("До начала следующего месяца осталось дней: " + today.DaysUntilNextMonth);
                    outF.WriteLine("Этот год " + (today.IsYearBissextile ? "високосный" : "не високосный"));
                    outF.WriteLine(today[0] + " - можно вывести ещё и с помощью индексации");
                    outF.WriteLine(today[-7] + " - семь дней назад, с помощью индексации");
                    foreach (DateOperator date in dates)
                    {
                        outF.WriteLine();
                        outF.WriteLine(date + " - " + (!date ? "не последний день месяца" : "последний день месяца"));
                        outF.WriteLine(date + " - " + (date ? "начало года" : "не начало года"));
                    }

                    outF.WriteLine();

                    for (int i = 0; i < dates.Count - 1; i++)
                    {
                        for (int j = i + 1; j < dates.Count; j++)
                        {
                            if (dates[i] & dates[j])
                            {
                                outF.WriteLine(dates[i] + " и " + dates[j] + " - одинаковые даты");
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Пр 18, 19 (9)

        private class Borrower
        {
            public DateTime LoanTakingDate { get; private set; }
            public DateTime Deadline { get; private set; }
            public double LoanSize { get; private set; }
            public double InterestPerDay => 0.08;

            public double RemainingDept { get; private set; }

            public double RemainingDeptIfDeadlineExpired { get; private set; }

            public bool DeadlineExpired => DateTime.Today.Day > Deadline.Day;

            public Borrower(double loanSize, int forDays)
            {
                if (loanSize <= 0)
                {
                    throw new ArgumentOutOfRangeException("Вы не можете занять такую сумму!");
                }

                if (forDays <= 0)
                {
                    throw new ArgumentOutOfRangeException("Вы не можете взять в долг на такой период времени!");
                }

                LoanTakingDate = DateTime.Today;
                Deadline = LoanTakingDate.AddDays(forDays);
                LoanSize = loanSize;
                RemainingDept = LoanSize *
                                (1 + forDays * InterestPerDay);
                RemainingDeptIfDeadlineExpired = RemainingDept * 2;
            }
        }

        private class Investor
        {
            public DateTime DepositOpeningDate { get; private set; }
            private DateTime WillRecieveAt { get; set; }
            public double DepositSize { get; private set; }
            public double InterestPerYear => 10;
            public double AmountCanRecieve { get; private set; }
            public bool CanRecieveWithoutMissings => DateTime.Today >= WillRecieveAt;

            public Investor(double depositSize, int forDays)
            {
                if (depositSize <= 0)
                {
                    throw new ArgumentOutOfRangeException("Вы не можете открыть вклад с такой суммой!");
                }

                if (forDays <= 0)
                {
                    throw new ArgumentOutOfRangeException("Вы не можете открыть вклад на такой период времени!");
                }

                DepositOpeningDate = DateTime.Today;
                WillRecieveAt = DepositOpeningDate.AddDays(forDays);
                DepositSize = depositSize;
                AmountCanRecieve = DepositSize *
                                   (1 + forDays * InterestPerYear /
                                       (DateTime.IsLeapYear(DepositOpeningDate.Year) ? 366 : 365));
            }
        }

        private abstract class Client : IComparable<Client>
        {
            public string Name { get; private set; }
            public double Balance { get; protected set; }
            public DateTime AccountOpeningDate { get; }
            public long AccountId { get; private set; }

            private Borrower? _asBorrower;

            public Borrower? AsBorrower
            {
                get => _asBorrower ?? throw new InvalidOperationException("Клиент не занимал денег у банка!");
                protected set
                {
                    if (value != null)
                    {
                        throw new InvalidOperationException("Клиент уже занял денег у банка!");
                    }

                    _asBorrower = value;
                }
            }

            private Investor? _asInvestor;

            public Investor? AsInvestor
            {
                get => _asInvestor ?? throw new InvalidOperationException("Клиент не открывал вклад!");
                protected set
                {
                    if (value != null)
                    {
                        throw new InvalidOperationException("Клиент уже открыл вклад!");
                    }

                    _asInvestor = value;
                }
            }

            protected Client(string name)
            {
                AccountOpeningDate = DateTime.Today;
                Name = name;
                AccountId = Random.Shared.NextInt64();
            }

            public abstract void TopUp(double amount);

            public abstract void Withdraw(double amount);

            public abstract void UpdateIncome(double newIncome);

            public abstract void TakeLoan(double amount, int forDays);

            public void CloseLoan()
            {
                if (AsBorrower == null)
                {
                    throw new InvalidOperationException("У клиента нет никаких займов!");
                }

                double mustReturn = AsBorrower.DeadlineExpired
                    ? AsBorrower.RemainingDeptIfDeadlineExpired
                    : AsBorrower.RemainingDept;

                if (Balance - mustReturn < 0)
                {
                    throw new InvalidOperationException("Недостаточно средств на балансе для погашения займа!");
                }

                Balance -= mustReturn;
                AsBorrower = null;
            }

            public abstract void OpenDeposit(double amount, int forDays);

            public void CloseDeposit()
            {
                if (AsInvestor == null)
                {
                    throw new InvalidOperationException("У клиента нет открытого вклада!");
                }

                double willRecieve = AsInvestor.CanRecieveWithoutMissings
                    ? AsInvestor.AmountCanRecieve
                    : AsInvestor.DepositSize *
                      (1 + (DateTime.Today - AsInvestor.DepositOpeningDate).Days * (AsInvestor.InterestPerYear / 2) /
                          (DateTime.IsLeapYear(AsInvestor.DepositOpeningDate.Year) ? 366 : 365));

                Balance += willRecieve;
                AsInvestor = null;
            }

            public string GetInvestorStatus()
            {
                try
                {
                    return AsInvestor != null ? "инвестор" : "лови ошибку";
                }
                catch (Exception e)
                {
                    return "не инвестор";
                }
            }

            public string GetBorrowerStatus()
            {
                try
                {
                    return AsBorrower != null ? "заёмщик" : "лови ошибку";
                }
                catch (Exception e)
                {
                    return "не заёмщик";
                }
            }
            
            public override int GetHashCode()
            {
                return AccountId.GetHashCode();
            }

            public int CompareTo(Client other)
            {
                return AccountOpeningDate.CompareTo(other.AccountOpeningDate);
            }
        }

        private class Individual : Client
        {
            private double _income;
            private const double OneTimeWithdrawLimitMultiplyer = 6;
            private const double LoanLimitMultiplyer = 3;

            private double Income
            {
                get => _income;
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Доход не может быть отрицательным!");
                    }

                    _income = value;
                }
            }

            public double OneTimeWithdrawLimit { get; private set; } = 500000.00;
            public double LoanLimit { get; private set; } = 150000.00;

            public Individual(string name, double income) : base(name)
            {
                UpdateIncome(income);
            }

            public override void TopUp(double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException("Вы не можете пополнить баланс на такую сумму!");
                }

                Balance += amount;
            }

            public override void Withdraw(double amount)
            {
                if (amount > OneTimeWithdrawLimit)
                {
                    throw new InvalidOperationException("Превышен лимит физ. лица на единоразовый вывод средств!");
                }

                if (Balance - amount < 0)
                {
                    throw new InvalidOperationException("Недостаточно средств на балансе для вывода!");
                }

                Balance -= amount;
            }

            public override void TakeLoan(double amount, int forDays)
            {
                if (amount > LoanLimit)
                {
                    throw new InvalidOperationException("Вы не можете взять займ на такую сумму!");
                }

                AsBorrower = new Borrower(amount, forDays);
            }

            public override void OpenDeposit(double amount, int forDays)
            {
                if (amount > LoanLimit)
                {
                    throw new InvalidOperationException("Вы не можете взять займ на такую сумму!");
                }

                AsBorrower = new Borrower(amount, forDays);
            }

            public void RegisterNewIncome(double amount)
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException("Вы не можете зарегистрировать такой доход!");
                }

                TopUp(amount);
            }

            public sealed override void UpdateIncome(double newIncome)
            {
                Income = newIncome;
                OneTimeWithdrawLimit = Income * OneTimeWithdrawLimit > OneTimeWithdrawLimit
                    ? OneTimeWithdrawLimit
                    : Income * OneTimeWithdrawLimitMultiplyer;
                LoanLimit = Income * LoanLimitMultiplyer > LoanLimit ? LoanLimit : Income * LoanLimitMultiplyer;
            }

            public override bool Equals(object? obj)
            {
                if (obj == null)
                {
                    return false;
                }

                if (obj is not Individual)
                {
                    return false;
                }

                if (this == obj)
                {
                    return true;
                }

                Individual other = (Individual)obj;

                return AccountId.Equals(other.AccountId);
            }

            public override string ToString()
            {
                return "id: " + AccountId + "\nсоздал аккаунт " + AccountOpeningDate.ToShortDateString() + "\nимя: " +
                       Name + "\nбаланс: " + Balance + "\nстатусы: " + GetInvestorStatus() + ", " + GetBorrowerStatus();
            }
        }

        private class LegalEntity : Client
        {
            private double _income;
            private const double OneTimeWithdrawLimitMultiplyer = 12;
            private const double LoanLimitMultiplyer = 6;
            private List<Individual> employeers = new List<Individual>();

            private double Income
            {
                get => _income;
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Доход не может быть отрицательным!");
                    }

                    _income = value;
                }
            }

            public double OneTimeWithdrawLimit { get; private set; } = 5000000.00;
            public double LoanLimit { get; private set; } = 1000000.00;

            public LegalEntity(string name, double income) : base(name)
            {
                UpdateIncome(income);
            }

            public override void TopUp(double amount)
            {
                Balance += amount;
            }

            public override void Withdraw(double amount)
            {
                if (amount > OneTimeWithdrawLimit)
                {
                    throw new InvalidOperationException("Превышен лимит физ. лица на единоразовый вывод средств!");
                }

                if (Balance - amount < 0)
                {
                    throw new InvalidOperationException("Недостаточно средств на балансе для вывода!");
                }

                Balance -= amount;
            }

            public override void TakeLoan(double amount, int forDays)
            {
                if (amount > LoanLimit)
                {
                    throw new InvalidOperationException("Вы не можете взять займ на такую сумму!");
                }

                AsBorrower = new Borrower(amount, forDays);
            }

            public override void OpenDeposit(double amount, int forDays)
            {
                if (amount > LoanLimit)
                {
                    throw new InvalidOperationException("Вы не можете взять займ на такую сумму!");
                }

                AsBorrower = new Borrower(amount, forDays);
            }

            public sealed override void UpdateIncome(double newIncome)
            {
                Income = newIncome;
                OneTimeWithdrawLimit = Income * OneTimeWithdrawLimit > OneTimeWithdrawLimit
                    ? OneTimeWithdrawLimit
                    : Income * OneTimeWithdrawLimitMultiplyer;
                LoanLimit = Income * LoanLimitMultiplyer > LoanLimit ? LoanLimit : Income * LoanLimitMultiplyer;
            }

            public void AddNewEmployeer(Individual employeer)
            {
                employeers.Add(employeer);
            }

            public void PayForWork(double amountForEach)
            {
                if (Balance - amountForEach * employeers.Count < 0)
                {
                    throw new InvalidOperationException("Недостаточно средств на балансе, чтобы заплатить столько!");
                }

                foreach (Individual employeer in employeers)
                {
                    employeer.RegisterNewIncome(amountForEach);
                }
            }

            public override bool Equals(object? obj)
            {
                if (obj == null)
                {
                    return false;
                }

                if (obj is not LegalEntity)
                {
                    return false;
                }

                if (this == obj)
                {
                    return true;
                }

                LegalEntity other = (LegalEntity)obj;

                return AccountId.Equals(other.AccountId);
            }

            public override string ToString()
            {
                return "id: " + AccountId + "\nсоздал аккаунт " + AccountOpeningDate.ToShortDateString() +
                       "\nнаименование: " +
                       Name + "\nбаланс: " + Balance + "\nстатусы: " + GetInvestorStatus() + ", " +
                       GetBorrowerStatus() + "\nкол-во наёмных работников: " + employeers.Count;
            }
        }

        public static void Pr1819Ix()
        {
            Individual smbd = new Individual("Егор", 30000);
            Console.WriteLine(smbd);
            LegalEntity comp = new LegalEntity("АО Умный Ретейл", 5000000);
            comp.AddNewEmployeer(smbd);
            comp.TopUp(5000);
            comp.PayForWork(50);
            Console.WriteLine();
            Console.WriteLine(smbd);
        }

        #endregion

        #region Пр 6.2, II 4

        public static void Pr6Point2Ii4Straight()
        {
            string GetStroke()
            {
                Random rnd = new Random(666);
                StringBuilder s = new StringBuilder(100009);
                while (s.Length < 100000)
                {
                    s.Append(rnd.Next(100000000, 999999999).ToString());
                }

                s.Remove(100000, s.Length - 100000);
                return s.ToString();
            }
        }

        public static void Pr6Point2Ii4Hash()
        {
            string GetStroke()
            {
                Random rnd = new Random(666);
                StringBuilder s = new StringBuilder(100009);
                while (s.Length < 100000)
                {
                    s.Append(rnd.Next(100000000, 999999999).ToString());
                }

                s.Remove(100000, s.Length - 100000);
                return s.ToString();
            }
        }

        #endregion
    }
}