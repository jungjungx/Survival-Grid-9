using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevatordoorleft : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform StartPos;
    public Vector3 nextPos;
    private bool visibility;
    private bool vist2= false;

    private bool compvist= false;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = StartPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        visibility = GameObject.Find("Player").GetComponent<PlayerMove_v2>().elevatorTrigger;

        vist2= GameObject.FindWithTag("Enemy").GetComponent<dragontest>().vatort;
        
        if(!visibility && !vist2){
            compvist= false;
        }else if(visibility || vist2){
            compvist= true;
        }

        if(compvist){
            nextPos= pos2.position;
        }
        if(!compvist){
            nextPos= pos1.position;
        }
        /*
        if(vist2){
            nextPos= pos2.position;
        }
        if(!vist2){
            nextPos= pos1.position;
        } */
        transform.position = Vector3.MoveTowards(transform.position,nextPos,speed*Time.deltaTime);
    }
}
