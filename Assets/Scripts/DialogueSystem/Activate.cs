using UnityEngine;

public class Activate : MonoBehaviour, IInteract
{
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject){
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && other.TryGetComponent(out Player player)){
            player.Interact = this;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player") && other.TryGetComponent(out Player player)){
            if(player.Interact is Activate dialogueActivator && dialogueActivator == this){
                player.Interact = null;
            }
        }
    }

    public void Interact(Player player){
        if(TryGetComponent(out DialogueResponseEvents responseEvents) && responseEvents.DialogueObject == dialogueObject){
            player.DialogueUI.AddResponseEvents(responseEvents.Events);
        }
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}