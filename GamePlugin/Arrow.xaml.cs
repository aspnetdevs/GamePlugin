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
        Line line;
        double lineLength;
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
            line = new Line();
            Line head = new Line();
            Point startPoint = new Point(Canvas.GetLeft(player) + player.ActualWidth / 2, Canvas.GetTop(player) + player.ActualHeight / 2);
            lineLength = GameEnvironment.GetLengthBetweenPoints(startPoint, endPoint);
            double angle = GameEnvironment.GetAngleBetweenPoints(startPoint, endPoint);
            line.X1 = startPoint.X;
            line.Y1 = startPoint.Y;
            line.X2 = line.X1 + lineLength;
            line.Y2 = line.Y1;

            line.StrokeThickness = 5;
            line.StrokeEndLineCap = PenLineCap.Triangle;
            RotateTransform rotate = new RotateTransform();
            rotate.Angle = angle;
            rotate.CenterX = startPoint.X;
            rotate.CenterY = startPoint.Y;
            line.RenderTransform = rotate;
            line.Stroke = GetBrush();

            this.ArrowCanvas.Children.Add(line);
        }

        public void UpdateArrow()
        {
            line.Stroke = GetBrush();
        }
        private Brush GetBrush()
        {
            if (player.actionList != null && player.actionList.selectedAction != null)
            {
                double greenOffset;
                switch (player.actionList.selectedAction)
                {
                    case "Run":
                        greenOffset = ((player.metadata.Run / 2) * (player.metadata.Speed / 100)) * 6 * (player.powerSlider.slider.Value / 100) / lineLength;
                        break;
                    default:
                        throw new Exception("Не найдено действие");
                }
                LinearGradientBrush gradient = new LinearGradientBrush();
                gradient.StartPoint = new Point(0, 0.5);
                gradient.EndPoint = new Point(1, 0.5);
                GradientStop greenStop = new GradientStop();
                greenStop.Color = Color.FromArgb(255, 128, 255, 0);
                greenStop.Offset = greenOffset - 0.05;
                gradient.GradientStops.Add(greenStop);

                GradientStop redStop = new GradientStop();
                redStop.Color = Colors.Red;
                redStop.Offset = greenOffset + 0.05;
                gradient.GradientStops.Add(redStop);
                return gradient;
            }
            else
            {
                SolidColorBrush brush = new SolidColorBrush(Colors.Black);
                return brush;
            }
        }
    }
}
