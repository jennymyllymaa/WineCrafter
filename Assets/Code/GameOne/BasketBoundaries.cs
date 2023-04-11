using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class BasketBoundaries : MonoBehaviour
    {
        private Vector2 screenBounds;
        private float objectWidth;
        private float objectHeight;

        void Start()
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            objectWidth = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
            objectHeight = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2;

        }

        void LateUpdate()
        {
            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 - objectWidth, screenBounds.x + objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 - objectHeight, screenBounds.y + objectHeight);
            transform.position = viewPos;
        }
    }
}
