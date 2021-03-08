using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patrol : MonoBehaviour {

    public Transform playerSprite;

    bool isDown = false;

    void Start() {

    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "PatrolBorder" && !isDown) {
            isDown = true;
        } else if(col.gameObject.tag == "PatrolBorder" && isDown) {
            isDown = false;
        }
    }

    void FixedUpdate()
    {
        if (!isDown) {
            transform.Translate(Vector3.up * Time.deltaTime * 3f);
            playerSprite.Translate(Vector3.up * Time.deltaTime * 0.1f);
        } else {
            transform.Translate(Vector3.down * Time.deltaTime * 3f);
            playerSprite.Translate(Vector3.down * Time.deltaTime * 0.1f);
        }
    }

}