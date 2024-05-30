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
        stamina.Add(stamina.paasiveValue * Time.deltaTime);
    }

    public void JumpSubtract()
    {
        if (stamina != null)
        {
            stamina.Subtract(10f); // 10만큼 스태미나 감소 (값은 필요에 따라 조정 가능)
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
