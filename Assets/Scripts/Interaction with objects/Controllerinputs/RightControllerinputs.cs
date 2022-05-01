using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
public class RightControllerinputs : MonoBehaviour
{
    public InputDeviceCharacteristics characteristicsright;
    private InputDevice targetdeviceright;
    

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristicsright, devices);


        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetdeviceright = devices[0];
        }
    }

    void Update()
    {
        bool triggerButtonaction = false;

        if (targetdeviceright.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonaction) && triggerButtonaction)
        {
            Eventsmanager.current.TriggerRightTrue();
        }
        if (!triggerButtonaction)
        {
            Eventsmanager.current.TriggerRightFalse();
        }

        bool gripbButtonaction = false;
        InputFeatureUsage<bool> usage = CommonUsages.gripButton;
        if (targetdeviceright.TryGetFeatureValue(usage, out gripbButtonaction) && gripbButtonaction)
        {
            Eventsmanager.current.GripRightTrue();
        }
        if (!gripbButtonaction)
        {
            Eventsmanager.current.GripRightFalse();
        }
    }

}
