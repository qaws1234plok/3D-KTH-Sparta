using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 startPoint; // 시작 위치
    [SerializeField] private Vector3 endPoint; // 끝 위치
    [SerializeField] private float speed = 2.0f; // 이동 속도

    private float t = 0.0f; // 보간 값
    private bool movingReturnPoint = true; // 도달 여부
    public Vector3 deltaPosition { get; private set; } // 플랫폼의 이동량
    private Vector3 lastPosition; // 이전 프레임의 플랫폼 위치


    void Start()
    {
        transform.position = startPoint;
        lastPosition = transform.position;
    }

    void Update()
    {
        // 보간 값을 업데이트
        if (movingReturnPoint)
        {
            t += Time.deltaTime * speed / Vector3.Distance(startPoint, endPoint);
            if (t >= 1.0f)
            {
                t = 1.0f;
                movingReturnPoint = false;
            }
        }
        else
        {
            t -= Time.deltaTime * speed / Vector3.Distance(startPoint, endPoint);
            if (t <= 0.0f)
            {
                t = 0.0f;
                movingReturnPoint = true;
            }
        }

        // 위치를 보간하여 이동 (위아래, 좌우 가리지 않고, 시작과 끝값의 사이를 이동)
        Vector3 newPosition = Vector3.Lerp(startPoint, endPoint, t);
        deltaPosition = newPosition - lastPosition;
        lastPosition = newPosition;
        transform.position = newPosition;
    }
}
