using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    // 따라다닐 대상
    public Transform target;

    // 대상과의 초기 거리
    float offsetX;
    float offsetY;

    void Start()
    {
        // 타겟이 설정되지 않았으면 아무것도 하지 않음
        if (target == null)
            return;

        // 카메라와 대상의 초기 x, y 거리 차이 저장
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        // 현재 위치를 기준으로 새로운 위치 계산
        Vector3 pos = transform.position;

        // 대상의 위치에 초기 오프셋을 더해서 카메라 위치 계산
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;

        // 카메라 위치 갱신
        transform.position = pos;
    }
}
