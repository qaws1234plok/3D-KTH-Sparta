using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class PlatformLauncher : MonoBehaviour, IInteractable, IObjectCheckBool
{
    private PlayerBuffController buffController;
    private PlayerController controller;
    public ObjectData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        if (IsDashObject())
        {
            buffController = CharacterManager.Instance.Player.buffController;
            buffController.StartChargeDash(); // 대쉬 모드 시작
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