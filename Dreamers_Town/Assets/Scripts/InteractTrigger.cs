using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    public enum MinigameType { Flap, Stack }
    public MinigameType minigameType;

    // �÷��̾ �� Ʈ���� ���� �ȿ� ���Դ��� ����
    public bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ������Ʈ�� �±װ� "Player"�� ���
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ���� �ȿ� �������� ǥ��
            playerInRange = true;

            // �÷��̾�� ���� ��ȣ�ۿ� ������ ������Ʈ(this)�� �˷���
            other.GetComponent<Player>().SetCurrentInteract(this);

            Debug.Log("�÷��̾ ���� �ȿ� ����");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // �浹 ����� ������Ʈ�� �±װ� "Player"�� ���
        if (other.CompareTag("Player"))
        {
            // �÷��̾ ������ ������� ǥ��
            playerInRange = false;

            // �÷��̾��� currentInteract�� ��������
            other.GetComponent<Player>().SetCurrentInteract(null);

            Debug.Log("�÷��̾ ���� �ۿ� ����");
        }
    }

    // �̴ϰ��� Ÿ�Կ� ���� ������ ���� �ٸ��� �����
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
