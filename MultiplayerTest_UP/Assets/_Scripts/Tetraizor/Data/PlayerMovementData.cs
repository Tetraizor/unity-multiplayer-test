using UnityEngine;

namespace Tetraizor.Data
{
    public readonly struct PlayerMovementData
    {
        private readonly short _playerRotation;
        private readonly short _playerPositionX;
        private readonly short _playerPositionY;

        public PlayerMovementData(Vector2 playerPosition, float playerRotation)
        {
            _playerRotation = (short)(playerRotation * 100);
            _playerPositionX = (short)(playerPosition.x * 1000);
            _playerPositionY = (short)(playerPosition.y * 1000);
        }

        public float GetRotation()
        {
            return ((float)_playerRotation) / 100;
        }
        
        public Vector2 GetPosition()
        {
            return new Vector2(_playerPositionX, _playerPositionY) / 1000;
        }
    }
}