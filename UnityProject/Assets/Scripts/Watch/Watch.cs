using UnityEngine;

namespace FlorianMan.Watch
{
    public class Watch : MonoBehaviour
    {
        public static Watch Instance {get; private set;}

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
        }

        public void BackOneDay() => _currentDay--;
        
        public void ForwardOneDay() => _currentDay++;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns>
        /// -1 : Error
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
        /// 
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns>
        /// -1 : Error
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
        
        public int GetCurrentTime() => _currentTime;
    }
}