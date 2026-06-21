using UnityEngine;

namespace FlorianMan.Inventory
{
    public class Item : MonoBehaviour
    {
        private void Update()
        {
            //Update the Position to where the Mouse is at
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z += 8;
            
            transform.SetPositionAndRotation(position, Quaternion.identity);
        }
    }
}