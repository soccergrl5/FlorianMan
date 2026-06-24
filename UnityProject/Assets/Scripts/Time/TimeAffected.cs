using System;
using FlorianMan.Watch;
using UnityEngine;

public class TimeAffected : MonoBehaviour
{
    //private attributes for intern management
    private ObjectState _morningState, _eveningState, _afternoonState, _noonState;
    private ObjectState[] _states;
    private ObjectState _currentState;
    
    //public attributes for setting Sprite, pos and activity for each object
    [SerializeField] private Sprite morningSprite, eveningSprite, afternoonSprite, noonSprite;
    [SerializeField] private Vector3 morningPos, eveningPos, afternoonPos, noonPos;
    [SerializeField] private bool isVisibleInMorning, isVisibleInEvening, isVisibleInAfternoon, isVisibleInNoon;

    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private TimeAffected timeAffectedObject;

    void Start()
    {
        //Instantiates the array and the states for each time
        InitializeStates();
        TimeManager.Instance.OnTimeChanged += OnTimeChangedSubscriber;
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    

    private void Update()
    {
        _spriteRenderer.sprite = _currentState.GetSprite();
        GetComponentInParent<Transform>().SetLocalPositionAndRotation(_currentState.GetPosition(), Quaternion.identity);
        _spriteRenderer.enabled = _currentState.GetIsActive();
    }

    //Instantiates the array and the states for each time
    private void InitializeStates()
    {
        
        morningPos.Set(morningPos.x, morningPos.y, -1);
        eveningPos.Set(eveningPos.x, eveningPos.y, -1);
        afternoonPos.Set(afternoonPos.x, afternoonPos.y, -1);
        noonPos.Set(noonPos.x, noonPos.y, -1);
        
        _morningState = new ObjectState(morningSprite, morningPos, isVisibleInMorning);
        _eveningState = new ObjectState(eveningSprite, eveningPos, isVisibleInEvening);
        _afternoonState = new ObjectState(afternoonSprite, afternoonPos, isVisibleInAfternoon);
        _noonState = new ObjectState(noonSprite, noonPos, isVisibleInNoon);
        
        _states = new ObjectState[]{_morningState, _eveningState, _afternoonState, _noonState};
        
        _currentState = _states[0];
    }
    
    
    //Event: is called when the time in the watch is changed
    private void OnTimeChangedSubscriber(object sender, EventArgs eventArgs)
    {
        //If the time is changed, the current time is adapted
        Times currentTime = TimeManager.Instance.GetCurrentTime();
        switch (currentTime)
        {
            case Times.Morning: _currentState = _morningState; break;
            case Times.Evening: _currentState = _eveningState; break;
            case Times.Afternoon: _currentState = _afternoonState; break;
            case Times.Noon: _currentState = _noonState; break;
            default: throw new ArgumentOutOfRangeException();
        } 
    }

    public void setVisibilityInThisTimeAndAllTimesPrior(bool visibility)
    {
        Times time = TimeManager.Instance.GetCurrentTime();
        switch (time)
        {
            case Times.Morning:
                _morningState.SetIsActive(visibility);
                _eveningState.SetIsActive(visibility);
                _afternoonState.SetIsActive(visibility);
                _noonState.SetIsActive(visibility);
                break;
            case Times.Evening:
                _eveningState.SetIsActive(visibility);
                _afternoonState.SetIsActive(visibility);
                _noonState.SetIsActive(visibility);
                break;
            case Times.Afternoon:
                _afternoonState.SetIsActive(visibility);
                _noonState.SetIsActive(visibility);
                break;
            case Times.Noon:
                _noonState.SetIsActive(visibility);
                break;
            default: throw new ArgumentOutOfRangeException();
        }

    }

    public ObjectState getCurrentState()
    {
        return _currentState;
    }
}


// Private inner struct
// Creates a state for each time-affected object 
public struct ObjectState
{
    private Sprite _objectStateSprite;
    private Vector3 _objectStatePosition;
    private bool _objectStateIsActive;

    public ObjectState(Sprite objectStateSprite, Vector3 objectStatePosition, bool objectStateIsActive)
    {
        this._objectStateSprite = objectStateSprite;
        this._objectStatePosition = objectStatePosition;
        this._objectStateIsActive = objectStateIsActive;
    }

    public Sprite GetSprite() { return _objectStateSprite; }
    public Vector3 GetPosition() { return _objectStatePosition; }
    public bool GetIsActive() { return _objectStateIsActive; }

    public void SetPosition(Vector3 position) { _objectStatePosition = position; }

    public void SetIsActive(bool isActive) { _objectStateIsActive = isActive; }
}


