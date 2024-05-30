using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObject/new ObjectData", order = 1)]
public class ObjectData : ScriptableObject
{
    [Header("오브젝트 정보")]
    public string displayName;
    public string description;
    public bool upSpeedObject;
    public bool dashObject;
}
