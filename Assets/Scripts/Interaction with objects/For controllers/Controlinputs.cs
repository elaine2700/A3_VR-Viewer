using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Controlinputs : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;
    private InputDevice targetdevice;
    private GameObject spawnedhandmodel;


    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetdevice = devices[0];
        }
    }
}
