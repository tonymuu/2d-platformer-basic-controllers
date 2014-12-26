using UnityEngine;
using System.Collections;

public class BKGCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Collide left: " + collider.name);

        float widthOfObject = ((BoxCollider2D)collider).size.x;

        Vector3 pos = collider.transform.position;

        pos.x +=  4 * widthOfObject;

        collider.transform.position = pos;
    }
}
