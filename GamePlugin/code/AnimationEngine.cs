using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GamePlugin
{
    public class AnimationEngine
    {
        public static bool IsAnimationStarted { get; private set; }
        private Storyboard _storyboard;
        public AnimationEngine()
        {
            _storyboard = new Storyboard();
            //Настроить правильную длительность
            //_storyboard.Duration = new Duration(TimeSpan.FromSeconds(5));
        }

        public void AddRunAnimation(DependencyObject dependencyObject, Point moveTo)
        {
            DoubleAnimation leftDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTarget(leftDoubleAnimation, dependencyObject);
            Storyboard.SetTargetProperty(leftDoubleAnimation, new PropertyPath("(Canvas.Left)"));
            leftDoubleAnimation.To = moveTo.X;
            _storyboard.Children.Add(leftDoubleAnimation);

            DoubleAnimation topDoubleAnimation = new DoubleAnimation();
            Storyboard.SetTarget(topDoubleAnimation, dependencyObject);
            Storyboard.SetTargetProperty(topDoubleAnimation, new PropertyPath("(Canvas.Top)"));
            topDoubleAnimation.To = moveTo.Y;
            _storyboard.Children.Add(topDoubleAnimation);
        }
        public void Execute()
        {
            IsAnimationStarted = true;
            _storyboard.Completed += _storyboard_Completed;
            _storyboard.Begin();
        }

        void _storyboard_Completed(object sender, EventArgs e)
        {
            IsAnimationStarted = false;
        }

        public static bool CheckCollision(FrameworkElement control1, FrameworkElement controlElem1, FrameworkElement control2, FrameworkElement controlElem2)
        {
            Rect rect1 = UserControlBounds(control1);
            Rect rect2 = UserControlBounds(control2);

            rect1.Intersect(rect2);
            if (rect1 == Rect.Empty)
            {
                return false;
            }
            else
            {
                bool bCollision = false;
                Point ptCheck = new Point();

                for (int x = Convert.ToInt32(rect1.X); x < Convert.ToInt32(rect1.X + rect1.Width); x++)
                {
                    for (int y = Convert.ToInt32(rect1.Y); y < Convert.ToInt32(rect1.Y + rect1.Height); y++)
                    {
                        ptCheck.X = x;
                        ptCheck.Y = y;


                        if (CheckCollisionPoint(ptCheck, control1, controlElem1))
                            if (CheckCollisionPoint(ptCheck, control2, controlElem2))
                            {
                                bCollision = true;
                                break;
                            }

                    }
                    if (bCollision) break;
                }
                return bCollision;
            }
        }
        private static bool CheckCollisionPoint(Point pt, FrameworkElement control, FrameworkElement controlElem)
        {
            List<UIElement> hits = System.Windows.Media.VisualTreeHelper.FindElementsInHostCoordinates(pt, controlElem) as List<UIElement>;
            return (hits.Contains(controlElem));
        }
        private static Rect UserControlBounds(FrameworkElement control)
        {
            Point ptTopLeft = new Point(Convert.ToDouble(control.GetValue(Canvas.LeftProperty)), Convert.ToDouble(control.GetValue(Canvas.TopProperty)));
            Point ptBottomRight = new Point(Convert.ToDouble(control.GetValue(Canvas.LeftProperty)) + control.ActualWidth, Convert.ToDouble(control.GetValue(Canvas.TopProperty)) + control.ActualHeight);

            return new Rect(ptTopLeft, ptBottomRight);
        }

    }
}
