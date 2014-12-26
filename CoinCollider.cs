using UnityEngine;
using System.Collections;

public class CoinCollider : MonoBehaviour {
    private bool collected = false;
    int coinID;
    GameObject[] coin;
	// Use this for initialization
	void Start () {
        coin = GameObject.FindGameObjectsWithTag("coin");
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (collected)
        {
            //Destroy(coin);

            return;
        }
       else
        {
            
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Equals("perry character"))
        {
            Debug.Log("Perry collected!" + collider.name);
            collected = true;
            
        }

    }
}
