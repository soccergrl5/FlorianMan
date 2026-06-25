using FlorianMan.UI;
using FlorianMan.Watch;
using UnityEngine;

public class ToyInteractable : MonoBehaviour
{
    public static ToyInteractable Instance {get; private set;}
    
    [SerializeField] private TextBoxActivated toy;

    private bool _canGetCogwheel;
    
    private void Awake()
    {
        Instance = this;
    }

    public void OnMouseDown()
    {
        if (!_canGetCogwheel) return;
        
        TripleHandler.instance.Remove(Times.Morning, toy);
        //TripleHandler.instance.Remove(Times.Afternoon, toy);
        //TripleHandler.instance.Remove(Times.Evening, toy);
        //TripleHandler.instance.Remove(Times.Noon, toy);
    }

    public void ChangeMorningLine()
    {
        TripleHandler.instance.Remove(Times.Morning, toy);
        TripleHandler.instance.Add(Times.Morning, TextBoxes.ToyOnShelfMorning, toy);
    }
}
