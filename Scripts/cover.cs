using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cover : MonoBehaviour
{

    //cover sfx- https://www.youtube.com/watch?v=896eFuYsPjM&ab_channel=BerlinAtmospheres

    public bool cover_available= false;

    public bool coveron= false;

    private bool running= false;

    public float ascendspeed = 0.8f;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cover_available= GameObject.Find("Player").GetComponent<PlayerMove_v2>().coveravail;

        if(cover_available && !running){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(coveron){
                    StartCoroutine(go_down(8f));
                    source.Play();
                    coveron= false;
                }else if(!coveron){
                    StartCoroutine(go_up(8f));
                    source.Play();

                }
            }
        }

    }

IEnumerator go_up(float time)
{
    Vector3 uppos= new Vector3(37.25f, 27f, 0f);
    Vector3 downpos= new Vector3(37.25f, 18f, 0f);
    float counter = 0;
    //Debug.Log("running timing code");

    while (counter <= time)
    {
        counter += Time.deltaTime;
        running= true;

        transform.localPosition = Vector3.MoveTowards(downpos,uppos,ascendspeed*counter);

        yield return null;
    }
    coveron= true;   
    running= false;
}

IEnumerator go_down(float time)
{
    Vector3 uppos= new Vector3(37.25f, 27f, 0f);
    Vector3 downpos= new Vector3(37.25f, 18f, 0f);
    float counter = 0;
    //Debug.Log("running timing code");

    while (counter <= time)
    {
        counter += Time.deltaTime;
        running= true;

        transform.localPosition = Vector3.MoveTowards(uppos,downpos,ascendspeed*counter);

        yield return null;
    }

    running= false;
}
}
