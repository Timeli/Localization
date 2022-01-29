using TMPro;
using UnityEngine;

// �� ������ ����� ����� �������
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
