using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_v2 : MonoBehaviour
{
    //PLAYER Sprites were made by Jungwoo Kwak (me)
    //Tileset is from ExceptRea on ArtStation
    //https://www.artstation.com/marketplace/p/xKV3z/2d-platformer-tileset-laboratory

    Animator anim;
    Rigidbody2D rb;
    bool facingleft;
    bool amogus_state = false;
    float jumpvalue;

    public float ms = 5f;
    public float isWalking;
    public bool clicked;
    public float jumpheight= 0.01f;

    public int currfloor;
    public bool goingv;

    public bool invincible= false;

    //triggers
    public bool interaction_available= false;

    public bool jammer = false;

    public bool crank= false;

    public bool cams_avail= false;

    public bool ventbutton= false;

    public bool detector= false;

    public bool coveravail= false;
    //DOOR TRIGGERS
    public bool door_available= false;
    public bool door_available7= false;
    public bool door_available1= false;
    public bool door_available2= false;
    public bool door_available3= false;
    public bool door_available4= false;

    //elevator trigger
    public bool elevatorTrigger = false;

    //audio code
     public AudioClip[] footClips;
     public AudioSource audioSource;

     public AudioListener audioListener;
     //public AudioClip elevatording;

    //elevator code
      public float[] playervert = new float[3];
      private bool isrunning = false;

    // Start is called before the first frame update
    void Start()
    {
        facingleft = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //is starting floor
        currfloor= 0;

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetButton("Jump");
        if (jump)
        {
            jumpvalue = jumpheight;
        }
   

        //movement

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * ms;

        //animation

        if (movement.x != 0)
        {
            isWalking = 1;
        }
        else {
            isWalking = 0;
        }
        anim.SetFloat("speed", isWalking);


        //flipping
        float direction = movement.x;
        if (direction < 0 && facingleft == false)
        {
            FlipSprite();
            facingleft = true;
        }
        else if (movement.x > 0 && facingleft == true)
        {
            FlipSprite();
            facingleft = false;
        }



        //when right clicking

        clicked = Input.GetMouseButtonDown(1);

        if (clicked && !amogus_state) {
            //changing to right size
            Vector3 sus = transform.localScale;
            sus.x = 0.2f; sus.y = 0.2f;
            transform.localScale = sus;

            anim.SetFloat("click", 1);
            Debug.Log("What have you done???");
            amogus_state = true;
        }else if (clicked && amogus_state) {
            Vector3 sus = transform.localScale;
            sus.x = 1f; sus.y = 1f;
            transform.localScale = sus;

            anim.SetFloat("click", -1);
            Debug.Log("Nothing happened");
            amogus_state = false;
        }

        //elevator code
             if(Input.GetKeyDown("w") && elevatorTrigger && currfloor<=1 && !isrunning){
                    StartCoroutine(iframes(2f));
                    currfloor++;
                    Debug.Log(currfloor);
                 //to avoid going out of array
                if(currfloor>2){
                    currfloor--;
                }
                Vector3 movemente = new Vector3(transform.position.x, playervert[currfloor]+2, 0f);
                transform.position = movemente;
                goingv= true;




                StartCoroutine(waiting(1f));
                

            }

             if(Input.GetKeyDown("s") && elevatorTrigger && currfloor>=1 && isrunning== false){
                    StartCoroutine(iframes(2f));
                    currfloor--;
                    Debug.Log(currfloor);
                //to avoid going out of array
                if(currfloor<0){
                    currfloor++;
                }
                Vector3 movemente = new Vector3(transform.position.x, playervert[currfloor]+3, 0f);
                transform.position = movemente;
                goingv= true;




                StartCoroutine(waiting(1f));
                

            }

    }

    void FlipSprite() {

        Vector3 charscale = transform.localScale;
        charscale.x *= -1.0f;
        transform.localScale = charscale;
        
    }


    // interativity code
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactive")
        {
            //Debug.Log("Interaction available to player (from playermove)");
            interaction_available= true;
        }

        //DOOR TRIGGERS
         if (collision.gameObject.tag == "DoorButtons")
        {
            //Debug.Log("Manipulate door?");
            door_available= true;
        }

         if (collision.gameObject.tag == "seven")
        {
            //Debug.Log("Manipulate door?");
            door_available7= true;
        }

         if (collision.gameObject.tag == "three")
        {
            //Debug.Log("Manipulate door?");
            door_available3= true;
        }

         if (collision.gameObject.tag == "four")
        {
            //Debug.Log("Manipulate door?");
            door_available4= true;
        }

         if (collision.gameObject.tag == "one")
        {
            //Debug.Log("Manipulate door?");
            door_available1= true;
        }

         if (collision.gameObject.tag == "two")
        {
            //Debug.Log("Manipulate door?");
            door_available2= true;
        }
        /*
         if (collision.gameObject.tag == "three")
        {
            //Debug.Log("Manipulate door?");
            door_available3= true;
        }
        */

        //Elevator trigger
         if (collision.gameObject.tag == "ElevatorTrigger")
        {
            //Debug.Log("You are at the elevator");
            elevatorTrigger= true;
        }
        //Jammer trigger
         if (collision.gameObject.tag == "jammer")
        {
            //Debug.Log("Manipulate door?");
            jammer= true;
        }

        //crank trigger
         if (collision.gameObject.tag == "crank")
        {
            //Debug.Log("Manipulate door?");
            crank=true;
        }

        //vent trigger
         if (collision.gameObject.tag == "vent")
        {
            //Debug.Log("Manipulate door?");
            ventbutton=true;
        }

        //cams trigger
         if (collision.gameObject.tag == "cams")
        {
            //Debug.Log("Manipulate door?");
            cams_avail=true;
        }

        //cover trigger
        if (collision.gameObject.tag == "cover")
        {
            //Debug.Log("Manipulate door?");
            coveravail=true;
        }

        //dtector trigger
        if (collision.gameObject.tag == "detector")
        {
            //Debug.Log("Manipulate door?");
            detector=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Interactive")
        {
            //Debug.Log("Interaction no longer available to player");
            interaction_available = false;
        }

        //DOOR TRIGGERS
        if (collision.gameObject.tag == "DoorButtons")
        {
            //Debug.Log("cant door no longer?");
            door_available = false;
        }

        if (collision.gameObject.tag == "seven")
        {
            //Debug.Log("Manipulate door?");
            door_available7= false;
        }

         if (collision.gameObject.tag == "three")
        {
            //Debug.Log("Manipulate door?");
            door_available3= false;
        }

         if (collision.gameObject.tag == "four")
        {
            //Debug.Log("Manipulate door?");
            door_available4= false;
        }

         if (collision.gameObject.tag == "one")
        {
            //Debug.Log("Manipulate door?");
            door_available1= false;
        }

         if (collision.gameObject.tag == "two")
        {
            //Debug.Log("Manipulate door?");
            door_available2= false;
        }

        //Elevator trigger
         if (collision.gameObject.tag == "ElevatorTrigger")
        {
            //Debug.Log("Manipulate door?");
            elevatorTrigger= false;
        }

        //Jammer trigger
         if (collision.gameObject.tag == "jammer")
        {
            //Debug.Log("Manipulate door?");
            jammer= false;
        }
        //crank trigger
         if (collision.gameObject.tag == "crank")
        {
            //Debug.Log("Manipulate door?");
            crank=false;
        }

        //vent trigger
         if (collision.gameObject.tag == "vent")
        {
            //Debug.Log("Manipulate door?");
            ventbutton=false;
        }

        //cams trigger
         if (collision.gameObject.tag == "cams")
        {
            //Debug.Log("Manipulate door?");
            cams_avail=false;
        }

        //cover trigger
        if (collision.gameObject.tag == "cover")
        {
            //Debug.Log("Manipulate door?");
            coveravail=false;
        }

                //dtector trigger
        if (collision.gameObject.tag == "detector")
        {
            //Debug.Log("Manipulate door?");
            detector=false;
        }
    }

    private void Footstep(){
        //Debug.Log("play footstep sound");
        int rand = Random.Range(0, footClips.Length -1);
        audioSource.clip = footClips[rand];
        audioSource.Play();
        //audioSource.PlayOneShot(clip);
    }

    IEnumerator waiting(float time)
{
    float counter = 0;
    //Debug.Log("running timing code");
    float temp=ms;


    while (counter <= time)
    {
        counter += Time.deltaTime;

        //DO YOUR STUFF HERE
        ms= 0;
        isrunning = true;
        //Wait for a frame so that we don't freeze Unity
        yield return null;
    }
        //Debug.Log("no v");
        ms= temp;
        goingv= false;
        isrunning= false;



}
    IEnumerator iframes(float time){
        float counter = 0f;
        invincible= true;
        while(counter<=time){
            counter += Time.deltaTime;

            yield return null;
        }
        invincible= false;
    }

}

