using System;
using Game.Entities;
using Microsoft.Xna.Framework.Input;

namespace Game.Interface
{
    public class InputManager
    {
        private KeyboardState _previousKey;
        private KeyboardState _currentKey;
        private readonly Player _player;

        public InputManager(Player player)
        {
            _player = player;
        }

        public void Update(KeyboardState currentKey)
        {
            _currentKey = currentKey;

            if (_currentKey.IsKeyDown(KeyBinds.Key.MoveUp))
            {
                _player.MoveDown(-1);
            }
            else if (_currentKey.IsKeyDown(KeyBinds.Key.MoveRight))
            {
                _player.MoveRight(1);
            }
            else if (_currentKey.IsKeyDown(KeyBinds.Key.MoveDown))
            {
                _player.MoveDown(1);
            }
            else if (_currentKey.IsKeyDown(KeyBinds.Key.MoveLeft))
            {
                _player.MoveRight(-1);
            }

            _previousKey = _currentKey;
        }
    }
}
