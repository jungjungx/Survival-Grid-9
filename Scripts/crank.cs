using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crank : MonoBehaviour
{

    //crank sfx- https://www.youtube.com/watch?v=w9rBk7990ZM&ab_channel=FreeSoundFXs
    //crank png - https://in.pinterest.com/pin/634163191255334556/
    public bool crank_available= false;
    public float base_crank_power;
    public float crank_power;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        crank_power= base_crank_power;
    }

    // Update is called once per frame
    void Update()
    {
        crank_available= GameObject.Find("Player").GetComponent<PlayerMove_v2>().crank;

        if(GameObject.Find("Power").GetComponent<Power>().percentage <15){
            crank_power= base_crank_power*2.5f;
        }
        else if(GameObject.Find("Power").GetComponent<Power>().percentage <30){
            crank_power= base_crank_power*1.6f;
        }
        else if(GameObject.Find("Power").GetComponent<Power>().percentage <50){
            crank_power= base_crank_power*1.4f;
        }
        else if(GameObject.Find("Power").GetComponent<Power>().percentage <100){
            crank_power= base_crank_power;
        }

        if(crank_available){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(GameObject.Find("Power").GetComponent<Power>().battery <= 3000){
                    sound.Play();
                    GameObject.Find("Power").GetComponent<Power>().battery+= crank_power;
                    StartCoroutine(Rotate(1f));
                }

            }
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
