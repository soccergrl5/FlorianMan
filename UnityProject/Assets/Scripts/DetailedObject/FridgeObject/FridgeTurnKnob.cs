using System;
using UnityEngine;

namespace FlorianMan.DetailedObject.FridgeObject
{
    public class FridgeTurnKnob : MonoBehaviour
    {
        public static FridgeTurnKnob Instance;

        private bool _onClick;
        private bool _moving;
        private bool _checkRotation;
        
        private Vector3 _rotationPoint;
        
        private float _currentRotation;
        private float _startRotation;
        
        private Vector3 _defaultPosition;
        private Quaternion _defaultRotation;
        
        private void Awake()
        {
            Instance = this;
            
            _rotationPoint = new Vector3(25f + 1.6348f, 3.89f, 0f);
            
            _defaultPosition = transform.position;
            _defaultRotation = transform.rotation;

            _defaultPosition.z += 10;
        }

        /// <summary>
        /// Snap the Button to the Cold Setting
        /// </summary>
        public void SnapToColdSetting()
        {
            transform.SetLocalPositionAndRotation(_defaultPosition, _defaultRotation);
        }

        /// <summary>
        /// Snap the Button to the Warm Setting
        /// </summary>
        public void SnapToWarmSetting()
        {
            Quaternion rotation = _defaultRotation;
            rotation.eulerAngles += new Vector3(0, 0, 180);
            transform.SetLocalPositionAndRotation(_defaultPosition, rotation);
        }

        private void OnMouseDown()
        {
            _onClick = true;
        }

        private void OnMouseUp()
        {
            _onClick       = false;
            _moving        = false;
            _checkRotation = false;
            
            CheckPosition();
        }

        private void Update()
        {
            if (!_onClick) return;

            bool isCold = Fridge.Instance.CheckIfSetCold();

            //Calculate Angle to Rotate
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            float xDiff = _rotationPoint.x - mousePos.x;
            float yDiff = _rotationPoint.y - mousePos.y;
            
            double tan = Math.Atan(xDiff / yDiff) * (180/Math.PI);
            
            //Special Cases
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

            //Save where the Mouse Pointer started
            if (!_moving)
            {
                _moving          = true;
                _startRotation   = (float)tan;
                _currentRotation = (float)tan;
            }
            
            float angle = _currentRotation - (float)tan;

            //Check if Pointer went through the bottom
            if (angle > 180)
            {
                angle -= 360;
            }
            if (angle < -180)
            {
                angle += 360;
            }
            
            //Check if turning started in the Right Direction
            if (!_checkRotation)
            {
                if (isCold && angle > 0)
                {
                    _onClick = false;
                    return;
                }

                if (!isCold && angle < 0)
                {
                    _onClick = false;
                    return;
                }
                
                if (angle != 0)
                    _checkRotation = true;
            }
            
            transform.RotateAround(_rotationPoint, Vector3.forward, angle);

            //Can turn further to the right
            float rotated = _currentRotation - _startRotation;

            if (isCold)
            {
                if (rotated < 0) rotated += 360;
            
                if (rotated > 180 && rotated != 360)
                {
                    _onClick = false;
                }
            }
            else
            {
                if (rotated > 0) rotated -= 360;

                if (rotated < -180 && rotated != 360)
                {
                    _onClick = false;
                }
            }
            
            _currentRotation = (float)tan;
        }

        /// <summary>
        /// Check which Setting the Current Position represents
        /// </summary>
        private void CheckPosition()
        {
            float rotation = _currentRotation - _startRotation;
            
            if (Fridge.Instance.CheckIfSetCold())
            {
                if (rotation < 0) rotation += 360;
                if (rotation is > 90 and < 270)
                {
                    SnapToWarmSetting();
                    Fridge.Instance.WarmButtonPressed();
                }
                else
                {
                    SnapToColdSetting();
                }
            }
            else
            {
                if (rotation > 0) rotation -= 360;
                if (rotation is < -90 and > -270)
                {
                    SnapToColdSetting();
                    Fridge.Instance.ColdButtonPressed();
                }
                else
                {
                    SnapToWarmSetting();
                }
            }
        }
    }
}