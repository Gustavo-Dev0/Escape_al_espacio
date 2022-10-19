using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 _currentVelocity;
    private Vector3 _desiredVelocity;
    private Vector3 _steeringVelocity;
    private float _maxVelocity = 4;
    private float _maxForce = 0.25f;
    Vector3 target;


    public float speed = 0.1f;
    public float accuracy = 0.01f;

    private Rigidbody _rigidbody;
    public float m_speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*this.transform.LookAt(target);
        Vector3 direction = target - this.transform.position;

        Debug.DrawRay(this.transform.position, direction, Color.red);

        if(direction.magnitude > accuracy)
            this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);*/

        if (Input.GetKey (KeyCode.UpArrow)) // Frente
        {
            this.transform.Translate(Vector3.forward*m_speed*Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.DownArrow)) // Después
        {
            this.transform.Translate(Vector3.forward *- m_speed * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.LeftArrow)) // Izquierda
        {
            this.transform.Translate(Vector3.right *-m_speed * Time.deltaTime);
        }
        if (Input.GetKey (KeyCode.RightArrow)) // Derecha
        {
            this.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
        }

    }


    public void movePlayer(Vector3 mouseP){
        //Debug.Log("click");
        Debug.Log(mouseP);

        //mouseP.y = 0;
        target = mouseP;




    }
}
