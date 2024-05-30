using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObject/new ObjectData", order = 1)]
public class ObjectData : ScriptableObject
{
    [Header("������Ʈ ����")]
    public string displayName;
    public string description;
    public bool upSpeedObject;
    public bool dashObject;
}
