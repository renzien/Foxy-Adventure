using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypeEffect : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 50f;
    
    private readonly Dictionary<HashSet<char>, float> punctuations = new Dictionary<HashSet<char>, float>()
    {
        {new HashSet<char>() {'.', '!', '?'}, 0.6f},
        {new HashSet<char>() {',', ';', ':'}, 0.3f},
    };

    public Coroutine Run(string textToType, TMP_Text labelText)
    {
        return StartCoroutine(TextType(textToType, labelText));
    }

    // IEnumerator
    private IEnumerator TextType(string textToType, TMP_Text labelText)
    {
        labelText.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        // Perulangan animasi typing
        while (charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;

            t += Time.deltaTime * typeSpeed;

            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;
                labelText.text = textToType.Substring(0, i + 1);
                
                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        labelText.text = textToType;
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (KeyValuePair<HashSet<char>, float> punctuationCategory in punctuations)
        {
            if (punctuationCategory.Key.Contains(character))
            {
                waitTime = punctuationCategory.Value;
                return true;
            }
        }

        waitTime = default;
        return false;
    }
}
