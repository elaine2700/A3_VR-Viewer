using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class TransformScale : MonoBehaviour
{
    public Transform target;
    public Transform left, right;
    public float result;
    private float initialDistance;
    private Vector3 initialScale;
    public static float hoverx2 = 0;



    public InputDeviceCharacteristics characteristicsright, characteristicsleft;
    private InputDevice targetdeviceright, targetdeviceleft;




    public void GetinitialScale()
    {
        hoverx2++;
        if (hoverx2 > 1)
        {
            initialScale = target.localScale;
            initialDistance = Vector3.Distance(left.position, right.position);
        }

    }

    private void Update()
    {
        bool triggerButtonactionleft = false;
        bool triggerButtonactionright = false;
        if (targetdeviceright.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonactionright) && targetdeviceleft.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonactionleft) && triggerButtonactionright && triggerButtonactionleft)
        {
            Debug.Log("I have entered");
            float currentDistance = Vector3.Distance(left.position, right.position);
            result = currentDistance / initialDistance;
            target.localScale = initialScale * result;
        }
    }

}





