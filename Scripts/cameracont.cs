using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracont : MonoBehaviour
{

    //CAMERA SFXS ARE FROM FIVE NIGHTS AT FREDDYS
    
    public bool camsavail= false;

    public bool camon= false;

    public int camnum= 5;

    public int currcam;

    public AudioSource sound;

    public AudioClip open;
    public AudioClip close;
    public AudioClip change;

    public Camera seccam;
    // Start is called before the first frame update
    void Start()
    {
       currcam= camnum;
    }

    // Update is called once per frame
    void Update()
    {
        camsavail= GameObject.Find("Player").GetComponent<PlayerMove_v2>().cams_avail;
        if(currcam!=camnum){
            sound.clip= change;
            sound.Play();
            currcam= camnum;
        }    

        if(camsavail){
            if(Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("camarastuff");
                if(camon){
                    GameObject.Find("SecurityCam").GetComponent<cams>().cam2.enabled= false;
                    GameObject.Find("lightsrc").GetComponent<Light>().intensity= 0f;
                    sound.clip= close;
                    camon= false;
                }else if(!camon){
                    sound.clip= open;
                    GameObject.Find("SecurityCam").GetComponent<cams>().cam2.enabled= true;
                    GameObject.Find("lightsrc").GetComponent<Light>().intensity= 7f;
                    camon= true;
                }
                sound.Play();
            }

            if(Input.GetKeyDown(KeyCode.Alpha1)){
                camnum=1;
            }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                camnum=2;
            }else if(Input.GetKeyDown(KeyCode.Alpha3)){
                camnum=3;
            }else if(Input.GetKeyDown(KeyCode.Alpha4)){
                camnum=4;
            }else if(Input.GetKeyDown(KeyCode.Alpha5)){
                camnum=5;
            }else if(Input.GetKeyDown(KeyCode.Alpha6)){
                camnum=6;
            }else if(Input.GetKeyDown(KeyCode.Alpha7)){
                camnum=7;
            }else if(Input.GetKeyDown(KeyCode.Alpha8)){
                camnum=8;
            }else if(Input.GetKeyDown(KeyCode.Alpha9)){
                camnum=9;
            }else if(Input.GetKeyDown("q")){
                if(camnum<=1){
                    camnum= 9;
                }else {
                    camnum-= 1;
                }
            }else if(Input.GetKeyDown("e")){
                if(camnum==9){
                    camnum= 1;
                }else {
                    camnum+= 1;
                }
            }
        }
    }
}
