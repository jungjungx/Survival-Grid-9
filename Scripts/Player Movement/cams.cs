using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cams : MonoBehaviour
{
 public Camera cam1;
 public Camera cam2;

 public int room;
 
 public float[] currentfloor = new float[3];
 public float[] currside= new float[3];
void Start() {
    room = 5;
     cam1.enabled = true;
     cam2.enabled = false;
 }
 
 void Update() {
        room = GameObject.Find("CameraSys").GetComponent<cameracont>().camnum;
        if(room==1){
            cam2.transform.localPosition= new Vector3(currside[0],currentfloor[2],-100f);
        }else if(room==2){
            cam2.transform.localPosition= new Vector3(currside[1],currentfloor[2],-100f);
        }else if(room==3){
            cam2.transform.localPosition= new Vector3(currside[2],currentfloor[2],-100f);
        }else if(room==4){
            cam2.transform.localPosition= new Vector3(currside[0],currentfloor[1],-100f);
        }else if(room==5){
            cam2.transform.localPosition= new Vector3(currside[1],currentfloor[1],-100f);
        }else if(room==6){
            cam2.transform.localPosition= new Vector3(currside[2],currentfloor[1],-100f);
        }else if(room==7){
            cam2.transform.localPosition= new Vector3(currside[0],currentfloor[0],-100f);
        }else if(room==8){
            cam2.transform.localPosition= new Vector3(currside[1],currentfloor[0],-100f);
        }else if(room==9){
            cam2.transform.localPosition= new Vector3(currside[2],currentfloor[0],-100f);
        }
 }
}
