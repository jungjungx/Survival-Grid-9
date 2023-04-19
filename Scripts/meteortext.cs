using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class meteortext : MonoBehaviour
{
    public float timer;
    public TMP_Text textDisplay;

    public float timetoDisplay= 0f;
    public float maxtime=0f;

    public bool jammed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jammed= GameObject.Find("phone-jammer").GetComponent<signaljam>().jammerstate;

        timetoDisplay= GameObject.Find("MeteorSpawner").GetComponent<metoerspawner>().timeleft;
        maxtime= GameObject.Find("MeteorSpawner").GetComponent<metoerspawner>().fulltime;
        float minutes = Mathf.FloorToInt((maxtime-timetoDisplay) / 60);
        float seconds = Mathf.FloorToInt((maxtime-timetoDisplay) % 60);

        if(!jammed){

            textDisplay.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
        }else if(jammed){

            textDisplay.SetText("ER:ROR");
        }
        
        //textDisplay= timer;

    }
}
