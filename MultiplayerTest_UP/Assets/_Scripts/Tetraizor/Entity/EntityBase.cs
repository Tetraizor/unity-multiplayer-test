using UnityEngine;

namespace Tetraizor.Entity
{
    public abstract class EntityBase : ObjectBase
    {
        #region Inherited Methods

        protected virtual void Move(Vector2 moveVector)
        {
            transform.position += (Vector3)moveVector;
        }

        #endregion
    }
}