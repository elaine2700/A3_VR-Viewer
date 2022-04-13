using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BikePart : XRBaseInteractable
{
    [SerializeField] string partName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] TextMeshPro nameField;

    ExplodedView explodedView;
    MeshRenderer meshRenderer;
    Views views;

    bool allowHovering = false;

    private void Start()
    {
        
        meshRenderer = GetComponent<MeshRenderer>();
        views = FindObjectOfType<Views>();
        explodedView = FindObjectOfType<ExplodedView>();
        nameField.text = partName;
        nameField.gameObject.SetActive(false);
    }

    public void DisplayInfo()
    {
        if (views.explodedViewActive)
        {
            HighlightPart();
            explodedView.NameField.text = partName;
            explodedView.DescriptionField.text = description;
            ShowName(true);
            explodedView.InfoCanvas.SetActive(true);
            Debug.Log(partName);
            Debug.Log(description);
        }
    }

    public void HideInfo()
    {
        if (views.explodedViewActive)
        {
            UnhighlightPart();
            explodedView.InfoCanvas.SetActive(false);
            ShowName(false);
        }    
    }

    private void HighlightPart()
    {
        meshRenderer.material.color = Color.red;
    }

    private void UnhighlightPart()
    {
        meshRenderer.material.color = Color.white;
    }

    public void ShowName(bool show)
    {
        if (views.explodedViewActive)
        {
            allowHovering = show;
            nameField.gameObject.SetActive(show);
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        if(enabled)
        base.OnHoverExited(args);
    }


}
