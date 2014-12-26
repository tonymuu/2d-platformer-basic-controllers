using UnityEngine;
using System.Collections;

public class GroundCollision : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("perry character"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            { 
                
            }
        }
    }

}
