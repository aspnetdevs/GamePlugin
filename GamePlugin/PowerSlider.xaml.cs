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
    public partial class PowerSlider : UserControl
    {
        Player player;
        public PowerSlider(Player player)
        {
            this.player = player;
            InitializeComponent();
        }

        private void slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (player.arrow != null)
                player.arrow.UpdateArrow();
        }
    }
}
