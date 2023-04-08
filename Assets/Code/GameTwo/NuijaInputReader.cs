using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace WineCrafter
{
    public class NuijaInputReader : MonoBehaviour
    {

        private const float targetoffset = 0.01f;
        private Vector3 worldTouchPosition;
        private Vector3 direction;
        private Vector3 targetPosition;
        private Rigidbody2D rb;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private Vector3 offset = Vector3.zero;
        Animator nuijaAnim;

        //bool to trigger animation and prevent from pressing continuously
        private bool fingerPressed = false;
        private bool mashAnimation = true;


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

                

                worldTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                worldTouchPosition.z = 0;
                targetPosition = worldTouchPosition + offset;
                direction = targetPosition - transform.position; ;
                rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;



                // when  starting a touch set booleans to true to begin  animation
                if (touch.phase== UnityEngine.TouchPhase.Began)
                {
                    fingerPressed= true;
                    mashAnimation = true;
                }

                //when finger is lifter set fingerpress to false
                else if (touch.phase == UnityEngine.TouchPhase.Ended)
                {
                    fingerPressed= false;
                    rb.velocity = Vector2.zero;
                }

            }

            //if screen not touched set boolean to false
            else
            {
                fingerPressed= false;
                rb.velocity= Vector2.zero;
            }

            // if finger is pressed on the screen and animation boolean is true, trigger the animation
            //disable another animation until finger no longer touches the screen
            if ( fingerPressed && mashAnimation)
            {
                nuijaAnim.Play("ALTNuija");
                mashAnimation = false;
                
            }

            // when finger is not pressed, set the animation boolean to true to wait for another animation
            else if (!fingerPressed) 
            {
                mashAnimation = true;
            }
        }
    }
}
