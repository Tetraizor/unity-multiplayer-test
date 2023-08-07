using UnityEngine;

namespace Tetraizor.Data
{
    public readonly struct EntityMovementData
    {
        private readonly short _zRotation;
        private readonly short _xPosition;
        private readonly short _yPosition;

        public EntityMovementData(Vector2 playerPosition, float playerRotation)
        {
            _zRotation = (short)(playerRotation * 100);
            
            _xPosition = (short)(playerPosition.x * 1000);
            _yPosition = (short)(playerPosition.y * 1000);
        }

        public float GetRotation()
        {
            return ((float)_zRotation) / 100;
        }
        
        public Vector2 GetPosition()
        {
            return new Vector2(_xPosition, _yPosition) / 1000;
        }
    }
}