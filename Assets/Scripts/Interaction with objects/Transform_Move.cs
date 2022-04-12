using UnityEngine;
using System.Collections.Generic;


public class Transform_Move : MonoBehaviour
{
    public Transform target;
    private Vector3 initialOffset;
    private Vector3 actualoffset;
    private float xposition;
    float timer = 0;
    float waitTime = 5;
    float speed = 5000f;
    float step;
    private void Start()
    {
        initialOffset = target.position - transform.position;
        Debug.Log(initialOffset);
        actualoffset = initialOffset;
        xposition = transform.position.x;
    }

    private void Update()
    {
        
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            Debug.Log("5 Seconds passed");
            Motionapproach();

        }
        else
        {
            Debug.Log("I am movingacording with my friend");
            target.position = transform.position + actualoffset;
        }
    }

    private void Motionapproach()
    {
        step = speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) > 5f)
        {
            if (xposition < transform.position.x)
            {
                Approach();
                Debug.Log("I am approaching");
            }

            else if (xposition > transform.position.x)
            {
                MOveaway();
                Debug.Log("I am moving away");
            }
        }
    }

    private void Approach()
    {
        target.position = Vector3.MoveTowards(target.position, transform.position, step * Time.deltaTime);

    }
    private void MOveaway()
    {
        target.position = Vector3.MoveTowards(target.position, (new Vector3(-600, transform.position.y, transform.position.z)), step * Time.deltaTime);

    }

}