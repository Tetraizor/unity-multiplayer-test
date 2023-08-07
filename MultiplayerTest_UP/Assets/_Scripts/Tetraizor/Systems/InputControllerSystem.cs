using System;
using Tetraizor.Singleton;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tetraizor.Systems
{
    public class InputControllerSystem : MonoSingleton<InputControllerSystem>
    {
        #region Propreties

        [SerializeField] private PlayerInput _playerInput;

        [HideInInspector] public InputAction MoveAction;
        [HideInInspector] public InputAction PrimaryAction;
        [HideInInspector] public InputAction SecondaryAction;
        [HideInInspector] public InputAction RunAction;

        #endregion

        #region Inherited Methods

        protected override void Init()
        {
            _playerInput = gameObject.GetComponent<PlayerInput>();

            RunAction = _playerInput.actions["Run"];
            MoveAction = _playerInput.actions["MoveAxis"];
            PrimaryAction = _playerInput.actions["PrimaryAction"];
            SecondaryAction = _playerInput.actions["SecondaryAction"];
        }

        #endregion
    }
}