using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WineCrafter
{
    public class GravityIncrease : MonoBehaviour
    {
        private Rigidbody2D rb2D;

        GameObject canvas;
        IncreasingGravity increasingGravity;

        void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            canvas = GameObject.Find("Canvas");
            increasingGravity=canvas.GetComponent<IncreasingGravity>();


            rb2D.gravityScale = increasingGravity.GetGravityMultiplier();
                
        }

    }
}
