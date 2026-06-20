using System;
using UnityEngine;

namespace FlorianMan.Watch
{
    public class MovePointer : MonoBehaviour
    {
        private bool onClick = false;

        private float currentRotation = 0;
        
        private Vector2 middlePoint;
        
        private void Start()
        {
            middlePoint.x = Screen.width / 2;
            middlePoint.y = Screen.height / 2;
        }
        
        private void OnMouseDown()
        {
            onClick = true;
        }

        private void OnMouseUp()
        {
            onClick = false;
        }

        private void Update()
        {
            if (!onClick) return;

            Vector3 mousePos = Input.mousePosition;

            float xDiff = middlePoint.x - mousePos.x;
            float yDiff = middlePoint.y - mousePos.y;
            
            double tan = Math.Atan(xDiff / yDiff) * (180/Math.PI);
            
            if (xDiff > 0 && yDiff > 0)
            {
                tan = -(180 - tan);
            }
            if (xDiff < 0 && yDiff > 0)
            {
                tan = 180 + tan;
            }
            
            transform.RotateAround(Vector3.zero, Vector3.forward, currentRotation - (float)tan);

            currentRotation = (float)tan;
        }
    }
}