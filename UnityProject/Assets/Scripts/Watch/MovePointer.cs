using System;
using UnityEngine;

namespace FlorianMan.Watch
{
    public class MovePointer : MonoBehaviour
    {
        private bool _onClick;

        private float _currentRotation;
        
        private Vector2 _middlePoint;
        
        private void Start()
        {
            _middlePoint.x = Screen.width / 2f;
            _middlePoint.y = Screen.height / 2f;
        }
        
        private void OnMouseDown()
        {
            _onClick = true;
        }

        private void OnMouseUp()
        {
            _onClick = false;
        }

        private void Update()
        {
            if (!_onClick) return;

            Vector3 mousePos = Input.mousePosition;

            float xDiff = _middlePoint.x - mousePos.x;
            float yDiff = _middlePoint.y - mousePos.y;
            
            double tan = Math.Atan(xDiff / yDiff) * (180/Math.PI);
            
            if (xDiff != 0 && yDiff == 0)
            {
                tan = -tan;
            }
            if (xDiff > 0 && yDiff > 0)
            {
                tan = -(180 - tan);
            }
            if (xDiff < 0 && yDiff > 0)
            {
                tan = 180 + tan;
            }
            
            float angle = _currentRotation - (float)tan;

            if (angle > 180)
            {
                angle -= 360;

                SmallPointer.Instance.HourUp();
            }
            if (angle < -180)
            {
                angle += 360;

                SmallPointer.Instance.HourDown();
            }
            
            transform.RotateAround(Vector3.zero, Vector3.forward, angle);
            
            SmallPointer.Instance.Turn(angle / 12);

            if (_currentRotation is < 90 and > 0 && tan is < 0 and > -90)
            {
                Debug.Log("Back " + SmallPointer.Instance.GetTime());
                
                int status = Watch.Instance.CanTurnBackFurther(SmallPointer.Instance.GetTime());

                if (status == 1 || status == 2) _onClick = false;
            }
            if (_currentRotation is < 0 and > -90 && tan is < 90 and > 0)
            {
                Debug.Log("Forth " + SmallPointer.Instance.GetTime());
            }
            
            _currentRotation = (float)tan;
        }
    }
}