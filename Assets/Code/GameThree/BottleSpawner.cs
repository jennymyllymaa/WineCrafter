using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BottleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject emptyBottle;
        [SerializeField] private float minSpawnTime = 1.0f;
        [SerializeField] private float maxSpawnTime = 2.0f;

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
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSecondsRealtime(randomTime);

            if (Time.timeScale != 0f)
            {
                Instantiate(emptyBottle, spawnPosition, Quaternion.identity);
            }
                

            StartCoroutine(Spawn());

        }
    }
}


