using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 93f, player.transform.position.z);
        transform.position = playerPos;
	}
}
