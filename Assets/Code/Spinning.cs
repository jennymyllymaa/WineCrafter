using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace WineCrafter
{
    public class Spinning : MonoBehaviour
    {

        float reachposition = 0f;
        float reachbackposition = 3f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (reachposition <= 3f)
            {
                reachbackposition = 3f;
                reachposition += 0.01f;
                transform.Rotate(0f, 0f, 10f * Time.deltaTime, Space.Self);
                
            }

            if (reachposition >= 3f)

                if (reachbackposition >= 0f)
                {
                    transform.Rotate(0f, 0f, -10f * Time.deltaTime, Space.Self);
                    reachbackposition = reachbackposition - 0.01f;

                    if (reachbackposition <= 0f)
                    {
                        reachposition = 0f;
                        
                    }

                }
            {

                
            }
            
            
        }
    }
}


