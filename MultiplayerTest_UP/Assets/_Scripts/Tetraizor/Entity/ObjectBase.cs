using System;
using UnityEngine;

namespace Tetraizor.Entity
{
    public abstract class ObjectBase : MonoBehaviour
    {
        #region Unity Methods

        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
        }

        #endregion

        #region Public Methods

        public virtual void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        #endregion
    }
}