using Snake.Core.Renderers;
using Snake.Core.Renderers.Console;
using Snake.Core.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Snake.Core
{
    public class Game
    {
        private ISnakeRenderer _snakeRenderer;
        private bool _gameOver => _snake.BodyParts
            .Where(x => x != _snake.Head)
            .Any(x => x.Location.X == _snake.Head.Location.X && x.Location.Y == _snake.Head.Location.Y);

        private ISnake _snake;
        private Timer _gameTime;
        private long _gameTicks = 0;
        private Food _food;

        public Game(ISnakeRenderer snakeRenderer, ISnake snake)
        {
            _snakeRenderer = snakeRenderer;
            _snake = snake;
            _food = new Food(new Location(new Random().Next(0, 80), new Random().Next(0, 25)));
        }

        public virtual void OnDirectionChanged(DirectionChangedEventArgs e)
        {
            _snake.ChangeDirection(e.Direction);
        }

        public void Start()
        {
            _gameTime = new Timer(1000 / 60);
            _gameTime.Elapsed += _gameTime_Elapsed;
            _gameTime.Start();
        }

        private void _gameTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!_gameOver)
            {
                _gameTicks++;
                if (_gameTicks % 10 == 0)
                {
                    _snake.Move();
                    if (_snake.Head.Location.X == _food.Location.X && _snake.Head.Location.Y == _food.Location.Y)
                    {
                        _food.ChangeLocation(new Location(new Random().Next(0, 80), new Random().Next(0, 25)));
                        _snake.Grow();
                    }
                    _snakeRenderer.DrawSnake(_snake);
                    _snakeRenderer.DrawFood(_food);
                }
            }
            else
            {

            }
        }
    }
}
