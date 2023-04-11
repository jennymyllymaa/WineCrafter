using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WineCrafter
{
    public class GravityIncrease : MonoBehaviour
    {
        public float initialGravityScale = 10f;
        private Rigidbody2D rb2D;

        public float gravityMultiplier = 1.1f;
        public float timeInterval = 1f;
        public float fixedTimeStep = 0.02f; // 50 FPS

        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = initialGravityScale;
        }

        void FixedUpdate()
        {
            Time.fixedDeltaTime = fixedTimeStep;

            rb2D.gravityScale *= gravityMultiplier * (fixedTimeStep / timeInterval);
        }
    }
}
