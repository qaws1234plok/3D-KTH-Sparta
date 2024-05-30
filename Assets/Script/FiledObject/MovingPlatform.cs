using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 startPoint; // ���� ��ġ
    [SerializeField] private Vector3 endPoint; // �� ��ġ
    [SerializeField] private float speed = 2.0f; // �̵� �ӵ�

    private float t = 0.0f; // ���� ��
    private bool movingReturnPoint = true; // ���� ����
    public Vector3 deltaPosition { get; private set; } // �÷����� �̵���
    private Vector3 lastPosition; // ���� �������� �÷��� ��ġ


    void Start()
    {
        transform.position = startPoint;
        lastPosition = transform.position;
    }

    void Update()
    {
        // ���� ���� ������Ʈ
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

        // ��ġ�� �����Ͽ� �̵� (���Ʒ�, �¿� ������ �ʰ�, ���۰� ������ ���̸� �̵�)
        Vector3 newPosition = Vector3.Lerp(startPoint, endPoint, t);
        deltaPosition = newPosition - lastPosition;
        lastPosition = newPosition;
        transform.position = newPosition;
    }
}
