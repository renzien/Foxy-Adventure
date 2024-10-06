using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private ResponseHandler responseHandler;
    private TypewriteEffect typewriterEffect;
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriteEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasReponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        }

        if (dialogueObject.HasReponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogBox();
        }
    }

    private void CloseDialogBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
