using FlorianMan.DetailedObject.FridgeObject;
using FlorianMan.DetailedObject.MicrowaveObject;
using FlorianMan.DetailedObject.RecordPlayerObject;
using FlorianMan.DetailedObject.TelephoneObject;
using UnityEngine;

namespace FlorianMan.DetailedObject
{
    public class ClickableObjectVersion : MonoBehaviour
    {
        [SerializeField] private DetailedObjects currentObject;
        
        private void OnMouseDown() 
        {
            switch(currentObject)
            {
                case DetailedObjects.Telephone:
                    Telephone.Instance.Show();
                    break;
                
                case DetailedObjects.Microwave:
                    Microwave.Instance.Show();
                    break;
                
                case DetailedObjects.Fridge:
                    Fridge.Instance.Show();
                    break;
                
                case DetailedObjects.RecordPlayer:
                    RecordPlayer.Instance.Show();
                    break;
            }
        }
    }
}