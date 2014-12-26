using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
    float yOff;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = transform.position;
        yOff = pos.y - player.transform.position.y;
        pos.x = player.transform.position.x;
        pos.y = player.transform.position.y + yOff;
        transform.position = pos;
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        pos.y = player.transform.position.y + yOff;
        transform.position = pos;
        
    }

}
