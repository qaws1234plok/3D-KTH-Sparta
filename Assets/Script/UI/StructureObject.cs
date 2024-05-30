using UnityEngine;

public interface IInteractable // 설명부분
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public interface IObjectCheckBool // Bool반환 부분
{
    public bool IsSpeedObject();
    public bool IsDashObject();
}


public class StructureObject : MonoBehaviour, IInteractable
{
    public ObjectData data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n {data.description}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.objectData = data;
    }
}