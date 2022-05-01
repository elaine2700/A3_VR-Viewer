using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


public class LeftControllerinputs : MonoBehaviour
{
    public InputDeviceCharacteristics characteristicsleft;
    private InputDevice targetdeviceleft;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristicsleft, devices);
       

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetdeviceleft = devices[0];
        }
    }

    void Update()
    {
        bool triggerButtonaction = false;
        
        if (targetdeviceleft.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonaction) && triggerButtonaction)
        {
            Eventsmanager.current.TriggerLeftTrue();
        }
        if (!triggerButtonaction)
        {
            Eventsmanager.current.TriggerLeftFalse();
        }

        bool gripbButtonaction = false;
        InputFeatureUsage<bool> usage = CommonUsages.gripButton;
        if (targetdeviceleft.TryGetFeatureValue(usage, out gripbButtonaction) && gripbButtonaction)
        {
            Eventsmanager.current.GripLeftTrue();
        }
        if (!gripbButtonaction)
        {
            Eventsmanager.current.GripLeftFalse();
        }
    }

}
