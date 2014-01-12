using GamePlugin.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GamePlugin
{
    public partial class Playground : UserControl, IEntity
    {
        public Player selectedPlayer;
        public Playground()
        {
            InitializeComponent();
            this.Loaded += Playground_Loaded;
        }

        public string GetMetadata()
        {
            throw new NotImplementedException();
        }

        public void ClearSelectedPlayer()
        {
            this.selectedPlayer.PlayerEllipse.Fill = selectedPlayer.solidColorBrush;
            if (this.selectedPlayer.actionList.CheckActionView.Visibility == Visibility.Visible)
                this.selectedPlayer.actionList.Visibility = Visibility.Collapsed;
            this.selectedPlayer = null;
        }

        void Playground_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new GameServiceClient();
            client.GetStartMetadataCompleted += client_GetStartMetadataCompleted;
            client.GetStartMetadataAsync(GameEnvironment.gameId, GameEnvironment.userId);
        }

        void client_GetStartMetadataCompleted(object sender, GetStartMetadataCompletedEventArgs e)
        {
            Metadata metaObject = ServiceHelper.GetTypedObjectFromJson<Metadata>(e.Result);
            if (metaObject.Players.Any<PlayerMetadata>())
            {
                foreach (var playerItem in metaObject.Players)
                {
                    Player player = new Player(this, playerItem);
                    Canvas.SetLeft(player, playerItem.Left);
                    Canvas.SetTop(player, playerItem.Top);
                    this.PlaygroundCanvas.Children.Add(player);
                }
            }
        }

        private void PlaygroundCanvas_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (selectedPlayer != null)
            {
                if (selectedPlayer.arrow != null)
                    this.PlaygroundCanvas.Children.Remove(selectedPlayer.arrow);
                Arrow arrow = new Arrow(e.GetPosition(this), selectedPlayer);
                selectedPlayer.arrow = arrow;
                this.PlaygroundCanvas.Children.Add(arrow);
            }
        }

        private void PlaygroundCanvas_MouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            ClearSelectedPlayer();
            e.Handled = true;
        }
    }
}
