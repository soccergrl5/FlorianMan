using FlorianMan.Watch;
using UnityEngine;

public class ChairInteractable : MonoBehaviour
{
    [SerializeField] private TimeAffected thisObject;
    [SerializeField]private Vector2 afternoonPosition;
    private Times _currentTime;
    
    public void OnMouseDown()
    {
        if (_currentTime.Equals(Times.Afternoon))
        {
            thisObject.setAfternoonPosition(afternoonPosition);
        }
        
    }
}
