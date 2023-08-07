using Tetraizor.Data;
using Tetraizor.Utils;
using UnityEngine;

namespace Tetraizor.Entity
{
    public class Humanoid : EntityBase
    {
        #region Properties

        private HumanoidRendererController _humanoidRendererController;
        private GameObject _humanoidRenderer;

        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();

            _humanoidRendererController = GetComponentInChildren<HumanoidRendererController>();
            _humanoidRenderer = _humanoidRendererController.gameObject;
        }

        #endregion

        #region Inherited Methods

        protected override void Move(Vector2 moveVector)
        {
            base.Move(moveVector);

            _humanoidRendererController.SetAnimationParameters((moveVector).magnitude);
        }
        
        public override void SetPosition(Vector2 position)
        {
            Vector2 moveVector = (Vector2)transform.position - position;
            
            base.SetPosition(position);

            _humanoidRendererController.SetAnimationParameters((moveVector).magnitude / Time.deltaTime);
        }
        
        private void Look(float lookDirection)
        {
            _humanoidRendererController.SetLookRotation(lookDirection);
        }

        protected void ProcessMovementData(EntityMovementData entityMovementData)
        {
            SetPosition(entityMovementData.GetPosition());
            Look(entityMovementData.GetRotation());
        }
        
        #endregion
    }
}