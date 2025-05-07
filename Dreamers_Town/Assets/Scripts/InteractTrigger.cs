using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    public enum MinigameType { Flap, Stack }
    public MinigameType minigameType;

    // 플레이어가 이 트리거 범위 안에 들어왔는지 여부
    public bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트의 태그가 "Player"일 경우
        if (other.CompareTag("Player"))
        {
            // 플레이어가 범위 안에 들어왔음을 표시
            playerInRange = true;

            // 플레이어에게 현재 상호작용 가능한 오브젝트(this)를 알려줌
            other.GetComponent<Player>().SetCurrentInteract(this);

            Debug.Log("플레이어가 범위 안에 있음");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 충돌 종료된 오브젝트의 태그가 "Player"일 경우
        if (other.CompareTag("Player"))
        {
            // 플레이어가 범위를 벗어났음을 표시
            playerInRange = false;

            // 플레이어의 currentInteract를 해제해줌
            other.GetComponent<Player>().SetCurrentInteract(null);

            Debug.Log("플레이어가 범위 밖에 있음");
        }
    }

    // 미니게임 타입에 따라 나오는 문자 다르게 만들기
    public string GetInteractionMessage()
    {
        switch (minigameType)
        {
            case MinigameType.Flap:
                return "Press F to play Flap";
            case MinigameType.Stack:
                return "Press F to play Stack";
            default:
                return "Press F to Interact";
        }
    }
}
