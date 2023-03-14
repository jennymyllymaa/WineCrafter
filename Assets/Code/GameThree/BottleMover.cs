using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{

    public class BottleMover : MonoBehaviour
    {

        [SerializeField] private Vector2 velocity;
        private Rigidbody2D rb2D;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        // Start is called before the first frame update
        void Start()
        {
            velocity = new Vector2(1.75f, 0);

            // transform.position = new Vector3(-2.0f, 0, 0.0f);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        }
    }

}
