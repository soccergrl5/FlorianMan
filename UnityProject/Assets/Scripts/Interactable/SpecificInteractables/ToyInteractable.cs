using FlorianMan.Watch;
using UnityEngine;

public class ToyInteractable : MonoBehaviour
{
    [SerializeField] private TextBoxActivated toy;
    
    public void OnMouseDown()
    {
        TripleHandler.instance.Remove(Times.Morning, toy);
        //TripleHandler.instance.Remove(Times.Afternoon, toy);
        //TripleHandler.instance.Remove(Times.Evening, toy);
        //TripleHandler.instance.Remove(Times.Noon, toy);
    }
}
