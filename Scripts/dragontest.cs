using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragontest : MonoBehaviour
{

    //dragon and metal door sprites from Open game art . org
    //https://opengameart.org/content/metal-plate
    //https://opengameart.org/content/flappy-dragon-sprite-sheets

    public float speed= 3f;

    public bool vatort= false;
    bool facingleft= false;

    public bool jamuse= false;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if(speed < 0){
            speed= -speed;
            Debug.Log("wtf?");
            FlipSprite();
        }
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //flipping
        float direction = speed;
        if (direction < 0 && facingleft == false)
        {
            FlipSprite();
            facingleft = true;
        }
        else if (direction > 0 && facingleft == true)
        {
            FlipSprite();
            facingleft = false;
        }

}
    private void OnCollisionEnter2D(Collision2D collision){
        speed= -speed;
        rb.velocity = new Vector2(speed, 0f);
    }

        void FlipSprite() {

        Vector3 charscale = transform.localScale;
        charscale.x *= -1.0f;
        transform.localScale = charscale;
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        //Elevator trigger
         if (collision.gameObject.tag == "ElevatorTrigger")
        {
            GameObject.FindWithTag("elevatorpivots").GetComponent<Elevatordoorleft>().nextPos = GameObject.FindWithTag("elevatorpivots").GetComponent<Elevatordoorleft>().pos2.position;
            vatort= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        //Elevator trigger
         if (collision.gameObject.tag == "ElevatorTrigger")
        {
            GameObject.FindWithTag("elevatorpivots").GetComponent<Elevatordoorleft>().nextPos = GameObject.FindWithTag("elevatorpivots").GetComponent<Elevatordoorleft>().pos1.position;
            vatort= false;
        }
    }
}

