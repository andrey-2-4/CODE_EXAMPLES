using System;

namespace MatrixCalculator
{
    class Program
    {
        // Иногда при выводе используется форматирование и нужно вручную менять параметры выода, не только эту переменную.
        // Например: Console.Write($"{matrix[i][j]:f5}" + ' '*(maxSpace.Length - matrix[i][j].ToString().Length) + " ");
        /// <summary>
        /// Число, до которого происходит округление. 
        /// </summary>
        const int RoundTo = 5;
        /// <summary>
        /// Калькулятор матриц.
        /// </summary>
        static void Main()
        {
            // Переменная для завершения программы.
            ConsoleKeyInfo keyCheck;
            // Цикл для возможности поторения решения.
            do
            {
                Console.Clear();
                Info();
                int operation = GetOperation();
                Console.Clear();
                DoOperation(operation);
                Console.WriteLine("Нажмите НЕ ESC, например, ENTER, если хотите сделать новую операцию над матрицами");
                Console.WriteLine("Если нет, то нажмите ESC");
                keyCheck = Console.ReadKey(true);
            }
            while (keyCheck.Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Вывод доступных операций.
        /// </summary>
        static void Info()
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine("Операции выполняютя для матриц размера от 1x1 до 10x10!!!");
            Console.WriteLine($"Все числа могут принимать значение от {double.MinValue} до {double.MaxValue}!!!");
            Console.WriteLine($"Все числа округляются до {RoundTo} знаков после запятой!!!");
            Console.WriteLine("Матрицы могут не помещаться в консоли,");
            Console.WriteLine("если операция производится над матрицей широкой и/или с большими значениям!!!");
            Console.WriteLine("================================================================================");
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("1. Нахождение следа матрицы");
            Console.WriteLine("2. Транспонирование матрицы");
            Console.WriteLine("3. Сумма двух матриц");
            Console.WriteLine("4. Разность двух матриц");
            Console.WriteLine("5. Произведение двух матриц");
            Console.WriteLine("6. Умножение матрицы на число");
            Console.WriteLine("7. Нахождение определителя матрицы");
            Console.WriteLine("================================================================================");
        }

        /// <summary>
        /// Получение номера операции.
        /// </summary>
        /// <returns> Номер операции.</returns>
        static int GetOperation()
        {
            int operation;
            Console.WriteLine("Введите номер операции, которую Вы хотите выполнить (1 - 7)");
            if (int.TryParse(Console.ReadLine(), out operation) && 0 < operation && operation < 8)
            {
                // Чтобы удалить информацию, которая не нужна пользователю во время выполнения конкретной операции, очищаем консоль.
                Console.Clear();
                return operation;
            }
            // Если ввели неправильное значение.
            do
            {
                Console.WriteLine("Некорректный ввод.");
                Console.WriteLine("Пожалуйста, введите номер операции, которую Вы хотите выполнить (1 - 7)");
            }
            while (!(int.TryParse(Console.ReadLine(), out operation) && 0 < operation && operation < 8));
            // Чтобы удалить информацию, которая не нужна пользователю во время выполнения конкретной операции, очищаем консоль.
            Console.Clear();
            return operation;
        }

        /// <summary>
        /// Выбор операции, которая должна быть выполнена.
        /// </summary>
        /// <param name="operation"> Номер операции.</param>
        static void DoOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    GetTrace();
                    break;
                case 2:
                    GetTransposed();
                    break;
                case 3:
                    GetSum();
                    break;
                case 4:
                    GetDifference();
                    break;
                case 5:
                    GetMatrixMultiplication();
                    break;
                case 6:
                    GetNumberMultiplication();
                    break;
                case 7:
                    PrintDeterminant();
                    break;
            }
        }

        /// <summary>
        /// Вычисление следа матрицы.
        /// </summary>
        static void GetTrace()
        {
            double[][] matrix = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица:");
            PrintMatrix(matrix);
            if (matrix.GetLength(0) != matrix[0].GetLength(0))
            {
                Console.WriteLine("Невозможно вычислить след матрицы т.к. матрица НЕ квадратная!!!");
                return;
            }
            else
            {
                double trace = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    trace += matrix[i][i];
                }
                Console.WriteLine($"След матрицы = {trace:f5}");
                return;
            }
        }

        /// <summary>
        /// Получение транспонированной матрицы.
        /// </summary>
        static void GetTransposed()
        {
            double[][] matrix = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица:");
            PrintMatrix(matrix);
            double[][] matrixTransposed = new double[matrix[0].GetLength(0)][];
            for (int i = 0; i < matrix[0].GetLength(0); i++)
            {
                matrixTransposed[i] = new double[matrix.GetLength(0)];
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrixTransposed[i][j] = matrix[j][i];
                }
            }
            Console.WriteLine("Транспонированная матрица:");
            PrintMatrix(matrixTransposed);
        }

        /// <summary>
        /// Сложение матриц.
        /// </summary>
        static void GetSum()
        {
            Console.Clear();
            Console.WriteLine("Матрица 1:");
            double[][] matrix1 = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица 2:");
            double[][] matrix2 = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица 1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матрица 2:");
            PrintMatrix(matrix2);
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1[0].GetLength(0) != matrix2[0].GetLength(0))
            {
                Console.WriteLine("Операция невозможна т.к. матрицы разных размеров!!!");
                return;
            }
            else
            {
                double[][] matrixSum = new double[matrix1.GetLength(0)][];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    matrixSum[i] = new double[matrix1[0].GetLength(0)];
                    for (int j = 0; j < matrix1[0].GetLength(0); j++)
                    {
                        matrixSum[i][j] = Math.Round(matrix1[i][j] + matrix2[i][j], RoundTo);
                    }
                }
                Console.WriteLine("Сумма матриц:");
                PrintMatrix(matrixSum);
                return;
            }
        }

        /// <summary>
        /// Вычитание матриц.
        /// </summary>
        static void GetDifference()
        {
            Console.Clear();
            Console.WriteLine("Матрица 1:");
            double[][] matrix1 = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица 2:");
            double[][] matrix2 = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица 1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матрица 2:");
            PrintMatrix(matrix2);
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1[0].GetLength(0) != matrix2[0].GetLength(0))
            {
                Console.WriteLine("Операция невозможна т.к. матрицы разных размеров!!!");
                return;
            }
            else
            {
                double[][] matrixDiff = new double[matrix1.GetLength(0)][];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    matrixDiff[i] = new double[matrix1[0].GetLength(0)];
                    for (int j = 0; j < matrix1[0].GetLength(0); j++)
                    {
                        matrixDiff[i][j] = Math.Round(matrix1[i][j] - matrix2[i][j], RoundTo);
                    }
                }
                Console.WriteLine("Разница матриц (матрица 1 - матрица 2):");
                PrintMatrix(matrixDiff);
                return;
            }
        }

        /// <summary>
        /// Произведение матриц.
        /// </summary>
        static void GetMatrixMultiplication()
        {
            Console.Clear();
            Console.WriteLine("Матрица 1:");
            double[][] matrix1 = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица 2:");
            double[][] matrix2 = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица 1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Матрица 2:");
            PrintMatrix(matrix2);
            if (matrix2.GetLength(0) != matrix1[0].GetLength(0))
            {
                Console.WriteLine("Операция невозможна!!!");
                return;
            }
            else
            {
                double[][] matrixMultiplication = new double[matrix1.GetLength(0)][];
                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    matrixMultiplication[i] = new double[matrix2[0].GetLength(0)];
                    for (int j = 0; j < matrix2[0].GetLength(0); j++)
                    {
                        for (int r = 0; r < matrix1[0].GetLength(0); r++)
                        {
                            matrixMultiplication[i][j] += matrix1[i][r] * matrix2[r][j];
                        }
                        matrixMultiplication[i][j] = Math.Round(matrixMultiplication[i][j], RoundTo);
                    }
                }
                Console.WriteLine("Произведение матриц:");
                PrintMatrix(matrixMultiplication);
                return;
            }
        }

        /// <summary>
        /// Умножение матрицы на число.
        /// </summary>
        static void GetNumberMultiplication()
        {
            double[][] matrix = CreateMatrix();
            Console.Clear();
            double number;
            Console.WriteLine("Введите число, на которое хотите умножить");
            if (double.TryParse(Console.ReadLine(), out number))
            {
            }
            else
            {
                do
                {
                    Console.WriteLine("Некорректный ввод.");
                    Console.WriteLine("Введите число, на которое хотите умножить");
                }
                while (!double.TryParse(Console.ReadLine(), out number));
            }
            Console.WriteLine("Матрица:");
            PrintMatrix(matrix);
            double[][] matrixMultiplied = new double[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixMultiplied[i] = new double[matrix[0].GetLength(0)];
                for (int j = 0; j < matrix[0].GetLength(0); j++)
                {
                    matrixMultiplied[i][j] = Math.Round(number * matrix[i][j], RoundTo);
                }
            }
            Console.WriteLine($"Матрица, умноженная на число {number}:");
            PrintMatrix(matrixMultiplied);
        }

        /// <summary>
        /// Вывод определителя матрицы.
        /// </summary>
        static void PrintDeterminant()
        {
            double[][] matrix = CreateMatrix();
            Console.Clear();
            Console.WriteLine("Матрица:");
            PrintMatrix(matrix);
            if (matrix.GetLength(0) != matrix[0].GetLength(0))
            {
                Console.WriteLine("Операция невозможна т.к. матрица НЕ квадратная!!!");
            }
            else
            {
                GetDeterminant(matrix, out double determinant);
                Console.Write("Определитель: ");
                Console.WriteLine(Math.Round(determinant, RoundTo));
            }
        }

        /// <summary>
        /// Вычисление определителя матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица.</param>
        /// <param name="determinant"> Определитель.</param>
        static void GetDeterminant(double[][] matrix, out double determinant)
        {
            determinant = 1;
            for (int i = 0; i < matrix[0].GetLength(0); i++)
            {
                int k = i;
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    if (Math.Abs(matrix[j][i]) > Math.Abs(matrix[k][i]))
                    {
                        k = j;
                    }
                }
                if (i < matrix.GetLength(0))
                {
                    if (matrix[k][i] == 0)
                    {
                        determinant = 0;
                    }
                    double[] b = matrix[i];
                    matrix[i] = matrix[k];
                    matrix[k] = b;
                    if (i != k)
                    {
                        determinant = -determinant;
                    }
                    determinant *= matrix[i][i];
                    for (int j = i + 1; j < matrix.GetLength(0); j++)
                    {
                        matrix[i][j] /= matrix[i][i];
                    }
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if ((j != i) && (matrix[j][i]) != 0)
                        {
                            for (k = i + 1; k < matrix.GetLength(0); k++)
                            {
                                matrix[j][k] -= matrix[i][k] * matrix[j][i];
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получение корректных размеров матрицы от пользователя.
        /// </summary>
        /// <param name="rows"> Количество строк.</param>
        /// <param name="columns"> Количество столбцов.</param>
        static void GetRowsColumns(out int rows, out int columns)
        {
            rows = 1;
            columns = 1;
            Console.Write("Введите количество строк: ");
            if (int.TryParse(Console.ReadLine(), out rows) && rows > 0 && rows < 11)
            {
                Console.Write("Введите количество столбцов: ");
                if (int.TryParse(Console.ReadLine(), out columns) && columns > 0 && columns < 11)
                {
                    return;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Некорректный ввод. (требуется число от 1 до 10)");
                        Console.WriteLine("Введите количество столбцов: ");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out columns) && columns > 0 && columns < 11));
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. (требуется число от 1 до 10)");
                GetRowsColumns(out rows, out columns);
            }
        }

        /// <summary>
        /// Создание матрицы.
        /// </summary>
        /// <returns> Созданная матрица.</returns>
        static double[][] CreateMatrix()
        {
            Console.WriteLine("Нажите ENTER, если хотите ввести матрицу вручную.");
            Console.WriteLine("Нажмите НЕ ENTER, например, ПРОБЕЛ если хотите сгенерировать матрицу.");
            ConsoleKeyInfo keyCheck;
            keyCheck = Console.ReadKey(true);
            if (keyCheck.Key == ConsoleKey.Enter)
            {
                return UserMatrix();
            }
            else
            {
                return RandomMatrix();
            }
        }

        /// <summary>
        /// Ввод матрицы пользователем.
        /// </summary>
        /// <returns> Матрица, введенная пользователем.</returns>
        static double[][] UserMatrix()
        {
            GetRowsColumns(out int rows, out int columns);
            double[][] matrix = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new double[columns];
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"matrix[{i + 1}][{j + 1}] = ");
                    if (double.TryParse(Console.ReadLine(), out matrix[i][j]))
                    {
                        continue;
                    }
                    do
                    {
                        Console.WriteLine("Некорректный ввод.");
                        Console.Write($"matrix[{i + 1}][{j + 1}] = ");
                    }
                    while (!double.TryParse(Console.ReadLine(), out matrix[i][j]));
                    matrix[i][j] = Math.Round(matrix[i][j], RoundTo);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Генерация рандомной матрицы.
        /// </summary>
        /// <returns> Рандомная матрица.</returns>
        static double[][] RandomMatrix()
        {
            Random rnd = new Random();
            GetRowsColumns(out int rows, out int columns);
            double[][] matrix = new double[rows][];
            GetMaxMin(out int max, out int min);
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new double[columns];
                for (int j = 0; j < columns; j++)
                {
                    // Создание матрицы со случайными рациональными числами, округление до 5 знаков после запятой.
                    do
                    {
                        matrix[i][j] = Math.Round(Math.Pow(-1, rnd.Next()) * rnd.Next() / rnd.Next(), RoundTo);
                    }
                    while (matrix[i][j] > max || matrix[i][j] < min);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Получение максимума и минимума генерируемых чисел матрицы.
        /// </summary>
        /// <param name="max"> Максимум генерируемых чисел матрицы.</param>
        /// <param name="min"> Минимум генерируемых чисел матрицы.</param>
        static void GetMaxMin(out int max, out int min)
        {
            max = 1;
            min = 1;
            Console.Write("Введите максимум: ");
            if (int.TryParse(Console.ReadLine(), out max))
            {
                Console.Write("Введите минимум: ");
                if (int.TryParse(Console.ReadLine(), out min) && min < max)
                {
                    return;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Некорректный ввод, min < max!");
                        Console.WriteLine("Введите минимум: ");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out min) && min < max));
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод, min < max!");
                GetMaxMin(out max, out min);
            }
        }

        /// <summary>
        /// Вывод матрицы.
        /// </summary>
        /// <param name="matrix"> Матрица, которую нужно вывести.</param>
        static void PrintMatrix(double[][] matrix)
        {
            // Получение самой большой длины среди элементов матрицы.
            string maxSpace = "", space;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    space = matrix[i][j].ToString();
                    if (space.Length > maxSpace.Length)
                    {
                        maxSpace = space;
                    }
                }
            }
            // Сам вывод.
            for (int i = 0; i < matrix.GetLength(0); i++, Console.WriteLine())
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    string addSpace = new string(' ', (maxSpace.Length - matrix[i][j].ToString().Length));
                    Console.Write($"{matrix[i][j]}" + addSpace + " ");
                }
            }
        }
    }
}
