using UnityEngine;

namespace FlorianMan.Watch
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance {get; private set;}

        private Times _currentTime;
        private int _unlockedTimes;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _currentTime   = Times.Morning;
            _unlockedTimes = 1;
        }
        
        public void SetCurrentTime(Times times) => _currentTime = times;

        public int GetUnlockedTimes() => _unlockedTimes;
        
        public void UnlockNextTime() => _unlockedTimes++;
        
        public Times GetCurrentTime() => _currentTime;
    }
}