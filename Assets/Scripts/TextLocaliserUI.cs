using TMPro;
using UnityEngine;

// На объект котор нужен перевод
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextLocaliserUI : MonoBehaviour
{
    [SerializeField] private string _key;
    private TextMeshProUGUI _textField;

    private void Start()
    {
        _textField = GetComponent<TextMeshProUGUI>();
        string value = LocalizationSystem.GetLocalisedValue(_key);
        _textField.text = value;    
    }
}
