using System.Linq;

namespace Snake.Core.Renderers.Console
{
    public class ConsoleSnakeRenderer : ISnakeRenderer
    {
        public void DrawSnake(ISnake snake)
        {
            foreach(var part in snake.BodyParts)
            {
                if (part == snake.BodyParts.Last())
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

        public void GameOver(int score)
        {
            System.Console.Clear();
            System.Console.SetCursorPosition(20, 10);
            System.Console.Write($"Game Over. Your score was: {score}");
        }
    }
}
