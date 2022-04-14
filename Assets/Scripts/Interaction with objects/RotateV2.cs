using UnityEngine;


public class RotateV2 : MonoBehaviour
{
    public Transform target, target2, target3;

    public Transform left, right;

    //public float result;

    private float initialDistance;
    private float speed = 50;
    private Vector3 initialRotation;
    private Vector3 initialRotation2;
    private Vector3 rotation;

    private Vector3 xoffatehr;

    private void Start()
    {
        initialRotation = target.rotation.ToEulerAngles();
        initialRotation2 = target2.rotation.ToEulerAngles();
        //initialDistance = Vector3.Distance(left.position, right.position);
        Debug.Log(initialRotation.y);
    }

    private void Update()
    {

        xoffatehr = target2.localRotation.ToEulerAngles();
        Vector3 xoftarget3 = target3.localRotation.ToEulerAngles();
        //Debug.Log($"local Rotation in x of parent is {xoffatehr}");

        //rotates with object as mirror
        //target.rotation = Quaternion.Euler(initialRotation.x, xoftarget3.y * 90, initialRotation.z);

        //3rd try
        //var rotation = Quaternion.LookRotation(target2.position);
        //target.rotation = Quaternion.Slerp(target.rotation, rotation, Time.deltaTime * 1000);

        //4th try, with one hand works
        //Vector3 targetPosition = new Vector3(0, target2.position.x * 90, 0);
        //target.rotation = Quaternion.Euler(targetPosition*-1);

        //5tth try,  works but flips when points of origin are equal
        //target.rotation = Quaternion.Euler(initialRotation.x, xoffatehr.y* 90, initialRotation.z);




        //float currentDistance = Vector3.Distance(left.position, right.position);
        //float result = currentDistance / initialDistance;
        //float movex = result * speed;
        //target.Rotate(Vector3.down, movex);
        //target.Rotate(0,(initialRotation.y) * movex,0, Space.Self);
        //target.RotateAround(target.localPosition, target.localPosition, result);
        //= initialRotation.ToEulerAngles * (Vector3.forward * result);

        target2.position = (left.position + right.position) / 2;
        target2.rotation = Quaternion.LookRotation(left.position - right.position, Vector3.up);

        //https://answers.unity.com/questions/408663/rotate-the-object-based-on-the-two-point.html
        //float differenceposition = Vector3.AngleBetween(right.position, left.position);
        //target2.rotation = Quaternion.Euler(0, differenceposition * 30 * 30, 0);
    }
}
