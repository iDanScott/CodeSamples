using System.Collections.Generic;

namespace Snake.Core
{
    public interface ISnake
    {
        int Length { get; }
        Direction Facing { get; }
        List<BodyPart> BodyParts { get; }
        BodyPart Head { get; }
        BodyPart Tail { get; }
        void Move();
        void Grow();
        void ChangeDirection(Direction direction);
    }
}
