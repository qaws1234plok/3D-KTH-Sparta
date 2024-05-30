using UnityEngine;

public class MouseInteraction : MonoBehaviour, IInteractable
{
    public GameObject interactionUI; // ��ȣ�ۿ� UI
    public ObjectData data; // ������Ʈ ������
    public TMPro.TextMeshProUGUI interactionUIText; // ��ȣ�ۿ� UI�� �ؽ�Ʈ ������Ʈ

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
            interactionUI.SetActive(true); // ���콺�� ������Ʈ ���� ���� �� UI�� ǥ��
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
