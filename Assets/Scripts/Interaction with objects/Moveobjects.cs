using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Moveobjects : MonoBehaviour
{
    //Objects to move and reference from controls
    public GameObject objectref;
    string name;
    public Transform controllerLeft;
    public Transform controllerright;

    //Get raycast info from both controllers

    private bool isHoverleft;
    private bool isHoverright;

    //For movement
    private Vector3 initialOffset;
    private Vector3 actualOffset;
    private float cubepositionofz;
    private float speed = .00001f;
    private float initialOffsetz;
    private float positionz;

    //For Scale
    private bool getinitialscaleonce = false;
    private float result;
    private float initialDistance;
    private Vector3 initialScale;
    private bool triggersleft;
    private bool triggersright;
    private bool iamscaling = false;

    //For Rotation
    public Transform target2;
    private Vector3 initialrotationofobject;
    private Vector3 localrotationoffsettarget2;
    private bool getinitialrotationonce;
    private bool gripleft;
    private bool gripright;
    private bool iamrotating = false;


    public void Start()
    {
        name = objectref.name;
        Eventsmanager.current.OnTriggerRightTrue += ApproachRight;
        Eventsmanager.current.OnTriggerRightFalse += Triggerrightfalse;
        Eventsmanager.current.OnGripRightTrue += Griprighttrue;
        Eventsmanager.current.OnGripRightFalse += Griprightfalse;
        Eventsmanager.current.OnHoverright += Getinitialoffsetright;
        Eventsmanager.current.OnHoverexitright += SethoverfalseRight;


        Eventsmanager.current.OnTriggerLeftTrue += ApproachLeft;
        Eventsmanager.current.OnTriggerLeftFalse += Triggerleftfalse;
        Eventsmanager.current.OnScaling += SetScaletrue;
        Eventsmanager.current.OnGripLeftTrue += Griplefttrue;
        Eventsmanager.current.OnGripLeftFalse += Gripleftfalse;
        Eventsmanager.current.OnHoverleft += Getinitialoffsetleft;
        Eventsmanager.current.OnHoverexitleft += SethoverfalseLeft;
    }

    private void Triggerrightfalse()
    {
            triggersright = false;
    }
    private void Triggerleftfalse()
    {
            triggersleft = false;
    }
    private void Griprighttrue()
    {
            gripright = true;
    }
    private void Griplefttrue()
    {
            gripleft = true;
    }
    private void Griprightfalse()
    {
            gripright = false;
    }
    private void Gripleftfalse()
    {
            gripleft = false;
    }
    public void Getinitialoffsetright(string name)
    {
        if (name == this.name && Eventsmanager.canhoverright)
        {
            isHoverright = true;
            //Debug.Log($"isHoverright on {objectref.name} should be true: {isHoverright}");
            initialOffset = transform.position - controllerright.position;
            actualOffset = initialOffset;
            initialOffsetz = transform.position.z - controllerright.position.z;
            positionz = controllerright.localPosition.z;
        }
    }
    public void Getinitialoffsetleft(string name)
    {
        if (name == this.name && Eventsmanager.canhoverleft)
        {
            isHoverleft = true;
            //Debug.Log($"isHoverleft on {objectref.name} should be true: {isHoverleft}");
            initialOffset = transform.position - controllerLeft.position;
            actualOffset = initialOffset;
            initialOffsetz = transform.position.z - controllerLeft.position.z;
            positionz = controllerLeft.localPosition.z;

        }
    }
    public void SethoverfalseLeft(string name)
    {
        if (name == this.name)
        {
            isHoverleft = false;
            //Debug.Log($"isHoverleft on {objectref.name} should be false: {isHoverleft}");
        }
    }
    public void SethoverfalseRight(string name)
    {
        if (name == this.name)
        {
            isHoverright = false;
            //Debug.Log($"isHoverright on {objectref.name} should be false: {isHoverright}");
        }
    }
    private void ApproachRight()
    {
            triggersright = true;
            if (isHoverright && !iamscaling)
            {
                transform.position = controllerright.position + actualOffset;
                actualOffset.x = initialOffset.x;
                actualOffset.y = initialOffset.y;

                if (positionz != controllerright.localPosition.z)
                {
                    actualOffset.z = initialOffsetz * positionz / controllerright.localPosition.z * speed * Time.deltaTime;
                }
            }
    }
    private void ApproachLeft()
    {
            triggersleft = true;
            if (isHoverleft && !iamscaling)
            {
                transform.position = controllerLeft.position + actualOffset;
                actualOffset.x = initialOffset.x;
                actualOffset.y = initialOffset.y;

                if (positionz != controllerLeft.localPosition.z)
                {
                    actualOffset.z = initialOffsetz * positionz / controllerLeft.localPosition.z * speed * Time.deltaTime;
                }
            }
    }
    private void Scale()
    {
            if (isHoverright && getinitialscaleonce || isHoverleft && getinitialscaleonce)
            {
                initialScale = objectref.transform.localScale;
                initialDistance = Vector3.Distance(controllerLeft.position, controllerright.position);
                getinitialscaleonce = false;
            }
            if (isHoverright && isHoverleft && !getinitialscaleonce)
            {
                Eventsmanager.current.Scaling();
            }
            if (triggersright && triggersleft && !getinitialscaleonce)
            {
                float currentDistance = Vector3.Distance(controllerright.position, controllerLeft.position);
                result = currentDistance / initialDistance;
                objectref.transform.localScale = initialScale * result;
            }
            if (!triggersright && !triggersleft)
            {
                getinitialscaleonce = true;
                iamscaling = false;
            }
    }
    public void SetScaletrue()
    {
        iamscaling = true;
    }

    private void Rotation()
    {
        if (isHoverright && getinitialrotationonce || isHoverleft && getinitialrotationonce)
        {
            initialrotationofobject = objectref.transform.localRotation.eulerAngles;
            getinitialrotationonce = false;
        }
        if (gripright && gripleft && !getinitialrotationonce)
        {
            iamrotating = true;
            localrotationoffsettarget2 = target2.rotation.eulerAngles;
            //Debug.Log($"local Rotation x axis  of target2 is {localrotationoffsettarget2}");

            objectref.transform.localRotation = Quaternion.Euler(initialrotationofobject.x, localrotationoffsettarget2.y * 2, initialrotationofobject.z);

            target2.position = (controllerLeft.position + controllerright.position) / 2;
            target2.rotation = Quaternion.LookRotation(controllerLeft.position - controllerright.position, Vector3.up);

            ////https://answers.unity.com/questions/408663/rotate-the-object-based-on-the-two-point.html
        }
        if (!gripright && !gripleft)
        {
            getinitialrotationonce = true;
            iamrotating = false;
        }
    }
    private void Update()
    {
        Scale();
        Rotation();
        Debug.Log($"Object: {objectref} |Hovering left = {isHoverleft} | Hovering right = {isHoverright}");
        if (iamscaling || iamrotating)
        {
            Eventsmanager.canhoverleft = false;
            Eventsmanager.canhoverright = false;
        }
    }
}

