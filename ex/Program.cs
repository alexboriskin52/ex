using System;
using System.Linq.Expressions;

public interface IVectorOperations
{
    double Length();
    double DotProduct(Vector3D other);
    Vector3D Add(Vector3D other);
    Vector3D Subtract(Vector3D other);
    Vector3D Multiply(double scalar);
    bool Equals(Vector3D other);
    bool CompareLength(Vector3D other);
}
public abstract class AbsVector : IVectorOperations
{
    protected double x, y, z;
    public abstract double Length();
    public abstract double DotProduct(Vector3D other);
    public abstract Vector3D Add(Vector3D other);
    public abstract Vector3D Subtract(Vector3D other);

    public abstract Vector3D Multiply(double scalar);
    public abstract bool Equals(Vector3D other);
    public abstract bool CompareLength(Vector3D other);

}

public class Vector3D : AbsVector
{
    public Vector3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public override double Length()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

    public override double DotProduct(Vector3D other)
    {
        return x * other.x + y * other.y + z * other.z;
    }

    public override Vector3D Add(Vector3D other)
    {
        return new Vector3D(x + other.x, y + other.y, z + other.z);
    }

    public override Vector3D Subtract(Vector3D other)
    {
        return new Vector3D(x - other.x, y - other.y, z - other.z);
    }

    public override Vector3D Multiply(double scalar)
    {
        return new Vector3D(x * scalar, y * scalar, z * scalar);
    }

    public override bool Equals(Vector3D other)
    {
        return x == other.x && y == other.y && z == other.z;
    }

    public override bool CompareLength(Vector3D other)
    {
        return Length() == other.Length();
    }

    public override string ToString()
    {
        return x + " " + y + " " + z;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Ручной ввод значений для вектора 1
            Console.WriteLine("Введите x для вектора 1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите y для вектора 1: ");
            double y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите z для вектора 1: ");
            double z1 = double.Parse(Console.ReadLine());
            Vector3D vector1 = new Vector3D(x1, y1, z1);

            // Ручной ввод значений для вектора 2
            Console.WriteLine("Введите x для вектора 2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите y для вектора 2: ");
            double y2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите z для вектора 2: ");
            double z2 = double.Parse(Console.ReadLine());
            Vector3D vector2 = new Vector3D(x2, y2, z2);

            Console.WriteLine("Длина вектора 1: " + vector1.Length());
            Console.WriteLine("Скалярное произведение вектора 1 и вектора 2: " + vector1.DotProduct(vector2));

            // Vector3D sum = vector1.Add(vector2);
            Console.WriteLine($"Сумма вектора 1 и вектора 2: {vector1.Add(vector2)}");

            //Vector3D difference = vector1.Subtract(vector2);
            Console.WriteLine($"Разность вектора 1 и вектора 2: {vector1.Subtract(vector2)} ");

            //Vector3D scalarProduct = vector1.Multiply(2);
            Console.WriteLine($"Произведение вектора 1 на 2: {vector1.Multiply(2)}");

            Console.WriteLine("Вектора 1 и 2 равны? " + vector1.Equals(vector2));
            Console.WriteLine("Длины векторов 1 и 2 равны? " + vector1.CompareLength(vector2));
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.Message);
        }
    }
}


