using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool moving;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moveSpeed = 0.2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !moving){
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if (Input.GetKey(KeyCode.A) && !moving){
           StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKey(KeyCode.S) && !moving){
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if (Input.GetKey(KeyCode.D) && !moving){
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction){
        moving = true;
        float timeElapsed = 0;

        startPosition = transform.position;
        endPosition = startPosition + direction;
        
        while(timeElapsed < moveSpeed){
            transform.position = Vector3.Lerp(startPosition, endPosition, (timeElapsed/moveSpeed));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        moving = false;
    }
}
