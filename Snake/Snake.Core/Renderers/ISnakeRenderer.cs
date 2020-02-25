using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core.Renderers
{
    public interface ISnakeRenderer
    {
        void DrawSnake(ISnake snake);
        void DrawFood(Food food);
        void GameOver(int score);
    }
}
