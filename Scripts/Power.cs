using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public float battery= 2000f;
    public float percentage;
    private float total;

    //factors
    private bool elevatoruse= false;
    public float elevatorfactor= 50f;
    public float passivefactor= 2f;

    public float detectorfactor= 10f;

    private bool door6use= false;
    private bool door7use= false;
    private bool door3use= false;
    private bool door4use= false;
    private bool door1use= false;
    private bool door2use= false;
    private bool jamuse= false;
    private bool coveruse= false;
    private bool detectoruse= false;

    private bool camuse= false;

    private bool ventuse= false;
    public float doorfactor= 5f;

    public float ventfactor= 10f;

    public float jamfactor= 5f;
    public float camfactor= 2f;

    public float coverfactor= 7f;

    public Text powerleft;
    void Start()
    {
        total = battery;
        percentage= battery/total;

        //power factors
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //passive loss
        battery -= Time.deltaTime * passivefactor;
        //elevator loos
        elevatoruse= GameObject.Find("Player").GetComponent<PlayerMove_v2>().goingv;
        door6use= GameObject.Find("thedoor6").GetComponent<Door_move>().doorstate;
        door7use= GameObject.Find("thedoor7").GetComponent<Door7>().doorstate;
        door3use= GameObject.Find("thedoor3").GetComponent<Door3>().doorstate;
        door4use= GameObject.Find("thedoor4").GetComponent<Door4>().doorstate;
        door1use= GameObject.Find("thedoor1").GetComponent<Door1>().doorstate;
        door2use= GameObject.Find("thedoor2").GetComponent<Door2>().doorstate;
        jamuse= GameObject.Find("phone-jammer").GetComponent<signaljam>().jammerstate;
        ventuse= GameObject.Find("Vents").GetComponent<Vent>().running;
        camuse= GameObject.Find("CameraSys").GetComponent<cameracont>().camon;
        coveruse= GameObject.Find("MeteorCover").GetComponent<cover>().coveron;
        detectoruse= GameObject.Find("MeteorDetector").GetComponent<detector>().turned;

        if(elevatoruse){
            //Debug.Log("elevator sappin battery");
            battery -= elevatorfactor* Time.deltaTime;
        }
        if(door6use){
            battery -= doorfactor* Time.deltaTime;
        }
        if(door7use){
            battery -= doorfactor* Time.deltaTime;
        }

        if(door3use){
            battery -= doorfactor* Time.deltaTime;
        }

        if(door4use){
            battery -= doorfactor* Time.deltaTime;
        }
        if(door1use){
            battery -= doorfactor* Time.deltaTime;
        }

        if(door2use){
            battery -= doorfactor* Time.deltaTime;
        }

        if(jamuse){
            battery -= jamfactor* Time.deltaTime;
        }

        if(ventuse){
            battery -= ventfactor*Time.deltaTime;
        }

        if(camuse){
            battery -= camfactor*Time.deltaTime;
        }

        if(coveruse){
            battery -= coverfactor*Time.deltaTime;
        }

        if(detectoruse){
            battery -= detectorfactor*Time.deltaTime;
        }

        percentage = battery/total * 100;
        powerleft.text= "PWR LEFT: ";
        powerleft.text += percentage.ToString("0");
        powerleft.text += "%";

        if(battery<0){
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
