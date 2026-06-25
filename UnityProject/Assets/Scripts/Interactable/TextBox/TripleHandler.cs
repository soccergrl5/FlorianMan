using System.Collections.Generic;
using FlorianMan.Watch;
using FlorianMan.UI;
using UnityEngine;

public class TripleHandler
{
    //This class maps each (time, gameObject) combination to the textbox that needs to be shown
    
    public static TripleHandler instance { get; } = new TripleHandler();

    private Dictionary<(Times, TextBoxActivated), TextBoxTimeObjectTripel> _byTimeAndObject = new();
    
    public void Add(Times time, TextBoxes textbox, TextBoxActivated gameObject)
    {
        var tripel = new TextBoxTimeObjectTripel(time, textbox, gameObject);
        _byTimeAndObject[(time, gameObject)] = tripel;
    }

    public TextBoxes GetTextBoxByTimeAndObject(Times time, TextBoxActivated gameObject)
    {
        if (_byTimeAndObject.TryGetValue((time, gameObject), out var tripel))
        {
            return tripel.GetTextbox();
        }

        Debug.LogWarning($"Kein Tripel gefunden für Time={time}, Object={gameObject}");
        return default;
    }

    public void Remove(Times time, TextBoxActivated gameObject)
    {
        var empty = new TextBoxTimeObjectTripel(time, TextBoxes.Empty, gameObject);
        _byTimeAndObject[(time, gameObject)] = empty;
    }
}

public class TextBoxTimeObjectTripel
{
    private Times _time;
    private TextBoxes _textbox;
    private TextBoxActivated _textBoxActivated;

    public  TextBoxTimeObjectTripel(Times time, TextBoxes textbox, TextBoxActivated textBoxActivated)
    {
        this._time = time;
        this._textbox = textbox;
        this._textBoxActivated = textBoxActivated;
    }

    public Times GetTime()
    {
        return _time;
    }

    public TextBoxes GetTextbox()
    {
        return _textbox;
    }

    public TextBoxActivated GTextBoxActivated()
    {
        return _textBoxActivated;
    }

}