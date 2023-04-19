using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metoerspawner : MonoBehaviour
{

    //meteor sfxs are from:
    //https://www.freesoundeffects.com/free-sounds/explosion-10070/

    public bool cover= false;
    

    public AudioSource sound;

    public AudioClip block;
    public AudioClip explode;

    public float timeleft;
    public float fulltime;
    public float explosivisible= 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MeteorSpawn",10f);
    }

    // Update is called once per frame
    void Update()
    {
        cover= GameObject.Find("MeteorCover").GetComponent<cover>().coveron;
    }

    void MeteorSpawn(){
        Debug.Log("meteor is coming");
        StartCoroutine(Incoming(69f)); //should be 75

        
    }

    IEnumerator Incoming(float duration)
    {
        float t = 0.0f;
        fulltime= duration;
        while ( t  < duration )
        {
            t += Time.deltaTime;
            timeleft= t;

            yield return null;
        }
        Debug.Log("impact incoming");
        Impact();
        Invoke("MeteorSpawn", Random.Range(1f,29f)); //1 to 15f
    }

    void Impact(){
        if(cover){
            sound.clip = block;
            sound.Play();
            //Debug.Log("meteor blocked");
        }else if(!cover){
            sound.clip= explode;
            sound.Play();
            StartCoroutine(wait(1.5f));
        }
    }

    IEnumerator wait(float duration){
        float t= 0.0f;
        while(t < duration){
            t+= Time.deltaTime;
            explosivisible+= 0.03f;
            yield return null;
        }
        FindObjectOfType<GameManager>().GameOver();
    }
}
