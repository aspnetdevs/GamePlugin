using System;
using System.Collections.Generic;
using System.Net;
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
    public class Metadata
    {
        public IEnumerable<PlayerMetadata> Players { get; set; }
    }

    public class PlayerMetadata
    {
        public Guid Tag { get; set; }
        public string SolidColor { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public bool IsOpponent { get; set; }
        public byte Run { get; set; }
        public byte ShortPass { get; set; }
        public byte LongPass { get; set; }
        public byte Shoot { get; set; }
        public byte ShortPassAccuracy { get; set; }
        public byte LongPassAccuracy { get; set; }
        public byte ShootAccuracy { get; set; }
        public byte Power { get; set; }
        public byte Speed { get; set; }
        public byte Stamina { get; set; }
        public byte BodyBalance { get; set; }
        public byte BallControl { get; set; }
    }
}
