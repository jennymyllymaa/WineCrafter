using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private GameObject[] fallingObjects;
        /* [SerializeField] float secondSpawn = 0.5f; */

        private BoxCollider2D col;

        float x1, x2;

        // Start is called before the first frame update
        void Awake()
        {
            col = GetComponent<BoxCollider2D>();

            x1 = transform.position.x - col.bounds.size.x / 2f;
            x2 = transform.position.x + col.bounds.size.x / 2f;


        }

        // Update is called once per frame
        void Start()
        {
            StartCoroutine(Spawn(0.01f));

        }

        IEnumerator Spawn(float time)
        {
            yield return new WaitForSecondsRealtime(time);



            Vector3 temp = transform.position;
            temp.x = Random.Range(x1, x2);

            Instantiate(fallingObjects[Random.Range(0, fallingObjects.Length)], temp, Quaternion.identity);

            StartCoroutine(Spawn(Random.Range(0.01f, 1.5f)));

        }
    }
}


