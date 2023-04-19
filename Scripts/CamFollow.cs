using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamFollow : MonoBehaviour
{
    //MUSIC ARE ALL FROM STARTCRAFT 1
    //MAIN MENU THEME- STARCRAFT MENU THEME
    //GAME THEME- STARCRAFT TERRAN THEME 2
    //WIN THEME- STARCRAFT TERRAN WIN THEME

    GameObject character;
    Vector3 offset;
    Vector3 floorchange;

    //music stuff
    AudioSource music;
    bool musicToggle;

    
     public AudioSource audioSource2;
    public AudioClip elevatording;


    public float rightmax = 4f;
    public float leftmax = -42f;
    private bool vertical;
    private bool changed;

    private int curr;

    public float speed;

    public float[] currentfloor = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position;
        //curr is current floor
        curr= GameObject.Find("Player").GetComponent<PlayerMove_v2>().currfloor;
        vertical = false;
        changed= vertical;

        //music stuff
        music = GetComponent<AudioSource>();
        musicToggle = true;

        StartCoroutine(waiting(0.6f));
    }

    // Update is called once per frame
    void Update()
    {

        curr= GameObject.Find("Player").GetComponent<PlayerMove_v2>().currfloor;
        vertical= GameObject.Find("Player").GetComponent<PlayerMove_v2>().goingv;
        
        if(changed!=vertical){
                audioSource2.clip = elevatording;
                audioSource2.Play();
                StartCoroutine(waiting(0.6f));

        }

       if(vertical){
            floorchange= offset;
            floorchange.y= currentfloor[curr];
            //Debug.Log(floorchange.y);
            transform.position = Vector3.MoveTowards(transform.position,floorchange,speed*Time.deltaTime);
            //Debug.Log(speed*Time.deltaTime);
            offset.y= floorchange.y;
       }

        if(!vertical){
            //Debug.Log(character.transform.position.x);
            offset.x = character.transform.position.x;
            if (character.transform.position.x < rightmax && character.transform.position.x > leftmax && curr!=2) //camara cant get past this point
            {
                transform.position = offset;
             }else if(curr==2){
                transform.position = offset;

             }

        }



        //music stuff
        if (Input.GetKeyDown("m"))
        {
            musicToggle = !musicToggle;

            if (musicToggle) {
                music.volume = 0.25f;
            }
            else if (!musicToggle) {
                music.volume = 0.0f;
            }



        }


    }


 IEnumerator waiting(float time)
{
    float counter = 0;

    while (counter <= time)
    {
        counter += Time.deltaTime;

        //DO YOUR STUFF HERE
        //Wait for a frame so that we don't freeze Unity
        yield return null;
    }
        //Debug.Log("no v");
        changed = true;
}

}
