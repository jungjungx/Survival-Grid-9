using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_move : MonoBehaviour
{
    private bool ponbutton;
    public bool doorstate;
    public float ascendspeed = 0.3f;
    public float ascendstop = 5f;
    private float ascend;
    private bool running;

    public AudioSource audioSource;
    public AudioClip door1;
    public AudioClip door2;

    private float before;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        doorstate= false;
        running= false;
        rb = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        ponbutton = GameObject.Find("Player").GetComponent<PlayerMove_v2>().door_available;

        //if player is on button and presses spacebar
        if(ponbutton==true && running==false){
            if(Input.GetKeyDown(KeyCode.Space)){
                //Debug.Log("you activated door button");
                if(doorstate){
                    Debug.Log("you open the door");
                    StartCoroutine(playClose());
                    StartCoroutine(executeInWithFixedTiming2(3));
                    doorstate= false; 
                    
                }else if(!doorstate){
                    Debug.Log("you close the door");
                    StartCoroutine(playOpen());
                    StartCoroutine(executeInWithFixedTiming(3));
                    doorstate = true;
                }
            }
        }
    }

    IEnumerator executeInWithFixedTiming(float time)
{

    float counter = 0;
    //Debug.Log("running timing code");
    ascend= ascendspeed;
    
    while (counter <= time)
    {
            Vector3 uppos = new Vector3(57.2f, 17f, 0f);
            Vector3 downedpos = new Vector3(57.2f, 9.9f, 0f);
        counter += Time.deltaTime;
        running= true;

        //DO YOUR STUFF HERE
        transform.localPosition = Vector3.MoveTowards(downedpos,uppos,ascendspeed*counter);
        //Debug.Log(ascendspeed*Time.deltaTime);
        /*
        ascend += ascendstop;
        Vector3 movement = new Vector3(0f, ascend, 0f);
        transform.position += movement * Time.deltaTime;
        */
        //Debug.Log(ascend);
        //Wait for a frame so that we don't freeze Unity
        yield return null;
    }
    

    running= false;
}

    IEnumerator executeInWithFixedTiming2(float time)
{
    Vector3 uppos = new Vector3(57.2f, 17f, 0f);
    Vector3 downedpos = new Vector3(57.2f, 9.9f, 0f);
    float counter = 0;
    //Debug.Log("running timing code");
    ascend= ascendspeed;
    
    while (counter <= time)
    {
        
        counter += Time.deltaTime;
        running= true;
        //DO YOUR STUFF HERE
        transform.localPosition = Vector3.MoveTowards(uppos,downedpos,ascendspeed*counter);
        /*
        ascend += ascendstop;
        Vector3 movement = new Vector3(0f, -ascend, 0f);
        transform.position += movement * Time.deltaTime;
        */
       //Debug.Log(ascend);
        //Wait for a frame so that we don't freeze Unity
        yield return null;
    }
    //Debug.Log("out of loop");

    running= false;
}

         IEnumerator playClose()
         {
             audioSource.clip = door1;
             audioSource.Play();
             yield return new WaitForSeconds(audioSource.clip.length);
             GetComponent<AudioSource>().clip = door2;
             audioSource.Play();
         }

         IEnumerator playOpen()
         {
             audioSource.clip = door2;
             audioSource.Play();
             yield return new WaitForSeconds(audioSource.clip.length);
             GetComponent<AudioSource>().clip = door1;
             audioSource.Play();
         }

}
