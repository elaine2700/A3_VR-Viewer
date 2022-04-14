using UnityEngine;
using TMPro;

public class Names : MonoBehaviour
{
    TextMeshPro nameField;

    private void Start()
    {
        nameField = GetComponent<TextMeshPro>();
        DisplayName(false);
    }

    public void DisplayName(bool show)
    {
        nameField.enabled = show;
    }
}
