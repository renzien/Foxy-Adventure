using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 50f;
    public Coroutine Run(string textToType, TMP_Text labelText)
    {
        return StartCoroutine(TypeText(textToType, labelText));
    }

    private IEnumerator TypeText(string textToType, TMP_Text labelText)
    {
        labelText.text = string.Empty;

        float f = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            f += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(f);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            labelText.text = textToType.Substring(0, charIndex);

            yield return null;
        } 

        labelText.text = textToType;
    }
}
