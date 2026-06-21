using System;
using UnityEngine;

namespace FlorianMan.Watch
{
    public class MovePointer : MonoBehaviour
    {
        public static MovePointer Instance {get; private set;}
        
        private bool _onClick;
        private bool _moving;

        private bool _lockedBack;
        private bool _lockedForward;

        private float _currentRotation;
        
        private Vector2 _middlePoint;
        private Vector3 _middlePointLocal;
        
        private Vector3 _defaultPosition;
        private Quaternion _defaultRotation;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _middlePoint.x = Screen.width / 2f;
            _middlePoint.y = Screen.height / 2f;
            
            _middlePointLocal = Vector3.zero;

            _lockedForward = true;
            
            _defaultPosition = transform.position;
            _defaultRotation = transform.rotation;

            _defaultPosition.z += 10;
        }

        private void ResetToDefaultTransform()
        {
            transform.SetLocalPositionAndRotation(_defaultPosition, _defaultRotation);
        }

        public void SetNewLocalMiddlePoint(int middlePointX)
        {
            _middlePointLocal.x = middlePointX;
            
            SmallPointer.Instance.SetNewLocalMiddlePoint(middlePointX);
        }
        
        private void OnMouseDown()
        {
            if (TimeManager.Instance.GetUnlockedTimes() == 1) return;
            
            _onClick = true;
        }

        private void OnMouseUp()
        {
            _onClick = false;
            _moving  = false;
        }

        private void Update()
        {
            if (!_onClick) return;

            Vector3 mousePos = Input.mousePosition;

            float xDiff = _middlePoint.x - mousePos.x;
            float yDiff = _middlePoint.y - mousePos.y;
            
            double tan = Math.Atan(xDiff / yDiff) * (180/Math.PI);

            if (!_moving && _lockedBack && tan < 0)
            {
                _onClick = false;
                return;
            }

            if (!_moving && _lockedForward && tan > 0)
            {
                _onClick = false;
                return;
            }

            if (!_moving)
            {
                _moving        = true;
                _lockedBack    = false;
                _lockedForward = false;
            }
            
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
            
            transform.RotateAround(_middlePointLocal, Vector3.forward, angle);
            
            SmallPointer.Instance.Turn(angle / 12);

            if (_currentRotation is < 90 and > 0 && tan is < 0 and > -90)
            {
                int status = Watch.Instance.CanTurnBackFurther(SmallPointer.Instance.GetTime());

                if (status == 1 || status == 2)
                {
                    _onClick = false;
                    _moving  = false;
                    
                    ResetToDefaultTransform();
                }
                
                if (status == 2) _lockedBack = true;
            }
            if (_currentRotation is < 0 and > -90 && tan is < 90 and > 0)
            {
                int status = Watch.Instance.CanTurnForwardFurther(SmallPointer.Instance.GetTime());

                if (status == 1 || status == 2)
                {
                    _onClick = false;
                    _moving  = false;
                    
                    ResetToDefaultTransform();
                }
                
                if (status == 2) _lockedForward = true;
            }
            
            _currentRotation = (float)tan;
        }

        public void UnlockedNewTime()
        {
            _lockedBack = false;
        }
    }
}