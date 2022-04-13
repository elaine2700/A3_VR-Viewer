using UnityEngine;
using TMPro;

public class Names : MonoBehaviour
{
    TextMeshPro nameField;
    BikePart bikePart;

    private void Start()
    {
        nameField = GetComponent<TextMeshPro>();
        DisplayName(false);
    }

    public void DisplayName(bool show)
    {
        Debug.Log(show);
        nameField.enabled = show;
    }
}
