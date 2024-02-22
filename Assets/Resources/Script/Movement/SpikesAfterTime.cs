using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAfterTime : MonoBehaviour
{
    [SerializeField] float countDown;
    List<Direction> dirOfTouch = new List<Direction>();
    [SerializeField] LayerMask obstacleMask;

    // �±� "SpikesAfterTime"�� ���� ������Ʈ�� �浹���� �� ȣ��Ǵ� �޼���
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ���ϰ�, �÷��̾�� �ε����� ���� startCountDown() �޼��带 ȣ���մϴ�.
        if (other.CompareTag("Player") && other.gameObject.CompareTag("SpikesAfterTime"))
        {
            Debug.Log("�÷��̾ SpikesAfterTime �±׸� ���� ��ֹ��� �浹�߽��ϴ�.");
            startCountDown();
        }
    }

    public void startCountDown()
    {
        foreach (Direction dir in dirOfTouch)
        {
            // ������ ���⿡�� "SpikesAfterTime" �±׸� ���� ��ֹ��� Ȯ���ϰ� �ı��մϴ�.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, GetDirectionVector(dir), 0.6f, obstacleMask);
            if (hit && hit.collider.CompareTag("SpikesAfterTime"))
            {
                Debug.Log("SpikesAfterTime �±׸� ���� ��ֹ��� �ı��մϴ�.");
                Destroy(hit.collider.gameObject);
            }
        }
    }


    private Vector2 GetDirectionVector(Direction dir)
    {
        switch (dir)
        {
            case Direction.North:
                return Vector2.up;
            case Direction.South:
                return Vector2.down;
            case Direction.West:
                return Vector2.left;
            case Direction.East:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }
}
