using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WineCrafter
{
    public class ScreenBoundsScript : MonoBehaviour
    {

        //Script for the first game so that the basket doesnt go over
        // the screen boundaries.

        void Awake()
        {
            AddCollider();
        }

        void AddCollider()
        {
            if (Camera.main == null)
            { Debug.LogError("Camera.main not found, failed to create edge colliders"); return; }

            var cam = Camera.main;
            if (!cam.orthographic) 
            { Debug.LogError("Camera.main is not Orthographic, failed to create edge colliders"); return; }

            Vector2 bottomLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
            Vector2 topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
            Vector2 topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
            Vector2 bottomRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

            // add or use existing EdgeCollider2D
            var edge = GetComponent<EdgeCollider2D>() == null ? gameObject.AddComponent<EdgeCollider2D>() : GetComponent<EdgeCollider2D>();

            var edgePoints = new[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
            edge.points = edgePoints;
        }
    }
}
