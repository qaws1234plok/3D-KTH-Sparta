using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStair : MonoBehaviour
{
    public PlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out controller))
        {
            controller.GetComponent<Rigidbody>().AddForce(Vector3.up * 700, ForceMode.Impulse);
        }
    }
}
