using System.Collections;
using UnityEngine;
public class Interact : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            Debug.Log("E");
            Ray interactionRay;
            interactionRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
            RaycastHit hitInfo;
            if(Physics.Raycast(interactionRay, out hitInfo,10))
            {
                //Switch Version
                switch(hitInfo.collider.tag)
                {
                    case "NPC":
                        Debug.Log("Talk to NPC");
                    break;
                    case "Item":
                        Debug.Log("Pick up Item");
                    break;
                }
                //if Version
                
                /* if(hitInfo.collider.CompareTag("NPC"))
                {
                    Debug.Log("Talk to NPC");
                }
                if(hitInfo.collider.tag == "Item")
                {
                    Debug.Log("Pick up Item");                    
                }*/
                             
            }
        }
    }
}
