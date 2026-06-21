using UnityEngine;

namespace FlorianMan.Watch
{
    public class SmallPointer : MonoBehaviour
    {
        public static SmallPointer Instance { get; private set; }
        
        private int _time;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _time = Watch.Instance.GetCurrentTime();
            
            transform.RotateAround(Vector3.zero, Vector3.forward, -30 * _time);
        }
    
        public void Turn(float angle)
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, angle);
        }
        
        public void HourDown()
        {
            _time--;

            if (_time == 0)
            {
                _time = 12;
                
                Watch.Instance.BackOneDay();
            }
        }

        public void HourUp()
        {
            _time++;

            if (_time == 13)
            {
                _time = 1;
                Watch.Instance.ForwardOneDay();
            }
        }

        public int GetTime() => _time;
    }
}