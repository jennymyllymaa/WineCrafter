using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace WineCrafter
{
    public class Spinning : MonoBehaviour
    {

        float reachposition = 0f;
        float reachbackposition = 15f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (reachposition <= 15f)
            {
                reachbackposition = 15f;
                reachposition += 0.01f;
                transform.Rotate(0f, 0f, 5f * Time.deltaTime * 0.4f, Space.Self);
                
            }

            if (reachposition >= 15f)

                if (reachbackposition >= 0f)
                {
                    transform.Rotate(0f, 0f, -5f * Time.deltaTime * 0.4f, Space.Self);
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


