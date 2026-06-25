using UnityEngine;
using FlorianMan.Watch;


public class VinylInteractable : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    [SerializeField] private TextBoxActivated thisObjectTextBoxActivated;
    //[SerializeField] private TimeAffected thisObjectTimeAffected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void OnMouseDown()
    {
        //Not visible anymore
        spriteRenderer.enabled = false;
        collider.enabled = false;
        
        //Not acitve anymore
        //thisObjectTimeAffected.SetIsActiveForAllTimes(false); //bin mir nich sicher ob das klappt
        
        //Textboxes don't show anymore
        /*TripleHandler.instance.Remove(Times.Morning, thisObjectTextBoxActivated);
        TripleHandler.instance.Remove(Times.Afternoon, thisObjectTextBoxActivated);
        TripleHandler.instance.Remove(Times.Evening, thisObjectTextBoxActivated);
        TripleHandler.instance.Remove(Times.Noon, thisObjectTextBoxActivated);*/
    }
}
