using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class detector : MonoBehaviour
{

    //DETECTOR SFX IS FROM TEAM FORTRESS 2- 2FORT AMBIENT NOISE

    public bool detector_available= false;
    public bool turned= false;
    public SpriteRenderer blackedscrn;

    public AudioSource sound;
    public AudioClip scan;
    public AudioClip jammedsound;

    public bool jammed= false;

    // Start is called before the first frame update
    void Start()
    {
        blackedscrn.color = new Color(blackedscrn.color.r, blackedscrn.color.g, blackedscrn.color.b, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        detector_available= GameObject.Find("Player").GetComponent<PlayerMove_v2>().detector;
        jammed= GameObject.Find("phone-jammer").GetComponent<signaljam>().jammerstate;

        if(detector_available){
            if(jammed){
                    sound.clip= jammedsound;
                }else{
                    sound.clip= scan;
                }
            
            if(Input.GetKeyDown(KeyCode.Space)){

                
                if(turned){
                    blackedscrn.color = new Color(blackedscrn.color.r, blackedscrn.color.g, blackedscrn.color.b, 1f);
                    sound.volume = 0f;
                    turned= !turned;
                }else if(!turned){
                    sound.Play();
                    sound.volume= 0.7f;
                    blackedscrn.color = new Color(blackedscrn.color.r, blackedscrn.color.g, blackedscrn.color.b, 0f);
                    turned= !turned;
                }
            }
        }
    }
}
