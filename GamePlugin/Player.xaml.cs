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
    public partial class Player : UserControl, IEntity
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
            {
                this.MouseLeftButtonDown += PlayerEllipse_MouseLeftButtonDown_1;
                this.Cursor = Cursors.Hand;
            }
        }


        private void PlayerEllipse_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            playground.SelectedPlayer = this;
            e.Handled = true;
        }

        public IMoveMetadata GetMetadata()
        {
            PlayerMoveMetadata playerMoveMetadata = null;
            if (this.actionList != null && this.actionList.selectedAction != null && this.arrow != null)
            {
                playerMoveMetadata = new PlayerMoveMetadata();
                playerMoveMetadata.ActionName = actionList.selectedAction;
                playerMoveMetadata.MoveTo = arrow.endPoint;
                playerMoveMetadata.Tag = (Guid)this.metadata.Tag;
            }
            return playerMoveMetadata;
        }
    }
}
