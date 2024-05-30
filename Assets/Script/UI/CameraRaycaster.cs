using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            MouseInteraction interactionObject = hit.collider.GetComponent<MouseInteraction>();
            if (interactionObject != null)
            {
                interactionObject.OnMouseEnter();
            }
        }
        else
        {
            // 모든 InteractionObject에 OnMouseExit을 호출
            MouseInteraction[] interactionObjects = FindObjectsOfType<MouseInteraction>();
            foreach (var obj in interactionObjects)
            {
                obj.OnMouseExit();
            }
        }
    }
}
