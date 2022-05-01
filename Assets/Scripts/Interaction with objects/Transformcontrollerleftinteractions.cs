using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Transformcontrollerleftinteractions : MonoBehaviour
{
    public Rigidbody rb;
    public Transform controllerLeft;
    private Vector3 initialOffset;
    private Vector3 actualOffset;
    private float cubepositionofz;
    private float speed = .00001f;
    private float initialOffsetz;
    private float positionz;


    public InputDeviceCharacteristics characteristicsright;
    private InputDevice targetdeviceriaght;

    private bool isHoverleft = true;

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
            targetdeviceriaght = devices[0];
        }

    }

    public void Getinitialoffset()
    {
        TransformScale.hoverx2++;
        isHoverleft = true;
        initialOffset = transform.position - controllerLeft.position;
        Debug.Log($"Initial offset is:{initialOffset}");
        actualOffset = initialOffset;
        initialOffsetz = transform.position.z - controllerLeft.position.z;
        positionz = controllerLeft.localPosition.z;
    }

    public void Update()
    {
        bool triggerButtonaction = false;
        if (targetdeviceriaght.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonaction) && triggerButtonaction && isHoverleft)
        {
            Debug.Log($"You pressed trigger");

            transform.position = controllerLeft.position + actualOffset;
            actualOffset.x = initialOffset.x;
            actualOffset.y = initialOffset.y;

            if (positionz != controllerLeft.localPosition.z)
            {
                Approach2();
            }
        }
        Debug.Log($"actualOffset.z: {actualOffset.z}");

    }

    public void Sethoverfalse()
    {
        isHoverleft = false;
    }

    private void Approach2()
    {
        Debug.Log("I am approaching");
        actualOffset.z = initialOffsetz * positionz / controllerLeft.localPosition.z * speed * Time.deltaTime;
    }
}
