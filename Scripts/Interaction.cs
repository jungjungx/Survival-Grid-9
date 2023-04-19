using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    GameObject sensedObject;
    private bool availability;
    private bool dooravailability;
    private bool doorToggle;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        availability = GameObject.Find("Player").GetComponent<PlayerMove_v2>().interaction_available;
        dooravailability = GameObject.Find("Player").GetComponent<PlayerMove_v2>().door_available;

        if(Input.GetKeyDown("space")){
            if(availability){
                //all possible interactions

                //doors interactions
                if(dooravailability){
                   // Debug.Log("za darudo");
                }
            }

        }
        
        /*
        if(availability){
            //Debug.Log("Interaction available to player");
            if(Input.GetKeyDown("space")){
                sensedObject = GameObject.FindGameObjectWithTag("Door");

                GameObject objectMain = sensedObject.transform.parent.gameObject;
                if(){
                    Debug.Log("Interact with za door");
                }
            }
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Interactive")
        {
            Debug.Log("Interaction available to player");
            sensedObject = GameObject.FindGameObjectWithTag("Door");

                GameObject objectMain = sensedObject.transform.parent.gameObject;
                Debug.Log("Interact with za door");
            

        }
    }
}
