using System;
using System.Collections;
using System.Collections.Generic;
using Tetraizor.Utils;
using UnityEngine;

namespace Tetraizor.Entity
{
    public class HumanoidRendererController : MonoBehaviour
    {
        #region Properties

        [Header("Hand-assigned References")] [SerializeField]
        private Transform _headTransform;

        private Animator _humanoidAnimator;

        private static readonly int WalkSpeed = Animator.StringToHash("WalkSpeed");
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        private readonly ValueDeltaChecker<bool> _lookDirectionDelta = new();

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _humanoidAnimator = gameObject.GetComponent<Animator>();
            _lookDirectionDelta.BindOnValueChangeEvent(OnDirectionChanged);
        }

        #endregion

        #region Inherited Methods

        public void SetAnimationParameters(float speed)
        {
            _humanoidAnimator.SetFloat(WalkSpeed, speed);
            _humanoidAnimator.SetBool(IsWalking, speed > .1f);
        }

        public void SetLookRotation(float lookRotation)
        {
            bool isLookingRight = lookRotation is < 90 and > -90;
            _lookDirectionDelta.UpdateValue(isLookingRight);

            var localEulerAngles = _headTransform.localEulerAngles;
            
            // Set head rotation. Depending on which way the humanoid is facing,
            // calculations are different.
            localEulerAngles = new Vector3(
                localEulerAngles.x,
                localEulerAngles.y,
                Mathf.Clamp(isLookingRight ? lookRotation : ((lookRotation > 0 ? 1 : -1) * 180 - lookRotation), -45, 45)
            );

            _headTransform.localEulerAngles = localEulerAngles;
        }

        protected virtual void OnDirectionChanged(bool currentDirection, bool oldDirection)
        {
            transform.localScale = new Vector3(currentDirection ? 1 : -1, 1, 1);
        }

        #endregion
    }
}