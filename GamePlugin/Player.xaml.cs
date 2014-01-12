﻿using System;
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
        public Playground playground;
        public PlayerMetadata metadata;
        public SolidColorBrush solidColorBrush;
        public ActionList actionList;
        public Arrow arrow;
        public byte Power;
        public Player(Playground playground, PlayerMetadata metadata)
        {
            InitializeComponent();
            this.playground = playground;
            this.metadata = metadata;
            this.PlayerEllipse.Fill = solidColorBrush = new SolidColorBrush((Color)typeof(Colors).GetProperty(metadata.SolidColor).GetValue(null, null));
            if (!metadata.IsOpponent)
                this.MouseLeftButtonDown += PlayerEllipse_MouseLeftButtonDown_1;
        }

        private void PlayerEllipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

            if (playground.selectedPlayer != null)
            {
                playground.ClearSelectedPlayer();
            }
            if (this.actionList == null)
            {
                ActionList actions = new ActionList(this);
                Canvas.SetLeft(actions, Canvas.GetLeft(this) + this.ActualWidth + 10);
                Canvas.SetTop(actions, Canvas.GetTop(this));
                playground.PlaygroundCanvas.Children.Add(actions);
                this.actionList = actions;
            }
            else
                this.actionList.Visibility = Visibility.Visible;
            this.PlayerEllipse.Fill = new SolidColorBrush(Colors.Red);
            playground.selectedPlayer = this;
            e.Handled = true;
            //Здесь необходимо добавить слайдер силы
        }
    }
}
