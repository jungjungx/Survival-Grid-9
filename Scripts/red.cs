using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class red : MonoBehaviour
{
    public Image image;

    public float visible = 0f;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, visible);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        visible = GameObject.Find("MeteorSpawner").GetComponent<metoerspawner>().explosivisible;
        if(visible != 0){
            image.color = new Color(image.color.r, image.color.g, image.color.b, visible);
        }

    }
}
