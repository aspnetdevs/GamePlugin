using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GamePlugin
{
    public partial class Arrow : UserControl
    {
        Player player;
        //Нужно для генерации метаданных
        public Point endPoint;
        public Arrow(Point endPoint, Player player)
        {
            InitializeComponent();
            this.player = player;
            this.endPoint = endPoint;
            DrawArrow(endPoint);
        }

        //Сделать цвет в зависимости от параметра игрока и выбранного действия.
        private void DrawArrow(Point endPoint)
        {
            Line line = new Line();
            Line head = new Line();
            Point startPoint = new Point(Canvas.GetLeft(player) + player.ActualWidth / 2, Canvas.GetTop(player) + player.ActualHeight / 2);
            line.X1 = startPoint.X;
            line.Y1 = startPoint.Y;
            line.X2 = endPoint.X;
            line.Y2 = endPoint.Y;
            line.StrokeThickness = 5;
            line.StrokeEndLineCap = PenLineCap.Triangle;
            line.Stroke = new SolidColorBrush(Colors.Black);
            this.ArrowCanvas.Children.Add(line);
        }
    }
}
