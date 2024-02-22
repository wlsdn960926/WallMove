using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAfterTime : MonoBehaviour
{
    [SerializeField] float countDown;
    List<Direction> dirOfTouch = new List<Direction>();
    [SerializeField] LayerMask obstacleMask;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾ SpikesAfterTime�� �浹.");
            startCountDown();
        }
    }

    public void startCountDown()
    {
        foreach (Direction dir in dirOfTouch)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, GetDirectionVector(dir), 0.6f, obstacleMask);
            if (hit && hit.collider.CompareTag("SpikesAfterTime"))
            {
                Debug.Log("SpikesAfterTime�� �ı�.");
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
