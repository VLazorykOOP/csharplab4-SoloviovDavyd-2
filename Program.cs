using System;

public class DRomb
{
    private int d1; // Перша діагональ
    private int d2; // Друга діагональ
    private int color; // Колір ромба

    // Конструктор
    public DRomb(int diagonal1, int diagonal2, int color)
    {
        this.d1 = diagonal1;
        this.d2 = diagonal2;
        this.color = color;
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return d1;
                case 1: return d2;
                case 2: return color;
                default:
                    throw new IndexOutOfRangeException("Індекс має бути 0, 1 або 2.");
            }
        }
    }

    // Перевантаження операторів ++ (постфіксна форма)
    public static DRomb operator ++(DRomb rhombus)
    {
        rhombus.d1++;
        rhombus.d2++;
        return rhombus;
    }

    // Перевантаження операторів -- (постфіксна форма)
    public static DRomb operator --(DRomb rhombus)
    {
        rhombus.d1--;
        rhombus.d2--;
        return rhombus;
    }

    // Перевантаження true для класу
    public static bool operator true(DRomb rhombus)
    {
        return rhombus.IsSquare();
    }

    // Перевантаження false для класу
    public static bool operator false(DRomb rhombus)
    {
        return !rhombus.IsSquare();
    }

    // Перевантаження оператора +
    public static int operator +(DRomb rhombus, int scalar)
    {
        return rhombus.d1 + rhombus.d2 + scalar;
    }

    // Перетворення типу DRomb в string
    public static explicit operator string(DRomb rhombus)
    {
        return $"DRomb: d1 = {rhombus.d1}, d2 = {rhombus.d2}, color = {rhombus.color}";
    }

    // Перевантаження виводу на консоль
    public override string ToString()
    {
        return $"DRomb: d1 = {d1}, d2 = {d2}, color = {color}";
    }

    // Метод для виведення довжин на екран
    public void PrintDimensions()
    {
        Console.WriteLine($"Перша діагональ: {d1}, Друга діагональ: {d2}");
    }

    // Метод для розрахунку периметру ромба
    public double CalculatePerimeter()
    {
        return 2 * (d1 + d2);
    }

    // Метод для розрахунку площі ромба
    public double CalculateArea()
    {
        return (d1 * d2) / 2.0;
    }

    // Метод, що перевіряє, чи є ромб квадратом
    public bool IsSquare()
    {
        return d1 == d2;
    }

    // Властивість для доступу до коліру (тільки для читання)
    public int Color
    {
        get { return color; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення екземпляру класу DRomb
        DRomb rhombus = new DRomb(5, 5, 1);

        // Використання індексатора для отримання значень
        Console.WriteLine($"Діагональ 1: {rhombus[0]}");
        Console.WriteLine($"Діагональ 2: {rhombus[1]}");
        Console.WriteLine($"Колір: {rhombus[2]}");

        // Використання операторів ++ та --
        rhombus++;
        Console.WriteLine($"Після збільшення: {rhombus}");
        rhombus--;
        Console.WriteLine($"Після зменшення: {rhombus}");

        // Використання перевантажених true та false
        if (rhombus)
            Console.WriteLine("Цей ромб є квадратом.");
        else
            Console.WriteLine("Цей ромб не є квадратом.");

        // Використання перевантаженого оператора +
        int scalar = 10;
        Console.WriteLine($"Сума діагоналей зі скаляром {scalar}: {rhombus + scalar}");

        // Використання перетворення типу в string
        string rhombusString = (string)rhombus;
        Console.WriteLine($"Рядок: {rhombusString}");
    }
}
