using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerBuffController : MonoBehaviour
{
    public bool charge = false;
    private Coroutine chargeCo;
    private Coroutine speedCoroutine;

    private PlayerController controller;

    private void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
    }

    public void StartChargeDash()
    {
        charge = true;

        if (chargeCo != null)
        {
            StopCoroutine(chargeCo);
        }

        chargeCo = StartCoroutine(ChargeDash());
    }

    public IEnumerator ChargeDash()
    {
        while (charge)
        {
            Vector3 dashDirection = controller.transform.TransformDirection(new Vector3(controller.curMovementInput.x, 0, controller.curMovementInput.y).normalized);

            if (dashDirection != Vector3.zero)
            {
                controller._rigidbody.AddForce(dashDirection * 1000f, ForceMode.Impulse); // 대쉬 힘 설정
                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (true)
        {
            if (controller.isGrounded())
            {
                charge = false; // 여기서 charge를 false로 설정
                break;
            }
            yield return null;
        }
    }

    public IEnumerator IncreaseSpeedTemporarily(float duration, float multiplier)
    {
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
        }

        speedCoroutine = StartCoroutine(SpeedBoost(duration, multiplier));
        yield return speedCoroutine;
    }

    private IEnumerator SpeedBoost(float duration, float multiplier)
    {
        float originalSpeed = controller.moveSpeed;
        controller.moveSpeed *= multiplier;
        yield return new WaitForSeconds(duration);
        controller.moveSpeed = originalSpeed;
    }
}