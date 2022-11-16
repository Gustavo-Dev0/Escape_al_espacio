using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    public GameObject proyectil;
    public float velocity = 420f;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            GameObject proyectiles= Instantiate(proyectil,transform.position,transform.rotation);
            proyectiles.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0,velocity,0));
        }
    }
}
