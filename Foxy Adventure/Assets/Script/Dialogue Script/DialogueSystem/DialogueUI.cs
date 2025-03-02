using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text labelText;

    public bool isOpen { get; private set;}

    private ResponseHandler responseHandler;
    private TypeEffect typeEffect;

    private void Start()
    {
        typeEffect = GetComponent<TypeEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        ClosedDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeEffect.Run(dialogue, labelText);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);       
        }
        else
        {
            ClosedDialogueBox();
        }
    }

    private void ClosedDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        labelText.text = string.Empty;
    }
}
