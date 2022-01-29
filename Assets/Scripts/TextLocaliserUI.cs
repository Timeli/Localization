using TMPro;
using UnityEngine;

// На объект котор нужен перевод
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    private TextMeshProUGUI _textField;
    public LocalisedString localisedString;

    private void Start()
    {
        _textField = GetComponent<TextMeshProUGUI>();
        _textField.text = localisedString.Value;    
    }
}
