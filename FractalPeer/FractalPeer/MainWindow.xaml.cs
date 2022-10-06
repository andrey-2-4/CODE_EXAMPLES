using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalPeer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация компонентов.
        /// </summary>
        public MainWindow()
        {
            WindowState = WindowState.Maximized;
            Visibility = Visibility.Collapsed;
            WindowStyle = WindowStyle.SingleBorderWindow;
            ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
            Desk = canvas;
            TextBoxCoefficient = textBoxCoefficient;
            TextBoxAngle1 = textBoxAngle1;
            TextBoxAngle2 = textBoxAngle2;
            TextBox = textBox;
            TextBoxKantor = textBoxKantor;
        }

        /// <summary>
        /// Переменная для обращения к canvas.
        /// </summary>
        public static Canvas Desk = new();
        /// <summary>
        /// Переменная длля обращения к textBoxCoefficient.
        /// </summary>
        public static TextBox TextBoxCoefficient = new();
        /// <summary>
        /// Переменная длля обращения к textBoxAngle1.
        /// </summary>
        public static TextBox TextBoxAngle1 = new();
        /// <summary>
        /// Переменная длля обращения к textBoxAngle2.
        /// </summary>
        public static TextBox TextBoxAngle2 = new();
        /// <summary>
        /// Переменная длля обращения к textBox.
        /// </summary>
        public static TextBox TextBox = new();
        /// <summary>
        /// Переменная длля обращения к textBoxKantor.
        /// </summary>
        public static TextBox TextBoxKantor = new();
        /// <summary>
        /// Дополнительные параметры.
        /// </summary>
        public static int coefficient, deep;
        /// <summary>
        /// Дополнительные параметры.
        /// </summary>
        public static double angle1, angle2, lineLength = 100, lineKochLength = 600;

        /// <summary>
        /// Объект для работы с деревом.
        /// </summary>
        Tree tree = new();
        /// <summary>
        /// Объект для работы с треугольником.
        /// </summary>
        Triangle triangle = new();
        /// <summary>
        /// Объект для работы с множеством Кантора.
        /// </summary>
        Kantor kantor = new();

        /// <summary>
        /// Обрабатывает при нажатии на кнопку отрисовки дерева.
        /// </summary>
        /// <param name="sender"> Отправитель.</param>
        /// <param name="e"> Аргументы.</param>
        private void ButtonTree_Click(object sender, RoutedEventArgs e)
        {
            tree.DrawFractal();
        }

        /// <summary>
        /// Обрабатывает при нажатии на кнопку отрисовки ковра.
        /// </summary>
        /// <param name="sender"> Отправитель.</param>
        /// <param name="e"> Аргументы.</param>
        private void ButtonCarpet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ковра тоже нет... Зато есть xml-комментарии...");
        }

        /// <summary>
        /// Обрабатывает при нажатии на кнопку отрисовки треугольника.
        /// </summary>
        /// <param name="sender"> Отправитель.</param>
        /// <param name="e"> Аргументы.</param>
        private void ButtonTriangle_Click(object sender, RoutedEventArgs e)
        {
            triangle.DrawFractal();
        }   

        /// <summary>
        /// Обрабатывает при нажатии на кнопку отрисовки множества Кантора.
        /// </summary>
        /// <param name="sender"> Отправитель.</param>
        /// <param name="e"> Аргументы.</param>
        private void ButtonKantor_Click(object sender, RoutedEventArgs e)
        {      
            kantor.DrawFractal();
        }

        /// <summary>
        /// Очищает холст при нажатии на кнопку.
        /// </summary>
        /// <param name="sender"> Отправитель.</param>
        /// <param name="e"> Аргументы.</param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            SetDefault();
        }

        /// <summary>
        /// Обрабатывает при нажатии на кнопку отрисовки линии Коха.
        /// </summary>
        /// <param name="sender"> Отправитель.</param>
        /// <param name="e"> Аргументы.</param>
        private void ButtonKoch_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Коха нет, не получилось, но есть 'оригинальное' дерево");
        }

        /// <summary>
        /// Возвращает все, как было при запуске.
        /// </summary>
        public static void SetDefault()
        {
            TextBox.Text = "";
            TextBoxCoefficient.Text = "(для дерева) коэффициент уменьшения отрезка (от 2 до 5, целое число)";
            TextBoxAngle1.Text = "(для дерева) Угол1 (от 10 до 80 градусов, целое число)";
            TextBoxAngle2.Text = "(для дерева) Угол2 (от 10 до 80 градусов, целое число)";
            TextBoxKantor.Text = "(для Кантора) целое число от 1 до 10, насколько большая часть отрезка вырезается";
            (MainWindow.coefficient, MainWindow.angle1, MainWindow.angle2, MainWindow.deep, lineKochLength, lineLength) = (0, 0, 0, 0, 600, 100);
        }
    }

    /// <summary>
    /// Базовый класс для отрисовки фрактала.
    /// </summary>
    public abstract class Fractal
    {
        /// <summary>
        /// Отрисовка фрактала.
        /// </summary>
        public abstract void DrawFractal();
    }

    /// <summary>
    /// Класс для множества Кантора.
    /// </summary>
    public class Kantor : Fractal
    {
        public override void DrawFractal()
        {
            if (int.TryParse(MainWindow.TextBox.Text, out int deep) && deep > 0 && deep < 11 &&
                int.TryParse(MainWindow.TextBoxKantor.Text, out MainWindow.coefficient) && MainWindow.coefficient > 0 && MainWindow.coefficient < 11)
            {
                DrawKantor(deep, MainWindow.coefficient);
            }
            else
            {
                MessageBox.Show("Что-то не так с числами, проверьте ещё раз, пожалуйста");
                MainWindow.SetDefault();
            }
        }

        /// <summary>
        /// Отрисовка множества Кантора.
        /// </summary>
        /// <param name="deep"></param>
        /// <param name="coefficient"></param>
        public void DrawKantor(int deep, int coefficient)
        {
            List<Line> lines = new();
            Line line = new Line();
            double y = MainWindow.Desk.ActualHeight / 2;
            line.X1 = MainWindow.Desk.ActualWidth / 2 - 200;
            line.Y1 = y;
            line.X2 = MainWindow.Desk.ActualWidth / 2 + 200;
            line.Y2 = y;
            lines.Add(line);
            for (int i = 0; i < deep; i++)
            {
                List<Line> tempLines = new();
                foreach (var subLine in lines)
                {
                    Line line1 = new();
                    line1.X1 = subLine.X1;
                    line1.X2 = (subLine.X2 + subLine.X1) / 2 - coefficient / 100.0 * (subLine.X2 - subLine.X1);
                    line1.Y1 = y;
                    line1.Y2 = y;
                    tempLines.Add(line1);
                    Line line2 = new();
                    line2.X2 = subLine.X2;
                    line2.X1 = (subLine.X2 + subLine.X1) / 2 + coefficient / 100.0 * (subLine.X2 - subLine.X1);
                    line2.Y1 = y;
                    line2.Y2 = y;
                    tempLines.Add(line2);
                }
                lines = tempLines;
            }
            foreach (var item in lines)
            {
                item.Stroke = Brushes.Black;
                MainWindow.Desk.Children.Add(item);
            }
        }
    }

    /// <summary>
    /// Класс для треугольника.
    /// </summary>
    public class Triangle : Fractal
    {
        public override void DrawFractal()
        {
            Point point = new Point(MainWindow.Desk.ActualWidth / 2, MainWindow.Desk.ActualHeight / 2);
            if (int.TryParse(MainWindow.TextBox.Text, out int deep) && deep > 0 && deep < 11)
            {
                DrawTriangle(new Point(point.X - 150, point.Y), new Point(point.X, point.Y - (Math.Sqrt(3) * 300 / 2)), new Point(point.X + 150, point.Y), deep);
            }
            else
            {
                MessageBox.Show("Что-то не так с числами, проверьте ещё раз, пожалуйста");
                MainWindow.SetDefault();
            }
        }

        /// <summary>
        /// Отрисовка треугольника.
        /// </summary>
        /// <param name="point1"> Точка1.</param>
        /// <param name="point2"> Точка2.</param>
        /// <param name="point3"> Точка3.</param>
        /// <param name="deep"> Кол-во операций.</param>
        public void DrawTriangle(Point point1, Point point2, Point point3, int deep)
        {
            if (deep == 0)
                return;
            deep -= 1;
            Polygon polygon = new();
            polygon.Points.Add(point1);
            polygon.Points.Add(point2);
            polygon.Points.Add(point3);
            polygon.Stroke = Brushes.Black;
            MainWindow.Desk.Children.Add(polygon);
            DrawTriangle(point1, new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2), new Point((point1.X + point3.X) / 2, (point1.Y + point3.Y) / 2), deep);
            DrawTriangle(new Point((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2), point2, new Point((point2.X + point3.X) / 2, (point2.Y + point3.Y) / 2), deep);
            DrawTriangle(new Point((point1.X + point3.X) / 2, (point1.Y + point3.Y) / 2), new Point((point2.X + point3.X) / 2, (point2.Y + point3.Y) / 2), point3, deep);
        }
    }

    /// <summary>
    /// Класс для дерева.
    /// </summary>
    public class Tree : Fractal
    {
        public override void DrawFractal()
        {
            GetValuesForTree();
            if (MainWindow.deep == 0)
                return;
            Polygon line = new Polygon();
            line.Stroke = Brushes.Black;
            Point point = new Point(MainWindow.Desk.ActualWidth / 2, MainWindow.Desk.ActualHeight / 2);
            line.Points.Add(new Point(MainWindow.Desk.ActualWidth / 2, MainWindow.Desk.ActualHeight / 2 + 100));
            line.Points.Add(point);
            line.FillRule = FillRule.Nonzero;
            MainWindow.Desk.Children.Add(line);
            DrawTree(point, MainWindow.angle1, MainWindow.angle2, MainWindow.lineLength, MainWindow.deep);
        }

        /// <summary>
        /// Рисует Дерево.
        /// </summary>
        /// <param name="point"> Точка.</param>
        /// <param name="angle1"> Угол налево.</param>
        /// <param name="angle2"> Угол направо.</param>
        /// <param name="lineLength"> Длина палки.</param>
        /// <param name="deep"> Кол-во операций.</param>
        private void DrawTree(Point point, double angle1, double angle2, double lineLength, int deep)
        { 
            if (deep == 0)
                return;
            deep -= 1;
            Polygon line = new Polygon();
            line.Stroke = Brushes.Green;
            line.Points.Add(point);
            //textBox.Text = (lineLength / coefficient * Math.Sin(angle1)).ToString();
            Point point1 = new Point(point.X - lineLength / MainWindow.coefficient * Math.Sin(angle1), point.Y - lineLength / MainWindow.coefficient * Math.Cos(angle1));
            line.Points.Add(point1);
            MainWindow.Desk.Children.Add(line);
            //DrawTree() //для левой и для правой.
            line = new Polygon();
            line.Stroke = Brushes.Red;
            line.Points.Add(point);
            Point point2 = new Point(point.X + lineLength / MainWindow.coefficient * Math.Sin(angle2), point.Y - lineLength / MainWindow.coefficient * Math.Cos(angle2));
            line.Points.Add(point2);
            //textBox.Text = (lineLength / coefficient * Math.Cos(angle2)).ToString();
            MainWindow.Desk.Children.Add(line);
            if (deep > 0)
            {
                DrawTree(point1, angle1 + MainWindow.angle1, angle2 - MainWindow.angle1, lineLength / MainWindow.coefficient, deep);
                DrawTree(point2, angle1 - MainWindow.angle2, angle2 + MainWindow.angle2, lineLength / MainWindow.coefficient, deep);
            }
        }

        /// <summary>
        /// Получение параметров для дерева и их проверка.
        /// </summary>
        /// <returns> Параметры для дерева.</returns>
        public void GetValuesForTree()
        {
            if (int.TryParse(MainWindow.TextBoxCoefficient.Text, out int coefficient) && coefficient > 1 && coefficient < 6 &&
                int.TryParse(MainWindow.TextBoxAngle1.Text, out int angle1) && angle1 > 9 && angle1 < 81 &&
                int.TryParse(MainWindow.TextBoxAngle2.Text, out int angle2) && angle2 > 9 && angle2 < 81 &&
                int.TryParse(MainWindow.TextBox.Text, out int deep) && deep > 0 && deep < 11)
            {
                (MainWindow.coefficient, MainWindow.angle1, MainWindow.angle2, MainWindow.deep) = (coefficient, (Math.PI / 180) * (angle1), (Math.PI / 180) * (angle2), deep);
            }
            else
            {
                MessageBox.Show("Что-то не так с числами, проверьте ещё раз, пожалуйста");
                MainWindow.SetDefault();
            }
        }
    }
}
