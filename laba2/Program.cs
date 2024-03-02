using System;

public class RelaxationMethod
{

    public static void Main(string[] args)
    {
        // Введіть матрицю A, вектор b та похибку
        double[,] matrix ={
            { 3, 2, 4 },
            { 5, 4, 1 },
            { 6, 8,3 }
        };

        double[] b = new double[] { 8,3,12 };
        double eps = 0.01;

        // Ініціалізуйте вектор x
        double[] x = { 0, 0, 0 };

        // Вирішуйте СЛАР методом релаксації
        int iterations = Solve(matrix,x,b,eps);

        // Виведіть результат
        for (int i = 0; i < x.Length; i++)
        {
            Console.WriteLine($"x{i + 1} = {x[i]}");
        }

        // Виведіть кількість ітерацій
        Console.WriteLine($"Кількість ітерацій: {iterations}");
        Console.WriteLine();
        Console.WriteLine($"Перевірка");
        Console.WriteLine($"3x1 + 2x2 + 4x3 = {3*x[0] + 2*x[1]+4*x[2]} - {b[0]} = {3 * x[0] + 2 * x[1] + 4 * x[2] - b[0]}");
        Console.WriteLine($"5x1 + 4x2 + x3 = {5*x[0] + 4*x[1]+1*x[2]} - {b[1]} = {5 * x[0] + 4 * x[1] + 1 * x[2] - b[1]}");
        Console.WriteLine($"6x1 + 8x2 + 3x3 = {6*x[0] + 8*x[1]+3*x[2]} - {b[2]} = {6 * x[0] + 8 * x[1] + 3 * x[2] - b[2]}");
    }

    private static int Solve(double[,] matrix, double[] x, double[] b, double eps)
    {
        int iterations = 0;
        while (true)
        {
            bool hasChanged = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        sum += matrix[i, j] * x[j];
                    }
                }

                double newX = (b[i] - sum) / matrix[i, i];

                if (Math.Abs(newX - x[i]) > eps)
                {
                    x[i] = newX;
                    hasChanged = true;
                }
            }

            iterations++;

            if (!hasChanged)
            {
                break;
            }
        }

        return iterations;
    }
}
