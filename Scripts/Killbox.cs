using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour
{
    public AudioSource oof;
    public bool immune=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        immune=  GameObject.Find("Player").GetComponent<PlayerMove_v2>().invincible;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player" && !immune) {
            oof.Play();
            StartCoroutine(waiting(0.7f));

        }
    }

     IEnumerator waiting(float time)
{
    float counter = 0;
    GameObject.Find("Player").GetComponent<PlayerMove_v2>().ms= 0f;

    while (counter <= time)
    {
        counter += Time.deltaTime;

        //DO YOUR STUFF HERE
        //Wait for a frame so that we don't freeze Unity
        yield return null;
    }
        FindObjectOfType<GameManager>().GameOver();

}

}
