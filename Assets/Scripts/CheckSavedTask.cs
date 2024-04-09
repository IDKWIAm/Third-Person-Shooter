using TMPro;
using UnityEngine;

public class CheckSavedTask : MonoBehaviour
{
    private TextMeshProUGUI _text;
    void Start()
    {
        if (PlayerPrefs.HasKey("Saved Task"))
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = PlayerPrefs.GetString("Saved Task");
            RectTransform parentRectTransform = _text.transform.parent.GetComponent<RectTransform>();
            parentRectTransform.sizeDelta = new Vector2(parentRectTransform.rect.width, PlayerPrefs.GetFloat("Saved Task Height"));
        }
    }
}
