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
                    Telephone.Telephone.Instance.Show();
                    break;
                
                case DetailedObjects.Microwave:
                    Microwave.Microwave.Instance.Show();
                    break;
                
                case DetailedObjects.Fridge:
                    Fridge.Fridge.Instance.Show();
                    break;
                
                case DetailedObjects.RecordPlayer:
                    RecordPlayer.RecordPlayer.Instance.Show();
                    break;
            }
        }
    }
}