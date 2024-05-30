using UnityEngine;

public class MouseInteraction : MonoBehaviour, IInteractable
{
    public GameObject interactionUI; // 상호작용 UI
    public ObjectData data; // 오브젝트 데이터
    public TMPro.TextMeshProUGUI interactionUIText; // 상호작용 UI의 텍스트 컴포넌트

    private void Start()
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(false); 
        }
    }

    public void OnMouseEnter()
    {
        if (interactionUI != null && interactionUIText != null)
        {
            interactionUI.SetActive(true); // 마우스가 오브젝트 위에 있을 때 UI를 표시
            interactionUIText.text = GetInteractPrompt();
        }
    }

    public void OnMouseExit()
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
    }

    public string GetInteractPrompt()
    {
        Debug.Log($"Displaying");
        string str = $"{data.displayName}\n {data.description}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.objectData = data;
    }
}
