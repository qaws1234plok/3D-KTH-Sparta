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
            stamina.Subtract(10f); // 10��ŭ ���¹̳� ���� (���� �ʿ信 ���� ���� ����)
        }
        else
        {
            Debug.LogError("stamina�� null�Դϴ�.");
        }
    }
    public void TriggerJumpEvent()
    {
        OnJumpEvent += JumpSubtract;
        OnJumpEvent?.Invoke();
        OnJumpEvent -= JumpSubtract;
    }
}
