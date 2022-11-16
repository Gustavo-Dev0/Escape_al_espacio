using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon1 : MonoBehaviour
{
    public GameObject proyectil;
    public float velocity = 460f;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            GameObject proyectiles= Instantiate(proyectil,transform.position,transform.rotation);
            proyectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0,velocity,0));
        }
    }
}
