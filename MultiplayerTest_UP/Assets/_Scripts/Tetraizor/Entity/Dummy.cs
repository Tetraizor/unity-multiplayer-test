using System.Collections;
using Tetraizor.Data;
using UnityEngine;

namespace Tetraizor.Entity
{
    public class Dummy : Humanoid
    {
        protected override void Start()
        {
            StartCoroutine(ExampleMovement());
        }

        private IEnumerator ExampleMovement()
        {
            float timer = 0;

            while (true)
            {
                while (timer < 10)
                {
                    Vector2 targetPosition = new Vector2(
                        Mathf.Sin(Mathf.PI * timer * .2f),
                        Mathf.Cos(Mathf.PI * timer * .2f)
                        ) * 5;
                    ProcessMovementData(new EntityMovementData(targetPosition, timer * 36));
                    
                    timer += Time.deltaTime;
                    yield return null;
                }
                
                timer = 0;
            }
        }
    }
}