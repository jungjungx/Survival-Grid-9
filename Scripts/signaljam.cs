using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signaljam : MonoBehaviour
{
    //JAMMER PICTURE FROM https://icons8.com/icon/25187/phone-jammer
    //JAMMER SFX FROM https://www.youtube.com/watch?v=wffIdh0CZWs&ab_channel=ParadoxMirror
    

    public bool jammer_available= false;
    public bool jammerstate= false;

    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        jammer_available= GameObject.Find("Player").GetComponent<PlayerMove_v2>().jammer;

        if(jammerstate){
            sound.volume= 0.5f;
        }else{
            sound.volume= 0;
        }

        if(jammer_available){
            if(Input.GetKeyDown(KeyCode.Space)){
                if(jammerstate){
                    jammerstate= false;
                }else if(!jammerstate){
                    jammerstate= true;
                }
            }
        }
    }
}
