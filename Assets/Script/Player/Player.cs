using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public PlayerBuffController buffController;
    public Transform dropPosition;

    public ObjectData objectData;
    public ItemData itemData;

    public Action addItem; 

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        buffController = GetComponent<PlayerBuffController>();
    }
}
