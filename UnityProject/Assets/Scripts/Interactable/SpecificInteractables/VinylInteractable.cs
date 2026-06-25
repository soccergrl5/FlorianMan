using UnityEngine;
using FlorianMan.Watch;


public class VinylInteractable : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private TextBoxActivated thisObjectTextBoxActivated;
    //[SerializeField] private TimeAffected thisObjectTimeAffected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        //Not visible anymore
        spriteRenderer.enabled = false;
        
        //Not acitve anymore
        //thisObjectTimeAffected.SetIsActiveForAllTimes(false); //bin mir nich sicher ob das klappt
        
        //Textboxes don't show anymore
        TripleHandler.instance.Remove(Times.Morning, thisObjectTextBoxActivated);
        TripleHandler.instance.Remove(Times.Afternoon, thisObjectTextBoxActivated);
        TripleHandler.instance.Remove(Times.Evening, thisObjectTextBoxActivated);
        TripleHandler.instance.Remove(Times.Noon, thisObjectTextBoxActivated);
    }
}
