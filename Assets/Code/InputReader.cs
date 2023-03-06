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


        /* public void OnTabMove (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Vector2 touchPosition = context.ReadValue<Vector2>();
                 Vector3 screenCoordinate = new Vector3(touchPosition.x, touchPosition.y, 0);

                // Vaihtoehtoinen tapa ilmaista ylempi rivi
                Vector3 screenCoordinate = touchPosition;

                this.worldTouchPosition = Camera.main.ScreenToWorldPoint(screenCoordinate);


            }
        }

        public Vector2 GetMoveInput()
        {
            Vector2 toTarget = (Vector3)(worldTouchPosition - transform.position);

            if (toTarget.magnitude > targetoffset)
            {
                //Kohde saavutettu
                return Vector2.zero;
            }

            return toTarget.normalized;

        } */


    }
}

