using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core.UserInput
{
    public class DirectionChangedEventArgs : EventArgs
    {
        public DirectionChangedEventArgs(Direction direction)
        {
            Direction = direction;
        }

        public Direction Direction { get; private set; }
    }
}
