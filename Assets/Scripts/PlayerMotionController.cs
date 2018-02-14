using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour {

    [SerializeField]
    private float _jumpHeight;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _turnSpeed;
    private CharacterController controller;
    private Vector3 moveDirection;

    // Use this for initialization
    void Start () {
        controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

    private void Move()
    {
        
        if(!controller.isGrounded)
        {
            moveDirection.y -= _gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0;
        }
        moveDirection.x = 0;
        moveDirection.z = 0;
        Vector3 newRotation = transform.rotation.eulerAngles;
        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDirection.y = _jumpHeight;
        }
        if(Input.GetKey(KeyCode.A))
        {
            newRotation.y -= _turnSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            newRotation.y += _turnSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward * _moveSpeed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward * _moveSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.Euler(newRotation);
        //transform.Rotate(rotation);
        controller.Move(moveDirection);
    }
}
