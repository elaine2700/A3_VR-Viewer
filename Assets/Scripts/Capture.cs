using UnityEngine;
using UnityEngine.InputSystem;

public class Capture : MonoBehaviour
{
    [SerializeField] InputActionReference captureInputReference;
    int numCapture;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        captureInputReference.action.started += CaptureScreenShot;
    }

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        numCapture = 1;
    }

    // Capture screenshots with Grip Button.
    void CaptureScreenShot(InputAction.CallbackContext context)
    {
        string nameCapture = $"Capture{numCapture}";
        ScreenCapture.CaptureScreenshot(nameCapture, ScreenCapture.StereoScreenCaptureMode.LeftEye);
        meshRenderer.enabled = true;
        numCapture++;
        Invoke(nameof(HideText), 2f);
    }

    void HideText()
    {
        meshRenderer.enabled = false;
    }
}
