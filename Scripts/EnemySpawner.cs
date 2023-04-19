using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //ENEMY SPAWN ALERT SFX, DOOR OPEN/CLOSE SFX ARE FROM STARCRAFT SFX
    //http://www.hazmatt.net/gaming/starcraft/terran/units/index.html
    // Start is called before the first frame update
    public GameObject[] enemies;
    public float spawnStart;
    public float spawnTime;
    public float baseStart;
    public float baseTime;

    public AudioSource ass;
    public AudioClip spawned;
    private int chosenfloor;
    public bool jammeron= false;

    private int isleft;
    private float left= 0;

    //randomnizing spawn floors
    public float[] currentfloor = new float[3];

    void Start()
    {
        jammeron= GameObject.Find("phone-jammer").GetComponent<signaljam>().jammerstate;
        baseStart= spawnStart;
        baseTime= spawnTime;

        Invoke("Spawn",spawnStart);
        InvokeRepeating("Spawnrate",10f,2f); //change spawnTime every # secs
    }

    void FixedUpdate(){
        jammeron= GameObject.Find("phone-jammer").GetComponent<signaljam>().jammerstate;
    }

    void Spawn(){
        //for next
         Vector3 SpawnPos= transform.position; 
        chosenfloor= Random.Range(0, 3);
        //Debug.Log(chosenfloor);
        isleft= Random.Range(0,2);
        if(isleft==1){
            left= 55;
        }else if(isleft==0){
            left= 2;
        }

        SpawnPos = new Vector3(transform.position.x+left,currentfloor[chosenfloor],transform.position.z);

        Instantiate(enemies[0],SpawnPos, transform.rotation);
        ass.Play();

        Debug.Log("next one will spawn in:"+ spawnTime);
        Invoke("Spawn",spawnTime);
    }

    void Spawnrate(){
        //Debug.Log("changing rate...");
        if(!jammeron){
            spawnStart = baseStart + Random.Range(-2,2);
            spawnTime = baseTime + Random.Range(-2,2);
        }else if(jammeron){
           // Debug.Log("jammer was on, spawning gonna be less frequent...");
            spawnStart = baseStart/2 + Random.Range(-5,10);
            spawnTime = baseTime+ baseTime/1.7f + Random.Range(-2,20);
        }
    }
}
