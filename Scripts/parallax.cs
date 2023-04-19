using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{

    [SerializeField] private Vector2 parallaxeffectMultiplier;
    private Transform camtrans;
    private Vector3 lastcampos;

    //public float parallaxeffect;

    // Start is called before the first frame update
    void Start()
    {
        //Camera mainc= GameObject.Find("MainCamera").GetComponent<Camera>();
        camtrans= Camera.main.transform;
        lastcampos= camtrans.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dMovement= camtrans.position - lastcampos;
        transform.position += new Vector3(dMovement.x * parallaxeffectMultiplier.x,0f);
        lastcampos = camtrans.position;
    }
}
