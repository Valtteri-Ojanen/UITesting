using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _distance;


    [SerializeField]
    private float _speed;

    private float _startDistance;



    // Use this for initialization
    void Awake () {
        transform.position = _target.position - (_target.transform.forward * _distance);
        transform.LookAt(_target);
        _startDistance = _distance;
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector3 newPos = _target.position - (_target.transform.forward * _distance);
        
        RaycastHit hit;
        if(Physics.SphereCast(_target.position, 0.1f, -_target.transform.forward, out hit, _distance))
        {
            newPos = hit.point + _target.transform.forward * 0.2f;
            if(hit.transform.rotation.z != 0)
            {
                float angle = hit.transform.rotation.z * Mathf.Deg2Rad;
                Vector3 y = new Vector3(0, Mathf.Cos(angle) * _distance, 0);

                if(!Physics.SphereCast(_target.position, 0.1f, -_target.transform.forward + y, out hit, _distance))
                {

                    newPos = _target.position - (_target.transform.forward * _distance - y);
                }
            }
           
            
        }
        transform.position = Vector3.Slerp(transform.position, newPos, _speed * Time.deltaTime);
        transform.LookAt(_target);

    }

}
