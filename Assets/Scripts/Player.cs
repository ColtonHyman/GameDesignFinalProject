using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    private bool moving;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moveSpeed = 0.2f;

    public DialogueUI DialogueUI => dialogueUI;
    public IInteract Interact {get; set;}

    void Update()
    {
        if(dialogueUI.IsOpen){
            return;
        }

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
        
        if (Input.GetKeyDown(KeyCode.Space)){
            if(Interact != null){
                Interact.Interact(this);
            }
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

    public void EndGame(){
        SceneManager.LoadScene("_Scene02");
    }
}
