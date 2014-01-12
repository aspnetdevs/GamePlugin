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
    public partial class ActionList : UserControl
    {
        Player player;
        public string selectedAction;
        public ActionList(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.ActionListBox.SelectedIndex != -1)
            {
                ListBoxItem selectedItem = (ListBoxItem)this.ActionListBox.SelectedItem;
                selectedAction = selectedItem.Name;
                this.CheckedActionCaption.Text = selectedItem.Content.ToString();
                TransformView();
            }
        }

        private void CheckedActionCaption_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            selectedAction = null;
            player.playground.SelectedPlayer = player;
            TransformView();
            e.Handled = true;
        }
        private void TransformView()
        {
            this.CheckActionView.Visibility = this.CheckActionView.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            this.CheckedActionCaption.Visibility = this.CheckedActionCaption.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        
    }
}
