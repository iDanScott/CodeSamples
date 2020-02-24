using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Core.Renderers.Console
{
    public class ConsoleSnakeRenderer : ISnakeRenderer
    {
        public void DrawSnake(ISnake snake)
        {
            foreach(var part in snake.BodyParts)
            {
                if (part == snake.Tail)
                {
                    System.Console.SetCursorPosition(part.PreviousLocation.X, part.PreviousLocation.Y);
                    System.Console.Write(" ");
                }

                System.Console.SetCursorPosition(part.Location.X, part.Location.Y);

                if (part == snake.Head)
                {
                    System.Console.Write("O");
                }
                else
                {
                    System.Console.Write("o");
                }
            }
        }

        public void DrawFood(Food food)
        {
            System.Console.SetCursorPosition(food.Location.X, food.Location.Y);
            System.Console.Write("Ó");
        }
    }
}
