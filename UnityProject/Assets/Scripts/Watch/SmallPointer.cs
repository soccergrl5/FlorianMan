using UnityEngine;

namespace FlorianMan.Watch
{
    public class SmallPointer : MonoBehaviour
    {
        public static SmallPointer Instance { get; private set; }
        
        private int _time;
        
        private Vector3 _localMiddlePoint;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _time = Watch.Instance.GetCurrentTime();
            
            _localMiddlePoint = Vector3.zero;
            
            transform.RotateAround(_localMiddlePoint, Vector3.forward, -30 * _time);
        }
    
        /// <summary>
        /// Turn with given angle
        /// </summary>
        /// <param name="angle">Angle to turn the Pointer</param>
        public void Turn(float angle)
        {
            transform.RotateAround(_localMiddlePoint, Vector3.forward, angle);
        }

        /// <summary>
        /// Set new Middle Point to turn around when Camera Position changes
        /// </summary>
        /// <param name="middlePointX">x-Coordinate of the new Camera Position</param>
        public void SetNewLocalMiddlePoint(int middlePointX)
        {
            _localMiddlePoint.x = middlePointX;
        }
        
        //Count down an Hour
        public void HourDown()
        {
            _time--;

            //Change between 12 and 1 o'clock
            if (_time == 0)
            {
                _time = 12;
                
                Watch.Instance.BackOneDay();
            }
        }
        
        //Count up an Hour
        public void HourUp()
        {
            _time++;

            //Change between 12 and 1 o'clock
            if (_time == 13)
            {
                _time = 1;
                Watch.Instance.ForwardOneDay();
            }
        }

        /// <summary>
        /// Get the current Time
        /// </summary>
        /// <returns>Current Hour</returns>
        public int GetTime() => _time;
    }
}