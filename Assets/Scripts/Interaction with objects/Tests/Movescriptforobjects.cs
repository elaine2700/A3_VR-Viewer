using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Movescriptforobjects : MonoBehaviour
{
    public Rigidbody rb;
    public Transform controller;
    private Vector3 initialOffset;
    private Vector3 actualOffset;
    private float cubepositionofz;
    private float speed = .00001f;
    private float initialOffsetz;
    private float positionz;


    public InputDeviceCharacteristics characteristicsright;
    private InputDevice targetdeviceright;

    private bool ishoverRight= true;

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

    public void Getinitialoffset()
    {
        TransformScale.hoverx2++;
        ishoverRight = true;
        initialOffset = transform.position - controller.position;
        actualOffset = initialOffset;
        initialOffsetz = transform.position.z - controller.position.z;
        positionz = controller.localPosition.z;
    }

    public void Update()
    {
        bool triggerButtonaction = false;
        if (targetdeviceright.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonaction) && triggerButtonaction && ishoverRight)
        {
            Debug.Log($"You pressed trigger");

            transform.position = controller.position + actualOffset;
            actualOffset.x = initialOffset.x;
            actualOffset.y = initialOffset.y;

            if (positionz != controller.localPosition.z)
            {
                Approach2();
            }
        }
        Debug.Log($"actualOffset.z: {actualOffset.z}");

    }

    public void Sethoverfalse()
    {
        ishoverRight = false;
    }

    private void Approach2()
    {
        Debug.Log("I am approaching");
        actualOffset.z = initialOffsetz * positionz / controller.localPosition.z * speed * Time.deltaTime;
    }

    //public void Update()
    //{
    //    bool triggerButtonaction = false;
    //    if (targetdevice.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonaction) && triggerButtonaction && ishover)
    //    {
    //        Debug.Log($"You pressed trigger");
    //        transform.position = controller.position + initialOffset;
    //    }
    //}
}
