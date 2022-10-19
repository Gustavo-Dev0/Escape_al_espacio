using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingMovement : MonoBehaviour
{
    private Vector3 _currentVelocity;
    private Vector3 _desiredVelocity;
    private Vector3 _steeringVelocity;
    private float _maxVelocity = 4;
    private float _maxForce = 0.25f;
    public Transform enemy;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 target = enemy.position;
        _desiredVelocity = (target - transform.position).normalized;
        Vector3 s = target - transform.position;
        //Debug.Log(s.magnitude);

        if(s.magnitude > 5){
            return;
        }

        if(s.magnitude < 1){
            return;
        }

        _desiredVelocity *= _maxVelocity;

        _steeringVelocity = _desiredVelocity - _currentVelocity;
        _steeringVelocity = Vector3.ClampMagnitude(_steeringVelocity, _maxForce);
        _steeringVelocity /= _rigidbody.mass;

        _currentVelocity += _steeringVelocity;
        _currentVelocity = Vector3.ClampMagnitude(_currentVelocity, _maxVelocity);

        transform.position += _currentVelocity * Time.deltaTime;
        transform.forward += _currentVelocity * Time.deltaTime;
    }
}
