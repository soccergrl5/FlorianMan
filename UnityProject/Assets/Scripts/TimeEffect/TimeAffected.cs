using System;
using FlorianMan.Watch;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class TimeAffected : MonoBehaviour
{
    //private attributes for intern management
    private ObjectState _morningState, _eveningState, _afternoonState, _noonState;
    private ObjectState[] _states;
    private ObjectState _currentState;
    
    //public attributes for setting Sprite, pos and activity for each object
    [SerializeField] private Sprite morningSprite, eveningSprite, afternoonSprite, noonSprite;
    [SerializeField] private Vector2 morningPos, eveningPos, afternoonPos, noonPos;
    [SerializeField] private bool isVisibleInMorning, isVisibleInEvening, isVisibleInAfternoon, isVisibleInNoon;

    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private TimeAffected timeAffectedObject;

    void Start()
    {
        
        //Instantiates the array and the states for each time
        InitializeStates();
        TimeManager.OnTimeChanged += OnTimeChangedSubscriber;
        //Test
        _currentState = _states[2];
        _currentState.SetPosition(GetComponentInParent<Transform>().position);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    

    private void Update()
    {
        _spriteRenderer.sprite = _currentState.GetSprite();
        transform.position = _currentState.GetPosition();
        _spriteRenderer.enabled = _currentState.GetIsActive();
    }

    //Instantiates the array and the states for each time
    private void InitializeStates()
    {
        
        _morningState = new ObjectState(morningSprite, morningPos, isVisibleInMorning);
        _eveningState = new ObjectState(eveningSprite, eveningPos, isVisibleInEvening);
        _afternoonState = new ObjectState(afternoonSprite, afternoonPos, isVisibleInAfternoon);
        _noonState = new ObjectState(noonSprite, noonPos, isVisibleInNoon);
        
        _states = new ObjectState[]{_morningState, _eveningState, _afternoonState, _noonState};
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
}


// Private inner struct
// Creates a state for each time-affected object 
public struct ObjectState
{
    private Sprite _objectStateSprite;
    private Vector2 _objectStatePosition;
    private bool _objectStateIsActive;

    public ObjectState(Sprite objectStateSprite, Vector2 objectStatePosition, bool objectStateIsActive)
    {
        this._objectStateSprite = objectStateSprite;
        this._objectStatePosition = objectStatePosition;
        this._objectStateIsActive = objectStateIsActive;
    }

    public Sprite GetSprite() { return _objectStateSprite; }
    public Vector2 GetPosition() { return _objectStatePosition; }
    public bool GetIsActive() { return _objectStateIsActive; }
    public void SetPosition(Vector2 position) { _objectStatePosition = position; }
}


