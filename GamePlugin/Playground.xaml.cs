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
        public ActionList selectedActionList;
        public Playground()
        {
            InitializeComponent();
            this.Loaded += Playground_Loaded;
        }

        public string GetMetadata()
        {
            throw new NotImplementedException();
        }

        public bool SetMetadata(string metadata)
        {
            Metadata metaObject = ServiceHelper.GetTypedObjectFromJson<Metadata>(metadata);
            if (metaObject.Players.Any<PlayerMetadata>())
            {
                foreach (var playerItem in metaObject.Players)
                {
                    Player player = new Player(this, playerItem.SolidColor, playerItem.IsOpponent);
                    Canvas.SetLeft(player, playerItem.Left);
                    Canvas.SetTop(player, playerItem.Top);
                    this.PlaygroundCanvas.Children.Add(player);
                }
            }
            return true;

        }

        void Playground_Loaded(object sender, RoutedEventArgs e)
        {
            var client = new GameServiceClient();
            client.GetStartMetadataCompleted += client_GetStartMetadataCompleted;
            client.GetStartMetadataAsync(GameEnvironment.gameId, GameEnvironment.userId);
        }

        void client_GetStartMetadataCompleted(object sender, GetStartMetadataCompletedEventArgs e)
        {
            SetMetadata(e.Result);
        }
    }
}
