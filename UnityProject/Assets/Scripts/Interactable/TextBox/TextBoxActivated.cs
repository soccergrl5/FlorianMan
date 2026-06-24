using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TextBoxActivated : MonoBehaviour
{
    private Times _currentTime;
    private TextBoxes _textBox;
    private bool _hasTextBox;
    public void Start()
    {
        _currentTime = TimeManager.Instance.GetCurrentTime();
        _textBox = TripleHandler.instance.GetTextBoxByTimeAndObject(_currentTime, this);
        
    }
    void OnMouseDown()
    {
        TextBoxesUI.Instance.ActivateTextBox(_textBox);
    }
}
