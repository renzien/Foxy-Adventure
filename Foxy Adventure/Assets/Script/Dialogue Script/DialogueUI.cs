using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text labelText;
    [SerializeField] private DialogueObject dialogueData;

    private TypeEffect typeEffect;

    private void Start()
    {
        typeEffect = GetComponent<TypeEffect>();
        ClosedDialogueBox();
        ShowDialogue(dialogueData);
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
            yield return typeEffect.Run(dialogue, labelText);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        ClosedDialogueBox();
    }

    private void ClosedDialogueBox()
    {
        dialogueBox.SetActive(false);
        labelText.text = string.Empty;
    }
}
