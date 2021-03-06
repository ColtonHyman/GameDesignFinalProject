using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text label;

    public bool IsOpen{get; private set;}
    private ResponseHandler responseHandler;
    private TextEffect textEffect;

    private void Start(){
        textEffect = GetComponent<TextEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject){
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents){
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){
        for(int i = 0; i < dialogueObject.Dialogue.Length; i++){
            string dialogue = dialogueObject.Dialogue[i];
            yield return textEffect.Run(dialogue, label);
            if(i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasReponses){
                break;
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if(dialogueObject.HasReponses){
            responseHandler.ShowResponses(dialogueObject.Responses);
        } else {
            CloseDialogueBox();
        }
    }

    public void CloseDialogueBox(){
        IsOpen = false;
        dialogueBox.SetActive(false);
        label.text = string.Empty;
    }
}