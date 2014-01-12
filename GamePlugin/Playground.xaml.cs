using GamePlugin.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Browser;
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
        private Player _selectedPlayer;
        public Player SelectedPlayer
        {
            get
            {
                return _selectedPlayer;
            }
            set
            {
                if (value != null)
                {
                    this.SelectedPlayer = null;
                    if (value.actionList == null)
                    {
                        ActionList actions = new ActionList(value);
                        Canvas.SetLeft(actions, Canvas.GetLeft(value) + value.ActualWidth + 10);
                        Canvas.SetTop(actions, Canvas.GetTop(value));
                        this.PlaygroundCanvas.Children.Add(actions);
                        value.actionList = actions;
                    }
                    else
                        value.actionList.Visibility = Visibility.Visible;
                    value.PlayerEllipse.Fill = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (this._selectedPlayer != null)
                    {
                        this._selectedPlayer.PlayerEllipse.Fill = _selectedPlayer.solidColorBrush;
                        if (this._selectedPlayer.actionList.CheckActionView.Visibility == Visibility.Visible)
                            this._selectedPlayer.actionList.Visibility = Visibility.Collapsed;
                    }
                }
                this._selectedPlayer = value;
            }
        }
        public Playground()
        {
            InitializeComponent();
            this.Loaded += Playground_Loaded;
        }

        void Playground_Loaded(object sender, RoutedEventArgs e)
        {
            GameServiceClient client = new GameServiceClient();
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
            if (_selectedPlayer != null)
            {
                if (_selectedPlayer.arrow != null)
                    this.PlaygroundCanvas.Children.Remove(_selectedPlayer.arrow);
                Arrow arrow = new Arrow(e.GetPosition(this), _selectedPlayer);
                _selectedPlayer.arrow = arrow;
                this.PlaygroundCanvas.Children.Add(arrow);
            }
        }

        private void PlaygroundCanvas_MouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.SelectedPlayer = null;
            e.Handled = true;
        }

        private void EndMove_Click_1(object sender, RoutedEventArgs e)
        {
            IMoveMetadata moveMetadata = GetMetadata();
            GameServiceClient client = new GameServiceClient();
            client.SetMoveMetadataCompleted += client_SetMoveMetadataCompleted;
            client.SetMoveMetadataAsync(GameEnvironment.gameId, GameEnvironment.userId, ServiceHelper.GetJsonStringFromObject<IMoveMetadata>(moveMetadata), GameEnvironment.currentMoveNumber);
        }

        void client_SetMoveMetadataCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            HtmlPage.Window.Invoke("checkEndOpponentMove");
        }

        public IMoveMetadata GetMetadata()
        {
            MoveMetadata moveMetadata = new MoveMetadata();
            foreach (Player item in this.PlaygroundCanvas.Children.OfType<Player>())
            {
                if (!item.metadata.IsOpponent)
                {
                    IMoveMetadata playerMetadata = item.GetMetadata();
                    if (playerMetadata != null)
                        moveMetadata.Players.Add(playerMetadata);
                }

            }
            return moveMetadata;
        }

        [ScriptableMember]
        public void GetMoveMetadata()
        {
            GameEnvironment.currentMoveNumber++;
        }
    }
}
