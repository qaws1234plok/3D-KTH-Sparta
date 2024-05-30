using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Consumable, // ���� ���� ���� ����
}

public enum ConsumableType // ����� ĳ���ϴ� ����
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
    [Header("������ ����")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("���� ����")]
    public ItemDataConsumable[] consumables;
}
