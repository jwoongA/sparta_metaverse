using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // ����ٴ� ���
    public Transform target;

    // ������ �ʱ� �Ÿ�
    float offsetX;
    float offsetY;

    void Start()
    {
        // Ÿ���� �������� �ʾ����� �ƹ��͵� ���� ����
        if (target == null)
            return;

        // ī�޶�� ����� �ʱ� x, y �Ÿ� ���� ����
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        // ���� ��ġ�� �������� ���ο� ��ġ ���
        Vector3 pos = transform.position;

        // ����� ��ġ�� �ʱ� �������� ���ؼ� ī�޶� ��ġ ���
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;

        // ī�޶� ��ġ ����
        transform.position = pos;
    }
}
