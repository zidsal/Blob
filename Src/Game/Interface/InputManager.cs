using Microsoft.Xna.Framework.Input;

namespace Game.Interface
{
    public class InputManager
    {
        private KeyboardState _previousKey;
        private KeyboardState _currentKey;

        public void Update(KeyboardState currentKey)
        {
            _currentKey = currentKey;

            if (_currentKey.IsKeyDown(KeyBinds.Key.MoveUp))
            {
            }
            else if (_currentKey.IsKeyDown(KeyBinds.Key.MoveRight))
            {
            }
            else if (_currentKey.IsKeyDown(KeyBinds.Key.MoveDown))
            {
            }
            else if (_currentKey.IsKeyDown(KeyBinds.Key.MoveLeft))
            {
            }

            _previousKey = _currentKey;
        }
    }
}
