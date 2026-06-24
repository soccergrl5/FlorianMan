using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
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
        //TodDo
    }

    void OnMouseLeave()
    {
        //Textbox wieder deaktivieren
    }
}
