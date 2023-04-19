using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class button_visibility : MonoBehaviour
{
    private bool visibility;
    GameObject character;
    Vector3 follow;

    

    // Start is called before the first frame update
    void Start()
    {
        visibility= false;
        //character = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        visibility = GameObject.Find("Player").GetComponent<PlayerMove_v2>().interaction_available;
        //Debug.Log(visibility);

        if (visibility == true) {
            //Debug.Log("button visible");
            //GameObject.FindGameObjectWithTag("UI").SetActive(true);
            GameObject.Find("Buttonz").transform.localScale = new Vector3(1, 1, 1);
            
            //make it follow the character
            //TOO HARD

        }
        else if (visibility == false) {
           // Debug.Log("not visible");
            GameObject.Find("Buttonz").transform.localScale = new Vector3(0, 0, 0);
                
        }

         if (Input.GetKeyDown(KeyCode.Space))
         {
             GetComponent<Button>().onClick.Invoke();
         }

    }

}
