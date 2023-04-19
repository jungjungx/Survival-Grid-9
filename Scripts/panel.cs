using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class panel : MonoBehaviour
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
        visible = GameObject.Find("Vents").GetComponent<Vent>().visibility;
        image.color = new Color(image.color.r, image.color.g, image.color.b, visible);
    }
}
