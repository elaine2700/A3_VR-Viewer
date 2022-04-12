using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public Transform target;
    private Vector3 initialOffset;
    private Vector3 actualoffset;
    private float xposition;
    private float speed = 2;
    float initialOffsetx;
    private void Start()
    {
        initialOffset = target.position - transform.position;
        Debug.Log(initialOffset);
        actualoffset = initialOffset;
        xposition = transform.localPosition.x;
        initialOffsetx = target.position.x - transform.position.x;
    }

    private void Update()
    {
        target.position = transform.position + actualoffset;
        actualoffset.y = initialOffset.y;
        actualoffset.z = initialOffset.z;

        if (xposition < transform.localPosition.x || xposition > transform.localPosition.x)
        {
            Approach2();
            Debug.Log("I am approaching");
        }


    }

    private void Approach2()
    {
        actualoffset.x = initialOffsetx * xposition/transform.localPosition.x * speed;
    }
}

