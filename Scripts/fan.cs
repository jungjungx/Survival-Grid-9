using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{

    private bool Isrunning= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Isrunning= GameObject.Find("Vents").GetComponent<Vent>().running;
        if(Isrunning){
            //Debug.Log("rotating fan");
            transform.Rotate (Vector3.forward * -15f);
        }
    }

    IEnumerator Rotate(float duration)
    {
        float t = 0.0f;
        while ( t  < duration )
        {
            t += Time.deltaTime;
            transform.Rotate (Vector3.forward * -3f);
            yield return null;
        }
    }
}
