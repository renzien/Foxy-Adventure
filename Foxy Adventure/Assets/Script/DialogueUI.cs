using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private TypewriteEffect typewriterEffect;
    private void Start()
    {
        typewriterEffect = GetComponent<TypewriteEffect>();
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
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        }

        CloseDialogBox();
    }

    private void CloseDialogBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
