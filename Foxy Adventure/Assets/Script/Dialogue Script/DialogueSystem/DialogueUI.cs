using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel; // Untuk teks dialog
    [SerializeField] private TMP_Text speakerNameLabel; // Untuk nama pembicara
    [SerializeField] private Image speakerImage; // Untuk gambar pembicara

    public bool IsOpen { get; private set; }

    private TypeEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypeEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            var dialogueEntry = dialogueObject.Dialogue[i];

            // Set teks, nama, dan gambar
            textLabel.text = string.Empty; // Kosongkan label sementara efek mengetik berjalan
            speakerNameLabel.text = dialogueEntry.SpeakerName;
            speakerImage.sprite = dialogueEntry.SpeakerImage;

            // Efek mengetik untuk teks
            yield return RunTypingEffect(dialogueEntry.Text);

            textLabel.text = dialogueEntry.Text;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        CloseDialogueBox();
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewriterEffect.Run(dialogue, textLabel);

        while (typewriterEffect.IsRunning)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.E))
            {
                typewriterEffect.Stop();
            }
        }
    }

    public void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        speakerNameLabel.text = string.Empty;
        speakerImage.sprite = null;
    }
}