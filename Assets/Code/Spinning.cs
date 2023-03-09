using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace WineCrafter
{
    public class Spinning : MonoBehaviour
    {

        public float amplitude = 0.5f;  // the amount of sway
        public float speed = 1f;        // the speed of the sway

        private float initialAngle;

        // Start is called before the first frame update
        void Start()
        {

            initialAngle = transform.eulerAngles.z;

        }

        // Update is called once per frame
        void Update()
        {
            float angle = initialAngle + amplitude * Mathf.Sin(speed * Time.time);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}


