using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vent : MonoBehaviour
{

    public bool ventavailable= false;
    public float visibility= 0f;
    public float visibility2= 0f;
    public bool running= false;
    private bool isclogging= false;
    private float basems;

    public AudioSource sound;

    public AudioClip ventfans;
    public AudioClip gasping;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        basems= GameObject.Find("Player").GetComponent<PlayerMove_v2>().ms;
        Invoke("clogging",Random.Range(40f,55f));
        //Invoke("clogging",10f);
    }

    // Update is called once per frame
    void Update()
    {
        ventavailable= GameObject.Find("Player").GetComponent<PlayerMove_v2>().ventbutton;
        if(ventavailable && !running){
            if(Input.GetKeyDown(KeyCode.Space)){
                declog();
                //StartCoroutine(Rotate(5f));
            }
        }
    }

    void clogging(){
        Debug.Log("clogging has started...");
        isclogging= true;
        StartCoroutine(fuzzing(25f));
        //Invoke("clogging",Random.Range(40f,75f));
    }

    void declog(){
        running= true;
        isclogging= false;
        Debug.Log("declogging");

        StartCoroutine(defuzzing(6f));
        CancelInvoke();
        Invoke("clogging",Random.Range(35f,55f)); //change these values
    }
    IEnumerator fuzzing(float duration)
    {
        float t = 0.0f;
        float tpersec= 0.0f;
        while ( t  < duration && isclogging)
        {
            //Debug.Log(visibility);
            t += Time.deltaTime;
            tpersec+= Time.deltaTime;
            if(tpersec >=1f){
                tpersec= tpersec%1f;
                if(visibility < 0.8){
                    visibility+= 0.04f;
                    if(GameObject.Find("Player").GetComponent<PlayerMove_v2>().ms > basems/1.6f){
                        GameObject.Find("Player").GetComponent<PlayerMove_v2>().ms-= visibility;
                    }
                }
            }
            yield return null;
        }
        Debug.Log("starting to choke");
        sound.clip = gasping;
        sound.Play();
        StartCoroutine(choking(12f));
    }

    IEnumerator defuzzing(float duration)
    {
        sound.clip = ventfans;
        sound.Play();
        float t = 0.0f;
        while ( t  < duration)
        {
            //Debug.Log(visibility);
            t += Time.deltaTime;
            GameObject.Find("Player").GetComponent<PlayerMove_v2>().ms= basems;
            if(visibility > 0f && t>0.5f){
                visibility-= 0.05f;
            }
            if(visibility2 >0f){
                visibility2-= 0.05f;
            }
            yield return null;
        }
        running= false;

    }


    IEnumerator choking(float duration){
        float t = 0.0f;
        float tpersec = 0.0f;
        bool pulse1= true;
        bool pulse2= false;

        if(!isclogging){
                    sound.clip = ventfans;
                 sound.Play();
        }

        while(t < duration && isclogging){
            t+= Time.deltaTime;
            tpersec+= Time.deltaTime;
            if(tpersec>=1f){
                if(pulse1){
                    visibility= 0.8f;
                    pulse1=false;
                    pulse2=true;
                }else if(pulse2){
                    visibility= 0.85f;
                    pulse2=false;
                    pulse1=true;
                }

                if(t>duration/2f){
                    visibility2+= 0.2f;
                }
                tpersec= tpersec%1f;
            }
            yield return null;
        }
        if(isclogging){
            FindObjectOfType<GameManager>().GameOver();
        }
    }

}
