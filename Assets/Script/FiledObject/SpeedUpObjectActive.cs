using UnityEngine;
using UnityEngine.InputSystem.XR;

public class SpeedUpObjectActive : MonoBehaviour, IInteractable, IObjectCheckBool
{
    private PlayerBuffController controller;
    public float chargingTime;
    public bool isCharge;

    public ObjectData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        if (IsSpeedObject())
        {
            controller = CharacterManager.Instance.Player.buffController;
            controller.StartCoroutine(controller.IncreaseSpeedTemporarily(10f, 3f)); // 10초 동안 속도 3배 증가
        }
    }

    public bool IsSpeedObject()
    {
        return data.upSpeedObject;
    }

    public bool IsDashObject()
    {
        return data.dashObject;
    }
}
