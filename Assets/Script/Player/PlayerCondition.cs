using UnityEngine;
using System;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uICondition;

    Condition health { get { return uICondition.health; } }
    Condition stamina { get { return uICondition.stamina; } }

    public event Action OnJumpEvent;

    // Update is called once per frame
    void Update()
    {
        health.Add(health.paasiveValue * Time.deltaTime);
        stamina.Add(stamina.paasiveValue * Time.deltaTime);
    }

    public void JumpSubtract()
    {
        if (stamina != null)
        {
            health.Subtract(10);
            stamina.Subtract(10f); 
        }
        else
        {
            Debug.LogError("stamina가 null입니다.");
        }
    }
    public void TriggerJumpEvent()
    {
        OnJumpEvent += JumpSubtract;
        OnJumpEvent?.Invoke();
        OnJumpEvent -= JumpSubtract;
    }
}
