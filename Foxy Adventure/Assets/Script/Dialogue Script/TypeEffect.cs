using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypeEffect : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 50f;
    public void Run(string textToType, TMP_Text labelText)
    {
        StartCoroutine(TextType(textToType, labelText));
    }

    // IEnumerator
    private IEnumerator TextType(string textToType, TMP_Text labelText)
    {
        labelText.text = string.Empty;
        yield return new WaitForSeconds(0.2f);

        float t = 0;
        int charIndex = 0;

        // Perulangan animasi typing
        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            labelText.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        labelText.text = textToType;
    }
}
