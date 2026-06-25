using FlorianMan.Watch;
using UnityEngine;

public class InteractableChair : MonoBehaviour
{
    [SerializeField] private TimeAffected thisObject;
    [SerializeField]private Vector2 afternoonPosition;
    private Times _currentTime;
    
    public void OnClick()
    {
        if (_currentTime.Equals(Times.Afternoon))
        {
            thisObject.getCurrentState().SetPosition(afternoonPosition);
        }
        
    }
}
