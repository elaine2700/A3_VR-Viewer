using UnityEngine;

public class Scale : MonoBehaviour
{
    public Transform target;

    public Transform left, right;

    public float result;

    private float initialDistance;
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = target.localScale;

        initialDistance = Vector3.Distance(left.position, right.position);
    }

    private void Update()
    {
        float currentDistance = Vector3.Distance(left.position, right.position);

        result = currentDistance / initialDistance;

        target.localScale = initialScale * result;
    }
}
