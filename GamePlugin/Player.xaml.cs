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
    public partial class Player : UserControl
    {
        Playground playground;
        bool isOpponent;
        SolidColorBrush solidColorBrush;
        public Player(Playground playground, string solidColor, bool isOpponent)
        {
            InitializeComponent();
            this.playground = playground;
            this.isOpponent = isOpponent;
            this.PlayerEllipse.Fill = solidColorBrush = new SolidColorBrush((Color)typeof(Colors).GetProperty(solidColor).GetValue(null, null));
            if (!isOpponent)
                this.MouseLeftButtonDown += PlayerEllipse_MouseLeftButtonDown_1;
        }

        private void PlayerEllipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (playground.selectedPlayer != null)
            {
                playground.selectedPlayer.PlayerEllipse.Fill = new SolidColorBrush(Colors.Yellow);
                playground.PlaygroundCanvas.Children.Remove(playground.selectedActionList);
            }
            this.PlayerEllipse.Fill = new SolidColorBrush(Colors.Red);
            playground.selectedPlayer = this;

            ActionList actions = new ActionList();
            Canvas.SetLeft(actions, Canvas.GetLeft(this) + this.ActualWidth + 10);
            Canvas.SetTop(actions, Canvas.GetTop(this));
            playground.PlaygroundCanvas.Children.Add(actions);
            playground.selectedActionList = actions;
            //Здесь необходимо добавить слайдер силы
            
        }
    }
}
