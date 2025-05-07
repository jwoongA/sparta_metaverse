using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // 이동 속도 (오른쪽/왼쪽 이동할 때 곱해질 값)
    [SerializeField] private float movementSpeed = 5f;

    // 입력받은 이동 방향을 저장할 벡터
    private Vector2 movementDirection;

    // Rigidbody2D 컴포넌트 캐싱
    private Rigidbody2D _rigidbody;

    // 현재 상호작용 가능한 오브젝트를 저장 (범위 안에 있을 때만 값이 들어감)
    private InteractTrigger currentInteract;

    [SerializeField] private GameObject interactPromptUI;
    [SerializeField] private TMPro.TextMeshProUGUI interactPrimptText;

    // 컴포넌트 초기화 (시작할 때 Rigidbody2D 가져오기)
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // 물리 기반 이동 처리 (이동 방향 * 속도, 점프는 y축 그대로 유지)
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }

    // 현재 범위 안에 있는 상호작용 오브젝트를 저장하는 메서드 (트리거에서 호출)
    public void SetCurrentInteract(InteractTrigger interactable)
    {
        currentInteract = interactable;

        if (currentInteract != null && currentInteract.playerInRange)
        {
            interactPromptUI.SetActive(true);
            interactPrimptText.text = currentInteract.GetInteractionMessage();
        }
        else
        {
            interactPromptUI.SetActive(false);
        }
    }

    // 이동 입력 처리 (WASD / 방향키 / 패드 등)
    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>().normalized;
    }

    // 상호작용 입력 처리 (Input System에서 'F' 키 바인딩)
    void OnInteract(InputValue inputValue)
    {
        // F 키가 눌렸고, 상호작용 가능한 오브젝트가 범위 안에 있을 경우
        if (inputValue.isPressed && currentInteract != null && currentInteract.playerInRange)
        {
            Debug.Log("상호작용 실행");

            switch (currentInteract.minigameType)
            {
                case InteractTrigger.MinigameType.Flap:
                    SceneManager.LoadScene("FlapScene");
                    break;
                case InteractTrigger.MinigameType.Stack:
                    SceneManager.LoadScene("StackScene");
                    break;
                default:
                    Debug.Log("씬 없음");
                    break;
            }
        } 
    }
}
