using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
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
    [DataContract]
    [KnownType(typeof(MoveMetadata))]
    public class MoveMetadata : IMoveMetadata
    {
        [DataMember]
        public List<IMoveMetadata> Players = new List<IMoveMetadata>();
    }
    [DataContract]
    [KnownType(typeof(PlayerMoveMetadata))]
    public class PlayerMoveMetadata : IMoveMetadata
    {
        [DataMember]
        public string Tag { get; set; }
        [DataMember]
        public string ActionName { get; set; }
        [DataMember]
        public Point MoveTo { get; set; }
    }

    public class Metadata
    {
        public List<PlayerMetadata> Players = new List<PlayerMetadata>();
    }

    public class PlayerMetadata
    {
        public string Tag { get; set; }
        public string SolidColor { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public bool IsOpponent { get; set; }
        public double Run { get; set; }
        public double ShortPass { get; set; }
        public double LongPass { get; set; }
        public double Shoot { get; set; }
        public double ShortPassAccuracy { get; set; }
        public double LongPassAccuracy { get; set; }
        public double ShootAccuracy { get; set; }
        public double Power { get; set; }
        public double Speed { get; set; }
        public double Stamina { get; set; }
        public double BodyBalance { get; set; }
        public double BallControl { get; set; }
    }
}
