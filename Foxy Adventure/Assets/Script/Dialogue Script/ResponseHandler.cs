using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    public void ShowResponses(Response[] responses)
    {
        float responseBoxWidth = 0;

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));

            responseBoxWidth += responseButtonTemplate.sizeDelta.x;
        }

        responseBox.sizeDelta = new Vector2(responseBoxWidth, responseBox.sizeDelta.y);
        responseBox.gameObject.SetActive(true);
    }

    private void OnPickedResponse(Response response)
    {

    }
}
