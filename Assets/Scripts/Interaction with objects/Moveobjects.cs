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
    private float speed = .01f;
    private float initialOffsetz;
    private float positionz;
    private bool iamapproachingright = false;
    private bool iamapproachingleft = false;


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
        //Subscribe to chanels when pressing inputs from control or when an object is being hovered left or right.
        //When the event happens deoending on what channel they are subscribed, this functions (brown) will be fired.
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
        //This prevents all objects with the same code to activate all at a time by checking the name, if one object is being hovered, you can´t hover another one.
        if (name == this.name && Eventsmanager.canhoverright)
        {
            isHoverright = true;
            //Debug.Log($"isHoverright on {objectref.name} should be true: {isHoverright}");
            initialOffset = transform.position - controllerright.position;
            actualOffset = initialOffset;
            //Gets the initial difference between the control and the hovered object over z axis
            initialOffsetz = transform.position.z - controllerright.position.z;
            positionz = controllerright.position.z;
        }
    }
    public void Getinitialoffsetleft(string name)
    {
        //Same but with Right controller
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
        //I should have used a bool to avoid repetition
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
    //This funstions awares the hole class that trigger right controler is true
    //A sad problem with our move, was that it has to hover specifically the object the user decides, it must be a possible solution for this, but we didn´t have time to solve it.
    private void ApproachRight()
    {
        //A problem with our movement action, is that we have to hover the object everytime we want to move the object so it is not UX friendly
        triggersright = true;
        //If trigger and the object is being hovered and the object is not being scaled, approach the object near me.
        if (isHoverright && !iamscaling)
        {
            //Awares that approaching action is happening
            iamapproachingright = true;
            //Position of the object will be the position of the control + the initial offset
            transform.position = controllerright.position + actualOffset;
            //X & y remain the same
            actualOffset.x = initialOffset.x;
            actualOffset.y = initialOffset.y;
            //We really didn´t see a big difference with z, the objective was to approach the object faster
            if (positionz != controllerright.position.z)
            {
                actualOffset.z = initialOffsetz * positionz / controllerright.position.z * speed * Time.deltaTime;
            }
        }
        else
            iamapproachingright = false;
    }
    private void ApproachLeft()
    {
        //Same as right, but with left
        triggersleft = true;
        if (isHoverleft && !iamscaling)
        {
            iamapproachingleft = true;
            transform.position = controllerLeft.position + actualOffset;
            actualOffset.x = initialOffset.x;
            actualOffset.y = initialOffset.y;

            if (positionz != controllerLeft.localPosition.z)
            {
                actualOffset.z = initialOffsetz * positionz / controllerLeft.localPosition.z * speed * Time.deltaTime;
            }
        }
        else
            iamapproachingleft = false;
    }
    private void Scale()
    {
        if (isHoverright && getinitialscaleonce || isHoverleft && getinitialscaleonce)
        {
            //Gets the initial offset once
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
            //If getinitialscaleonce is false, then the action of scaling is implemented.
            //This function was stolen from Erik´s class.
            float currentDistance = Vector3.Distance(controllerright.position, controllerLeft.position);
            result = currentDistance / initialDistance;
            objectref.transform.localScale = initialScale * result;
        }
        if (!triggersright && !triggersleft)
        {
            //If triiger is not being pressed by both controllers, then it cancels the action of scaling and resets the offset.
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
        //It is basically the same concept with scaling but instead of trigger are both grip buttons pressed and the object will start rotationg.
        if (isHoverright && getinitialrotationonce || isHoverleft && getinitialrotationonce)
        {
            initialrotationofobject = objectref.transform.localRotation.eulerAngles;
            getinitialrotationonce = false;
        }
        if (gripright && gripleft && !getinitialrotationonce)
        {
            iamrotating = true;
            //Gets local roation of target 2 and converts it to euler (Vector3)
            localrotationoffsettarget2 = target2.rotation.eulerAngles;
            //Debug.Log($"local Rotation x axis  of target2 is {localrotationoffsettarget2}");
            //Sets y rotation based on target rotation * 2
            objectref.transform.localRotation = Quaternion.Euler(initialrotationofobject.x, localrotationoffsettarget2.y * 2, initialrotationofobject.z);
            //This is an object that is positioned between both controllers and the rotation depends on the movement of the controls.
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
        //Scale and rotation are always being called
        Scale();
        Rotation();
        Debug.Log($"Object: {objectref} |Hovering left = {isHoverleft} | Hovering right = {isHoverright}");
        //This prevents to activate other objects while one is already hovered.
        if (iamscaling || iamrotating || iamapproachingright || iamapproachingleft)
        {
            Eventsmanager.canhoverleft = false;
            Eventsmanager.canhoverright = false;
        }
    }
}

