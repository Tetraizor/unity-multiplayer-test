using Tetraizor.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using Tetraizor.Systems;

namespace Tetraizor.Entity
{
    /// <summary>
    /// Class that controls everything related to the client side player. There
    /// should only be one of this class at a time. Other players should be
    /// instances of Humanoid based classes, and not depend on player input.
    /// </summary>
    public class PlayerController : Humanoid
    {
        #region Properties

        [SerializeField] private float _walkSpeed = 5;

        private InputAction _moveAxis;
        private InputAction _runAction;
        private InputAction _primaryAction;
        private InputAction _secondaryAction;

        private Camera _mainCamera; 
        #endregion

        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            
            // Initialization
            _mainCamera = Camera.main;
            
            // Key references
            _moveAxis = InputControllerSystem.Instance.MoveAction;
            _runAction = InputControllerSystem.Instance.RunAction;
            _primaryAction = InputControllerSystem.Instance.PrimaryAction;
            _secondaryAction = InputControllerSystem.Instance.SecondaryAction;
        }

        protected override void Update()
        {
            base.Update();
            
            // Save some variables.
            Vector2 playerPosition = transform.position;
            
            // Get direction from input.
            Vector2 movementDirection = _moveAxis.ReadValue<Vector2>();
            float finalSpeed = _walkSpeed * (_runAction.IsPressed() ? 2 : 1);
            
            // Calculate the look rotation.
            Vector2 lookDifferenceVector =
               (Vector2)(_mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector3)playerPosition);

            float lookDifferenceAngles =
                (Mathf.Atan2(lookDifferenceVector.y, lookDifferenceVector.x) * Mathf.Rad2Deg);

            // Move the humanoid.
            var playerMovementData = new EntityMovementData((Vector2)transform.position + (finalSpeed * Time.deltaTime * movementDirection), lookDifferenceAngles);
            ProcessMovementData(playerMovementData);
        }

        #endregion
    }
}