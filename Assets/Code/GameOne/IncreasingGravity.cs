using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace WineCrafter
{
    public class IncreasingGravity : MonoBehaviour
    {
        [SerializeField] float initialGravityScale = 10f;
        float gravityScale;
        float gravityMultiplier = 1.2f;

        void Start()
        {
            //Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds
            InvokeRepeating("IncreaseGravity", 8.0f, 5.0f);

            //jotta se ei ole nolla ennen ekaa repeatiä
            gravityScale= initialGravityScale;

        }

        void IncreaseGravity()
        {
            gravityScale = gravityScale * gravityMultiplier;
            Debug.Log("GravityScale Increased: " + gravityScale + " laskettu: x " + gravityMultiplier);

        }

        public float GetGravityMultiplier()
        {
            return gravityScale;
        }


    }
 
}


