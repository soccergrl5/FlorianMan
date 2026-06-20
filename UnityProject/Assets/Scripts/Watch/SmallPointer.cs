using UnityEngine;

namespace FlorianMan.Watch
{
    public class SmallPointer : MonoBehaviour
    {
        public static SmallPointer Instance { get; private set; }
        
        private int time = 8;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, -30 * time);
        }
    
        public void Turn(float angle)
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, angle);
        }
        
        public void HourDown()
        {
            time--;

            if (time == 0) time = 12;
        }

        public void HourUp()
        {
            time++;
            
            if (time == 13) time = 1;
        }

        public int GetTime() => time;
    }
}