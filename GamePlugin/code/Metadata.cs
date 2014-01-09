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
        public string SolidColor { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public bool IsOpponent { get; set; }
    }
}
