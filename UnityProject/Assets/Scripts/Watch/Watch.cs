using FlorianMan.UI;
using UnityEngine;

namespace FlorianMan.Watch
{
    public class Watch : MonoBehaviour
    {
        public static Watch Instance {get; private set;}

        [SerializeField] private GameObject clockFront;
        [SerializeField] private GameObject clockBack;
        
        [SerializeField] private GameObject[] cogwheels;

        private bool _showFront;

        private const int MorningTime   = 7;
        private const int EveningTime   = 10;
        private const int AfternoonTime = 4;
        private const int NoonTime      = 12;

        private int _currentDay;
        private int _currentTime;

        private void Awake()
        {
            Instance = this;
            
            _currentDay  = 2;
            _currentTime = MorningTime;
            
            _showFront = true;
        }

        private void Start()
        {
            Hide();
        }

        /// <summary>
        /// Show the Watch
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);
            
            RoomPlanUI.Instance.Disable();
            DetectiveBookUI.Instance.Disable();
        }

        /// <summary>
        /// Hide the Watch
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
            
            RoomPlanUI.Instance.Enable();
            DetectiveBookUI.Instance.Enable();
        }

        /// <summary>
        /// Turn the Clock back and forth
        /// </summary>
        public void TurnClock()
        {
            _showFront = !_showFront;

            clockFront.SetActive(_showFront);
            clockBack.SetActive(!_showFront);
        }

        /// <summary>
        /// Go Back one day if turned over Hour 12
        /// </summary>
        public void BackOneDay() => _currentDay--;
        
        /// <summary>
        /// Go Forth one day if turned over Hour 12
        /// </summary>
        public void ForwardOneDay() => _currentDay++;
        
        /// <summary>
        /// Check if the Clock can be turned Further Back
        /// </summary>
        /// <param name="currentTime">The Current Time</param>
        /// <returns>
        /// -1: Error
        /// 0: Can Turn Back Further
        /// 1: Valid Time But can Turn Back Further
        /// 2: Valid Time but cannot turn back further
        /// </returns>
        public int CanTurnBackFurther(int currentTime)
        {
            int unlockedTimes = TimeManager.Instance.GetUnlockedTimes();
            
            switch (unlockedTimes)
            {
                case 1:
                    return 2;
                
                case 2:
                    if (_currentDay == 2) return 0;

                    if (currentTime == EveningTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Evening);
                        return 2;
                    }
                    
                    return 0;
                
                case 3:
                    if (_currentDay == 2) return 0;
                    
                    if (currentTime == EveningTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Evening);
                        return 1;
                    }

                    if (currentTime == AfternoonTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Afternoon);
                        return 2;
                    }

                    return 0;
                
                case 4:
                    if (_currentDay == 2) return 0;

                    if (_currentDay == 0)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Noon);
                        return 2;
                    }
                    
                    if (currentTime == EveningTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Evening);
                        return 1;
                    }

                    if (currentTime == AfternoonTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Afternoon);
                        return 1;
                    }

                    return 0;
                
                default:
                    Debug.Log("WTF");
                    break;
            }

            return -1;
        }
        
        /// <summary>
        /// Check if the Clock can be turned further Forward
        /// </summary>
        /// <param name="currentTime">The current Time</param>
        /// <returns>
        /// -1: Error
        /// 0: Can Turn Forward Further
        /// 1: Valid Time But can Turn Forward Further
        /// 2: Valid Time but cannot turn forward further
        /// </returns>
        public int CanTurnForwardFurther(int currentTime)
        {
            int unlockedTimes = TimeManager.Instance.GetUnlockedTimes();

            switch (unlockedTimes)
            {
                case 1:
                    return 2;
                
                case 2:
                    if (_currentDay == 1) return 0;
                    
                    if (currentTime == MorningTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Morning);
                        return 2;
                    }

                    return 0;
                
                case 3:
                    if (_currentDay == 1)
                    {
                        if (currentTime == EveningTime)
                        {
                            _currentTime = currentTime;
                            TimeManager.Instance.SetCurrentTime(Times.Evening);
                            return 1;
                        }
                        
                        return 0;
                    }

                    if (currentTime == MorningTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Morning);
                        return 2;
                    }

                    return 0;
                
                case 4:
                    if (_currentDay == 0) return 0;

                    if (_currentDay == 1)
                    {
                        if (currentTime == AfternoonTime)
                        {
                            _currentTime = currentTime;
                            TimeManager.Instance.SetCurrentTime(Times.Afternoon);
                            return 1;
                        }

                        if (currentTime == EveningTime)
                        {
                            _currentTime = currentTime;
                            TimeManager.Instance.SetCurrentTime(Times.Evening);
                            return 1;
                        }
                        
                        return 0;
                    }

                    if (currentTime == MorningTime)
                    {
                        _currentTime = currentTime;
                        TimeManager.Instance.SetCurrentTime(Times.Morning);
                        return 2;
                    }
                    
                    return 0;
                
                default:
                    Debug.Log("WTF!");
                    break;
            }

            return -1;
        }

        /// <summary>
        /// Check if the Position of the Cogwheel Item is at the right spot
        /// </summary>
        /// <param name="position">Position of the Cogwheel Item</param>
        /// <returns>If the Spot is valid</returns>
        public bool CogwheelIsAtRightPosition(Vector3 position)
        {
            if (!gameObject.activeSelf) return false;
            if (_showFront) return false;
            
            int unlockedTimes = TimeManager.Instance.GetUnlockedTimes();
            
            Vector3 positionCogwheel = cogwheels[unlockedTimes - 1].transform.position;
            float radius = 1f;

            if (position.x < positionCogwheel.x + radius
                && position.x > positionCogwheel.x - radius 
                && position.y < positionCogwheel.y + radius 
                && position.y > positionCogwheel.y - radius)
            {
                cogwheels[unlockedTimes - 1].GetComponent<WatchCogwheel>().Placed();
                TimeManager.Instance.UnlockNextTime();
                MovePointer.Instance.UnlockedNewTime();
                
                return true;
            }
            
            return false;
        }
        
        /// <summary>
        /// Get the current Time
        /// </summary>
        /// <returns>Current Time</returns>
        public int GetCurrentTime() => _currentTime;
    }
}