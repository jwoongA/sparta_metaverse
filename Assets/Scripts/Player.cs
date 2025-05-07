using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // �̵� �ӵ� (������/���� �̵��� �� ������ ��)
    [SerializeField] private float movementSpeed = 5f;

    // �Է¹��� �̵� ������ ������ ����
    private Vector2 movementDirection;

    // Rigidbody2D ������Ʈ ĳ��
    private Rigidbody2D _rigidbody;

    // ���� ��ȣ�ۿ� ������ ������Ʈ�� ���� (���� �ȿ� ���� ���� ���� ��)
    private InteractTrigger currentInteract;

    [SerializeField] private GameObject interactPromptUI;
    [SerializeField] private TMPro.TextMeshProUGUI interactPrimptText;

    // ������Ʈ �ʱ�ȭ (������ �� Rigidbody2D ��������)
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // ���� ��� �̵� ó�� (�̵� ���� * �ӵ�, ������ y�� �״�� ����)
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }

    // ���� ���� �ȿ� �ִ� ��ȣ�ۿ� ������Ʈ�� �����ϴ� �޼��� (Ʈ���ſ��� ȣ��)
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

    // �̵� �Է� ó�� (WASD / ����Ű / �е� ��)
    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>().normalized;
    }

    // ��ȣ�ۿ� �Է� ó�� (Input System���� 'F' Ű ���ε�)
    void OnInteract(InputValue inputValue)
    {
        // F Ű�� ���Ȱ�, ��ȣ�ۿ� ������ ������Ʈ�� ���� �ȿ� ���� ���
        if (inputValue.isPressed && currentInteract != null && currentInteract.playerInRange)
        {
            Debug.Log("��ȣ�ۿ� ����");

            switch (currentInteract.minigameType)
            {
                case InteractTrigger.MinigameType.Flap:
                    SceneManager.LoadScene("FlapScene");
                    break;
                case InteractTrigger.MinigameType.Stack:
                    SceneManager.LoadScene("StackScene");
                    break;
                default:
                    Debug.Log("�� ����");
                    break;
            }
        } 
    }
}
