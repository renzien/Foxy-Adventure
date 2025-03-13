using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text labelText;

    public bool IsOpen { get; private set; }

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
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    public void AddRepsonseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);

            labelText.text = dialogue;

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;

            yield return null;

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

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typeEffect.Run(dialogue, labelText);
        while (typeEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.E))
            {
                typeEffect.Stop();
            }
        }
    }

    private void ClosedDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        labelText.text = string.Empty;
    }
}
