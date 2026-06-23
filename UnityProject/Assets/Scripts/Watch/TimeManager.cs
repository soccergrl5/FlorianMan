using System;
using UnityEngine;

namespace FlorianMan.Watch
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance {get; private set;}

        private Times _currentTime;
        private int _unlockedTimes;
        
        public event EventHandler OnTimeChanged; 

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _currentTime   = Times.Morning;
            _unlockedTimes = 1;
        }

        /// <summary>
        /// Set the new Current Time
        /// </summary>
        /// <param name="times">New set Time</param>
        public void SetCurrentTime(Times times)
        {
            _currentTime = times;
            OnTimeChanged?.Invoke(_currentTime, EventArgs.Empty);
        }

        /// <summary>
        /// Get how many Times are already unlocked
        /// </summary>
        /// <returns>Amount of unlocked Times</returns>
        public int GetUnlockedTimes() => _unlockedTimes;
        
        /// <summary>
        /// Unlock a new Time
        /// </summary>
        public void UnlockNextTime() => _unlockedTimes++;
        
        /// <summary>
        /// Get the current Time
        /// </summary>
        /// <returns>Current Time</returns>
        public Times GetCurrentTime() => _currentTime;
    }
}