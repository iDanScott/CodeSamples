using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake.Core
{
    public class Snake : ISnake
    {
        private Direction _facing = Direction.Right;
        private List<Direction> _turnQueue = new List<Direction>();

        public Snake()
        {
            _facing = Direction.Right;
            Head = new BodyPart(new Location(2, 0));
            Tail = new BodyPart(new Location(0, 0));
            BodyParts = new List<BodyPart>() { Head, new BodyPart(new Location(1, 0)), Tail };
        }

        public BodyPart Head { get; private set; }
        public BodyPart Tail { get; private set; }

        public int Length => BodyParts.Count;

        public Direction Facing => _facing;

        public List<BodyPart> BodyParts { get; private set; }

        public void Grow()
        {
            BodyParts.Insert(BodyParts.IndexOf(Tail) - 1, new BodyPart(Tail.Location));
        }

        public void Move()
        {
            if (_facing == Direction.Left)
            {
                Head.ChangeLocation(new Location(Head.Location.X - 1, Head.Location.Y));
            }
            else if (_facing == Direction.Down)
            {
                Head.ChangeLocation(new Location(Head.Location.X, Head.Location.Y + 1));
            }
            else if (_facing == Direction.Right)
            {
                Head.ChangeLocation(new Location(Head.Location.X + 1, Head.Location.Y));
            }
            else if (_facing == Direction.Up)
            {
                Head.ChangeLocation(new Location(Head.Location.X, Head.Location.Y - 1));
            }

            if (_turnQueue.Count() > 0)
            {
                _facing = _turnQueue.First();
                _turnQueue = _turnQueue.Where(x => _turnQueue.IndexOf(x) != 0).ToList();
            }

            for (var i = 1; i < BodyParts.Count(); i++)
            {
                BodyParts[i].ChangeLocation(BodyParts[i - 1].PreviousLocation);
            }

        }

        public void ChangeDirection(Direction direction)
        {
            var checkDirection = _turnQueue.Count() > 0 ? _turnQueue.Last() : _facing;
            if (checkDirection == Direction.Up && direction == Direction.Down || checkDirection == Direction.Down && direction == Direction.Up ||
                checkDirection == Direction.Left && direction == Direction.Right || checkDirection == Direction.Right && direction == Direction.Left)
            {
                throw new ArgumentException("You cannot have a snake that goes back on itself.", nameof(direction));
            }

            _turnQueue.Add(direction);
        }
    }
}
