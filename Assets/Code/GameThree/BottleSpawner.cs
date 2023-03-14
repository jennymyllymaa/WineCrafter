using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BottleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject emptyBottle;
        [SerializeField] private int time = 2;

        private Vector3 spawnPosition;
        private BoxCollider2D col;

        void Awake()
        {
            col = GetComponent<BoxCollider2D>();
            Vector2 colCenter = col.bounds.center;
            spawnPosition = new Vector3(colCenter.x, colCenter.y, transform.position.z);


        }
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Spawn(time));
        }

        IEnumerator Spawn(int time)
        {

            yield return new WaitForSecondsRealtime(time);


            Instantiate(emptyBottle, spawnPosition, Quaternion.identity);

            StartCoroutine(Spawn(time));

        }
    }
}


