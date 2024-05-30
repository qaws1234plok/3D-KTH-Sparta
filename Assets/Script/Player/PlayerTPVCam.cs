using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerTPVCam : MonoBehaviour
{
    public GameObject cameraGo;
    public Image crossHair;

    private void Start()
    {
        cameraGo.SetActive(false);
    }


    public void OnCameraViewToggle(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (!cameraGo.activeInHierarchy)
            {
                cameraGo.SetActive(true);
                crossHair.enabled = false;
            }
            else
            {
                cameraGo.SetActive(false);
                crossHair.enabled = true;
            }
        }
    }
}
