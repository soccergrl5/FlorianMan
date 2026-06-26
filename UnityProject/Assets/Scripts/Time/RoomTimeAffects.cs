using System;
using FlorianMan.Watch;
using UnityEngine;

public class RoomTimeAffects : MonoBehaviour
{

    //public attributes for setting Sprite, pos and activity for each object
    [SerializeField] private Sprite morningSprite, eveningSprite, afternoonSprite, noonSprite;

    private SpriteRenderer _spriteRenderer;
    private Sprite _currentSprite;
    
    void Start()
    {
        TimeManager.Instance.OnTimeChanged += OnTimeChangedSubscriber;
        _currentSprite = morningSprite;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = true;
    }

    
    private void Update()
    {
        //The sprite is changed in the event
        _spriteRenderer.sprite = _currentSprite;
    }

    //Event: is called when the time in the watch is changed
    private void OnTimeChangedSubscriber(object sender, EventArgs eventArgs)
    {
        //If the time is changed, the current time is adapted
        Times currentTime = TimeManager.Instance.GetCurrentTime();
        switch (currentTime)
        {
            case Times.Morning:
                _currentSprite = morningSprite;
                break;
            case Times.Evening:
                _currentSprite = eveningSprite;
                break;
            case Times.Afternoon:
                _currentSprite = afternoonSprite;
                break;
            case Times.Noon:
                _currentSprite = noonSprite;
                break;
            default: throw new ArgumentOutOfRangeException();
        }
    }
}