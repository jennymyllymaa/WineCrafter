using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WineCrafter
{
    public class NuijaInputReader : MonoBehaviour
    {

        private const float targetoffset = 0.01f;
        // probably wont need this just now 

        private Vector3 worldTouchPosition;
        private Vector3 direction;
        private Vector3 targetPosition;
        private Rigidbody2D rb;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private Vector3 offset = Vector3.zero;
        Animator nuijaAnim;



        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            nuijaAnim = GetComponent<Animator>();
        }


        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                nuijaAnim.Play("ALTNuija");

                worldTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                worldTouchPosition.z = 0;
                targetPosition = worldTouchPosition + offset;
                direction = targetPosition - transform.position; ;
                rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

                if (touch.phase == UnityEngine.TouchPhase.Ended)
                {
                    rb.velocity = Vector2.zero;
                }

            }
        }
    }
}
