using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WineCrafter
{
    public class InputReader : MonoBehaviour
    {

        private const float targetoffset = 0.01f;
        // probably wont need this just now 

        private Vector3 worldTouchPosition;
        private Vector3 direction;
        private Rigidbody2D rb;
        [SerializeField] private float moveSpeed = 10f;

        

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                worldTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                worldTouchPosition.z = 0;
                direction = worldTouchPosition - transform.position;
                rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

                if (touch.phase == UnityEngine.TouchPhase.Ended)
                {
                    rb.velocity = Vector2.zero;
                }

            }
        }
    }
}



