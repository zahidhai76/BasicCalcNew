using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalcsNew
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            while (!finished)
            {
                try
                {
                    string choice;
                    do
                    {
                        Console.WriteLine("Choose one: Calculator (c), Area (a), Speed (s) or Prime (p): ");
                        choice = Console.ReadLine().ToLower();
                    } while (!Enum.IsDefined(typeof(choices), choice));
                    if (choice == "area" || choice == "a")
                    {
                        string shapeChoice;
                        do
                        {
                            Console.WriteLine("Enter a shape out of the following: Rectangle, Triangle or Circle");
                            shapeChoice = Console.ReadLine().ToLower();
                        } while (!Valid.ValidShape(shapeChoice));
                        if (shapeChoice == "triangle")
                        {
                            Triangle newObj = new Triangle();
                            Console.WriteLine("Enter the length of your triangle: ");
                            newObj.Length = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the width of your triangle: ");
                            newObj.Width = Convert.ToDouble(Console.ReadLine());
                            newObj.Area();
                            newObj.Perimeter();
                        }
                        else if (shapeChoice == "circle")
                        {
                            Circle newObj = new Circle();
                            Console.WriteLine("Enter the radius of your circle: ");
                            newObj.Length = Convert.ToDouble(Console.ReadLine());
                            newObj.Area();
                            newObj.Perimeter();
                        }
                        else
                        {
                            BaseShape newObj = new BaseShape();
                            Console.WriteLine("Enter the length of your rectangle: ");
                            newObj.Length = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the width of your rectagnle: ");
                            newObj.Width = Convert.ToDouble(Console.ReadLine());
                            newObj.Area();
                            newObj.Perimeter();
                        }
                    }
                    else if (choice == "calculator" || choice == "c")
                    {
                        string calcChoice;
                        do
                        {
                            Console.WriteLine("Basic (b) or quadratic (q): ");
                            calcChoice = Console.ReadLine().ToLower();
                        } while (!Enum.IsDefined(typeof(types), calcChoice));
                        if (calcChoice == "b" || calcChoice == "basic")
                        {
                            BaseCalculator newObj = new BaseCalculator();
                            Console.Write("Enter your first number: ");
                            newObj.a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter your second number: ");
                            newObj.b = Convert.ToDouble(Console.ReadLine());
                            do
                            {
                                Console.WriteLine("Enter one of the following operators: +, -, *, / ");
                                newObj.operation = Console.ReadLine().ToLower();
                            } while (!Valid.ValidOperator(newObj.operation));
                            newObj.Calculation(newObj.a, newObj.b);
                        }
                        else
                        {
                            QuadraticCalculator newObj = new QuadraticCalculator();
                            Console.Write("Enter the first co-efficient: ");
                            newObj.a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter the second co-efficient: ");
                            newObj.b = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter the third co-efficient: ");
                            newObj.c = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"Your quadratic is the following: {newObj.a}x² + {newObj.b}x + {newObj.c}");
                            newObj.Calculation(newObj.a, newObj.b, newObj.c);
                        }
                    }
                    else if (choice == "speed" || choice == "s")
                    {
                        SpeedCalc car = new SpeedCalc();
                        Console.Write("Input distance(metres): ");
                        car.Distance = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Input time (hour): ");
                        car.Hour = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Input time (minutes): ");
                        car.Min = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Input time (seconds): ");
                        car.Sec = Convert.ToDouble(Console.ReadLine());
                        car.Speed();
                    }
                    else if (choice == "prime" || choice == "p")
                    {
                        Prime number = new Prime();
                        string primeChoice;
                        do
                        {
                            Console.WriteLine("Prime check (c) or prime sum (s): ");
                            primeChoice = Console.ReadLine().ToLower();
                        } while (!Enum.IsDefined(typeof(primeChoices), primeChoice));
                        if (primeChoice == "check" || primeChoice == "c")
                        {
                            Console.Write("Enter a number: ");
                            number.N = Convert.ToDouble(Console.ReadLine());
                            number.PrimeCheck(number.N);
                        }
                        if (primeChoice == "sum" || primeChoice == "s")
                        {
                            Console.Write("Enter starting number of your range: ");
                            number.x = int.Parse(Console.ReadLine());
                            Console.Write("Enter ending number of your range: ");
                            number.y = int.Parse(Console.ReadLine());
                            number.PrimeSum(number.x, number.y);
                        }
                    }
                        finished = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    public enum choices
    {
        calculator = 0,
        area = 1,
        speed = 2,
        c = 3,
        a = 4,
        prime = 7,
        p = 8
    }

    public enum types
    {
        basic = 0,
        quadratic = 1,
        b = 2,
        q = 3
    }
    public enum primeChoices
    {
        check = 0,
        sum = 1,
        c = 2,
        s = 3
    }
    class BaseShape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public string Name { get; set; }

        public virtual void Area()
        {
            double area = Length * Width;
            Console.WriteLine("The area of your {0} is {1}", Name, area);
        }

        public virtual void Perimeter()
        {
            double perimeter = 2 * (Length + Width);
            Console.WriteLine("The perimeter of your {0} is {1}", Name, perimeter);
        }

    }

    class Circle : BaseShape
    {
        const double pi = Math.PI;
        public override void Area()
        {
            double area = 0.5 * pi * Length * Length;
            Console.WriteLine("The area of your {0} is {1}", Name, area);
        }

        public override void Perimeter()
        {
            double perimeter = 2 * pi * Length;
            Console.WriteLine("The perimeter of your {0} is {1}", Name, perimeter);
        }
    }

    class Triangle : BaseShape
    {
        public override void Area()
        {
            double area = 0.5 * Length * Length;
            Console.WriteLine("The area of your {0} is {1}", Name, area);
        }
        public override void Perimeter()
        {
            double perimeter = (Length + Width) + Math.Sqrt((Length * Length) + (Width * Width));
            Console.WriteLine("The perimeter of your {0} is {1}", Name, perimeter);
        }
    }

    class Valid
    {
        public static bool ValidShape(string choice)
        {
            switch (choice)
            {
                case "triangle":
                case "rectangle":
                case "circle":
                    return true;
                default:
                    return false;
            }
        }

        public static bool ValidOperator(string choice)
        {
            switch (choice)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    return true;
                default:
                    return false;
            }
        }

    }

    public interface ICalculator
    {
        public double a { get; set; }
        public double b { get; set; }
        public void Calculation(double a, double b, double c = 0);

    }

    class BaseCalculator : ICalculator
    {
        public double a { get; set; }
        public double b { get; set; }
        public string operation { get; set; }

        public virtual void Calculation(double a, double b, double c = 0)
        {
            double result;
            switch (operation)
            {
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    break;
                default:
                    result = 0;
                    break;
            }
            Console.WriteLine($"{a} {operation} {b} = {result}");
        }
    }

    class QuadraticCalculator : BaseCalculator
    {
        public double c { get; set; }
        public double discriminant(double a, double b, double c)
        {
            double disc = (b * b) - (4 * a * c);
            return disc;
        }
        public override void Calculation(double a, double b, double c)
        {
            if (discriminant(a, b, c) < 0)
                Console.WriteLine("Roots are imaginary.");
            else
            {
                double result1 = (-b + Math.Sqrt(discriminant(a, b, c))) / (2 * a);
                double result2 = (-b - Math.Sqrt(discriminant(a, b, c))) / (2 * a);
                Console.WriteLine($"The roots to your quadratic are {result1} and {result2}");
            }
        }
    }

    class SpeedCalc
    {
        private double distance, hour, min, sec, timeinseconds, mps, kph, mph;

        public double Distance
        {
            get { return distance; }
            set { if (distance >= 0)
                {
                    distance = value;
                }
                else
                {
                    distance = 0;
                }
            }
        }
        public double Hour
        {
            get { return hour; }
            set { if (hour >= 0) 
                {
                    hour = value;
                }
                else {
                    hour = 0;
                }
            }
        }
        public double Min
        {
            get { return min; }
            set { if (min >= 0)
                {
                    min = value;
                }
                else
                {
                    min = 0;
                }
            }
        }
        public double Sec
        {
            get { return sec; }
            set { if (sec >= 0)
                {
                    sec = value;
                }
                else
                {
                    sec = 0;
                }
            }
        }
        public void Speed()
        {
            timeinseconds = (hour * 3600) + (min * 360) + sec;
            mps = distance / timeinseconds;
            kph = (distance / 1000) / (timeinseconds / 3600);
            mph = kph / 1.609;
            Console.WriteLine("Your speed in metres/sec is {0}", mps);
            Console.WriteLine("Your speed in km/h is {0}", kph);
            Console.WriteLine("Your speed in miles/h is {0}", mph);
        }
    }

    class Prime
    {
        public double N { get; set; }
        public static int ctr = 0;
        public int x { get; set; }
        public int y { get; set; }
        public void PrimeCheck(double n)
        {
            ctr = 0;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    ctr++;
                    break;
                }
            }
            if (ctr == 0 && n != 1)
                Console.Write("{0} is a prime number.", n);
            else
                Console.Write("{0} is not a prime number.", n);
        }

        public void PrimeSum(int x, int y)
        {
            int n;
            List<int> sum = new List<int>();
            int sum1 = 0;
            for (n = x; n <= y; n++)
            {
                ctr = 0;
                for (int i = 2; i <= n / 2; i++)
                {
                    if (n % i == 0)
                    {
                        ctr++;
                        break;
                    }
                }
                if (ctr == 0 && n != 1)
                {
                    Console.Write("{0} ", n);
                    sum.Add(n);
                }
            }
            foreach (int i in sum)
            {
                sum1 += i;
            }
            Console.WriteLine("\nThe sum of your primes is {0}.", sum1);
        }
    }
}
