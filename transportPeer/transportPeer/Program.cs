using System;
using System.IO;
using EKRLib;


namespace transportPeer
{
    /// <summary>
    /// Класс программы.
    /// </summary>
    class Program
    {
        /// <summary>
        ///  Переменая для рандома.
        /// </summary>
        public static Random rnd = new Random();

        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        static void Main()
        {
            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                CreateOrClearFiles();
                Transport[] transports = new Transport[rnd.Next(6, 10)];
                for (int i = 0; i < transports.Length; i++)
                {
                    try
                    {
                        transports[i] = TryToGetTransport();
                        Console.WriteLine(transports[i].StartEngine());
                        WriteTransportInFile(transports[i]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Произошло исключение НЕ типа TransportException при попытке создать транспорт:");
                        Console.WriteLine(e.Message);
                    }
                }
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Нажмите ENTER, чтобы начать заново");
                Console.WriteLine("Нажмите НЕ ENTER, чтобы закончить");
                Console.WriteLine("------------------------------------");
                consoleKeyInfo = Console.ReadKey(true);
            }
            while (consoleKeyInfo.Key == ConsoleKey.Enter);
        }

        /// <summary>
        /// Метод пытается создать/очистить файлы "Cars.txt" и "MotorBoats.txt".
        /// </summary>
        private static void CreateOrClearFiles()
        {
            try
            {
                char separator = Path.DirectorySeparatorChar;
                string goingToParentFolder = $"..{separator}..{separator}..{separator}..{separator}";
                File.WriteAllText(@$"{goingToParentFolder}Cars.txt", "", System.Text.Encoding.Unicode);
                File.WriteAllText(@$"{goingToParentFolder}MotorBoats.txt", "", System.Text.Encoding.Unicode);
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникло исключение при попытке создания файлов:");
                Console.WriteLine(e.Message);
            }
        }
        
        /// <summary>
        /// Метод пытается записать транспорт в подходящий файл.
        /// </summary>
        /// <param name="transport"></param>
        private static void WriteTransportInFile(Transport transport)
        {
            try
            {
                char separator = Path.DirectorySeparatorChar;
                string goingToParentFolder = $"..{separator}..{separator}..{separator}..{separator}";
                if (transport.GetType() == typeof(Car))
                    File.AppendAllText(@$"{goingToParentFolder}Cars.txt", transport.ToString() + Environment.NewLine, System.Text.Encoding.Unicode);
                if (transport.GetType() == typeof(MotorBoat))
                    File.AppendAllText(@$"{goingToParentFolder}MotorBoats.txt", transport.ToString() + Environment.NewLine, System.Text.Encoding.Unicode);
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникло исключение при попытке записи в файл:");
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Пытается создать транспорт случайным образом.
        /// </summary>
        /// <returns>Транспорт, созданный случайным образом.</returns>
        private static Transport TryToGetTransport()
        {
            Random rnd = new();
            uint power = (uint)rnd.Next(10, 100);
            string model = GetRandomModel();
            try
            {
                if (rnd.Next(0, 2) == 0)
                    return new Car(model, power);
                else
                    return new MotorBoat(model, power);
            }
            catch (TransportException e)
            {
                Console.WriteLine(e.Message);
                return TryToGetTransport();
            }
        }

        /// <summary>
        /// Метод для генерации случайного названия модели.
        /// </summary>
        /// <returns> Название модели.</returns>
        private static string GetRandomModel()
        {
            Random rnd = new();
            char[] model = new char[5];
            for (int i = 0; i < model.Length; i++)
            {
                if (rnd.Next(0, 2) == 0)
                    model[i] = (char)rnd.Next('A', 'Z' + 1);
                else
                    model[i] = (char)rnd.Next('0', '9' + 1);
            }
            return new string(model);
        }
    }
}
