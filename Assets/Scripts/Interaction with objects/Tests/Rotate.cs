using UnityEngine;


public class Rotate : MonoBehaviour
{
    public Transform target2;
    public Transform target;

    public Transform left, right;

    public float result;

    private float initialDistance;
    private float speed = 5000;
    private Vector3 initialRotation;
    private Vector3 rotation;

    private Vector3 xoffatehr;
    private Quaternion m_MyQuaternion;

    private void Start()
    {
        m_MyQuaternion = new Quaternion();
        //initialRotation = target.rotation.ToEulerAngles();
        //initialRotation2 = target2.rotation.ToEulerAngles();
        //initialDistance = Vector3.Distance(left.position, right.position);
        //Debug.Log(initialRotation.y);
    }

    private void Update()
    {
        m_MyQuaternion.SetFromToRotation(target.position, target2.position);
        //target.position = Vector3.Lerp(target.position, target2.position, 1000 * Time.deltaTime);
        target.rotation = m_MyQuaternion * target.rotation;

        //xoffatehr = target2.localRotation.ToEulerAngles();
        //Debug.Log($"local Rotation in x of parent is {xoffatehr}");
        //float difference = initial target.position.y
        //target.RotateAroundLocal(target.position, target.position.y xoffatehr.y);

        //target.rotation = Quaternion.Euler(initialRotation.x, xoffatehr, initialRotation.y);

        //float currentDistance = Vector3.Distance(left.position, right.position);
        //result = currentDistance / initialDistance;

        //float movex = result * speed;
        //target.Rotate(Vector3.down, movex);

        //target.Rotate(0,(initialRotation.y) * result*50,0, Space.Self);


        //target.RotateAround(target.localPosition, target.localPosition, result);


        //= initialRotation.ToEulerAngles * (Vector3.forward * result);
    }
}
