using System;
using UnityEngine;

namespace FlorianMan.DetailedObject.TelephoneObject
{
    public class TurnablePart : MonoBehaviour
    {
        public static TurnablePart Instance {get; private set;}
        
        private bool _onClick;
        private bool _moving;
        private bool _checkRotation;

        private bool _locked;
        
        private Vector2 _middlePoint;
        
        private float _currentRotation;
        private float _startRotation;
        
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
            
            _defaultPosition = transform.position;
            _defaultRotation = transform.rotation;

            _defaultPosition.z += 10;
        }

        /// <summary>
        /// Reset the Position to normal
        /// </summary>
        private void ResetToDefaultTransform()
        {
            transform.SetLocalPositionAndRotation(_defaultPosition, _defaultRotation);
        }

        /// <summary>
        /// Actually Turn Back to the Default Position
        /// </summary>
        private void TurnBackToDefaultTransform()
        {
            if (transform.rotation.eulerAngles.z > 5)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, 1f);
                Invoke(nameof(TurnBackToDefaultTransform), 0.01f);
            }
            else
            {
                ResetToDefaultTransform();
            }
        }

        private void Update()
        {
            if (!_onClick) return;

            //Calculate Angle to Rotate
            Vector3 mousePos = Input.mousePosition;

            float xDiff = _middlePoint.x - mousePos.x;
            float yDiff = _middlePoint.y - mousePos.y;
            
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
                if (angle > 0)
                {
                    _onClick = false;
                    return;
                }
                
                if (angle != 0)
                    _checkRotation = true;
            }
            
            transform.RotateAround(Vector3.zero, Vector3.forward, angle);

            //Can turn further to the right
            if (_currentRotation < 100 && tan > 100 && angle < 0)
            {
                _onClick = false;
            }
            
            //Turned Back to original Position (no dial)
            if (tan < _startRotation && _currentRotation > _startRotation && angle > 0)
            {
                _onClick = false;
                ResetToDefaultTransform();
            }
            
            _currentRotation = (float)tan;
        }

        private void OnMouseDown()
        {
            if (_locked) return;
            
            _onClick = true;
        }

        private void OnMouseUp()
        {
            _onClick       = false;
            _moving        = false;
            _checkRotation = false;

            //No Rotation
            if (transform.rotation == _defaultRotation) return;
            
            //Check the Dialed Number
            CalculateSelectedNumber();
            TurnBackToDefaultTransform();
        }

        private void CalculateSelectedNumber()
        {
            float angle = _currentRotation - _startRotation;
            if (angle < 0) angle += 360;
            
            if (angle is > 55 and <= 85) Telephone.Instance.AddDial("1");
            else if (angle is > 85 and <= 115) Telephone.Instance.AddDial("2");
            else if (angle is > 115 and <= 145) Telephone.Instance.AddDial("3");
            else if (angle is > 145 and <= 175) Telephone.Instance.AddDial("4");
            else if (angle is > 175 and <= 205) Telephone.Instance.AddDial("5");
            else if (angle is > 205 and <= 235) Telephone.Instance.AddDial("6");
            else if (angle is > 235 and <= 265) Telephone.Instance.AddDial("7");
            else if (angle is > 265 and <= 295) Telephone.Instance.AddDial("8");
            else if (angle is > 295 and <= 325) Telephone.Instance.AddDial("9");
            else if (angle is > 325 and <= 355) Telephone.Instance.AddDial("0");
        }
        
        public void LockTelephone() => _locked = true;
        public void UnlockTelephone() => _locked = false;
    }
}