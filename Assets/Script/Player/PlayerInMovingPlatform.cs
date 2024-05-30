using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMovingPlatform : MonoBehaviour
{
    private MovingPlatform currentPlatform;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
        {
            currentPlatform = collision.collider.GetComponent<MovingPlatform>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("MovingPlatform"))
        {
            currentPlatform = null;
        }
    }

    void Update()
    {
        if (currentPlatform != null)
        {
            transform.position += currentPlatform.deltaPosition;
        }
    }
}
