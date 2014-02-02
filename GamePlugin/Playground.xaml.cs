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
        private Metadata metadata;
        private IMoveMetadata moveMetadata;
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
                    //Вынести создание элементов в отдельный метод, который создает любой тип элементов.
                    //Либо сделать как отельный блок
                    if (value.powerSlider == null)
                    {
                        PowerSlider powerSlider = new PowerSlider(value);
                        Canvas.SetLeft(powerSlider, Canvas.GetLeft(value) - powerSlider.slider.Width - 10);
                        Canvas.SetTop(powerSlider, Canvas.GetTop(value));
                        this.PlaygroundCanvas.Children.Add(powerSlider);
                        value.powerSlider = powerSlider;
                    }
                    else
                        value.powerSlider.Visibility = Visibility.Visible;
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
                        this._selectedPlayer.powerSlider.Visibility = Visibility.Collapsed;
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

        #region Обработка событий Playground
        void Playground_Loaded(object sender, RoutedEventArgs e)
        {

            GameServiceClient client = new GameServiceClient();
            client.GetStartMetadataCompleted += client_GetStartMetadataCompleted;
            client.GetStartMetadataAsync(GameEnvironment.gameId, GameEnvironment.userId);
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
            moveMetadata = GetMetadata();
            GameServiceClient client = new GameServiceClient();
            client.SetMoveMetadataCompleted += client_SetMoveMetadataCompleted;
            client.SetMoveMetadataAsync(GameEnvironment.gameId, GameEnvironment.userId, ServiceHelper.GetJsonStringFromObject<IMoveMetadata>(moveMetadata), GameEnvironment.currentMoveNumber);
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            CheckEntityCollision();
        }
        #endregion

        #region Ответы от сервиса
        void client_GetStartMetadataCompleted(object sender, GetStartMetadataCompletedEventArgs e)
        {
            Metadata metaObject = metadata = ServiceHelper.GetTypedObjectFromJson<Metadata>(e.Result);
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
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        void client_SetMoveMetadataCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            HtmlPage.Window.Invoke("checkEndOpponentMove");
        }

        void client_GetMoveMetadataCompleted(object sender, GetMoveMetadataCompletedEventArgs e)
        {
            MoveMetadata playerMoveMetadata = ServiceHelper.GetTypedObjectFromJson<MoveMetadata>(e.Result);
            AnimationEngine animation = new AnimationEngine();
            foreach (PlayerMoveMetadata opponentMoveMetadata in playerMoveMetadata.Players)
            {

                Player player = GetPlayerByTagName(opponentMoveMetadata.Tag);
                animation.AddRunAnimation(player, opponentMoveMetadata.MoveTo);
            }
            foreach (PlayerMoveMetadata userMoveMetadata in ((MoveMetadata)moveMetadata).Players)
            {
                Player player = GetPlayerByTagName(userMoveMetadata.Tag);
                animation.AddRunAnimation(player, userMoveMetadata.MoveTo);
                player.UpdateAfterMove(userMoveMetadata);
            }
            animation.Execute();
        }
        #endregion

        #region Дополнительные методы
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

        private Player GetPlayerByTagName(string tagName)
        {
            foreach (UIElement element in this.PlaygroundCanvas.Children)
            {
                Player player = element as Player;
                if (player != null && player.metadata.Tag == tagName)
                {
                    return player;
                }
            }
            throw new Exception(string.Format("Элемент с идентификатором {0} не найден", tagName));
        }

        private void CheckEntityCollision()
        {
            if (AnimationEngine.IsAnimationStarted)
            {
                EndMove.Content = 0;
                for (int i = 0; i < metadata.Players.Count - 1; i++)
                {
                    Player firstPlayer = GetPlayerByTagName(metadata.Players[i].Tag);
                    for (int j = i + 1; j < metadata.Players.Count; j++)
                    {
                        Player secondPlayer = GetPlayerByTagName(metadata.Players[j].Tag);
                        if (AnimationEngine.CheckCollision(firstPlayer, firstPlayer.PlayerEllipse, secondPlayer, secondPlayer.PlayerEllipse))
                            EndMove.Content = Convert.ToInt32(EndMove.Content) + 1;
                    }
                }
            }
        }
        
        #endregion

        #region Scriptable члены
        [ScriptableMember]
        public void GetMoveMetadata()
        {
            GameServiceClient client = new GameServiceClient();
            client.GetMoveMetadataCompleted += client_GetMoveMetadataCompleted;
            client.GetMoveMetadataAsync(GameEnvironment.gameId, GameEnvironment.userId);
            GameEnvironment.currentMoveNumber++;
        }
        #endregion


    }
}


