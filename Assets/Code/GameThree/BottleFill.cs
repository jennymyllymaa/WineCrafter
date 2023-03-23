using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BottleFill : MonoBehaviour
    {
        private CapsuleCollider2D coll;
        private SpriteRenderer spriteRenderer;
        [SerializeField] private Sprite fullBottle;

        int bottlePoints = 0;

        // Start is called before the first frame update
        void Awake()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            coll = GetComponent<CapsuleCollider2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "WineDrop")
            {

                Destroy(collision.gameObject);
                ChangeSprite();
                bottlePoints += 1;
                ScoreManager.instance.AddPoint();
                Debug.Log(bottlePoints);
            }

        }

        public void ChangeSprite()  
        {
            spriteRenderer.sprite = fullBottle;
        }

    }
}
