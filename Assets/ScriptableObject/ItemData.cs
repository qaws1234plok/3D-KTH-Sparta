using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Consumable, // 섭취 가능 여부 구분
}

public enum ConsumableType // 섭취시 캐싱하는 스텟
{
    Health,
    Stamina,
    SpeedUp
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/New Item", order = 2)]
public class ItemData : ScriptableObject
{
    [Header("아이템 정보")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("섭취 가능")]
    public ItemDataConsumable[] consumables;
}
