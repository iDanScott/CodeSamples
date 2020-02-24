using Snake.Core;
using Snake.Core.Renderers.Console;
using Snake.Core.UserInput;
using System;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {

        static void Main(string[] args)
        {

            var game = new Game(new ConsoleSnakeRenderer(), new Core.Snake());
            
            var gameTask = new Task(() => game.Start());
            gameTask.Start();

            while(true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
                {
                    game.OnDirectionChanged(new DirectionChangedEventArgs(Direction.Left));
                }
                if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    game.OnDirectionChanged(new DirectionChangedEventArgs(Direction.Down));
                }
                if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
                {
                    game.OnDirectionChanged(new DirectionChangedEventArgs(Direction.Right));
                }
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    game.OnDirectionChanged(new DirectionChangedEventArgs(Direction.Up));
                }
            }
        }
    }
}
