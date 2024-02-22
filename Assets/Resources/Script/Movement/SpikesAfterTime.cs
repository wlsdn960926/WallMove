using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesAfterTime : MonoBehaviour
{
    [SerializeField] float countDown;
    List<Direction> dirOfTouch = new List<Direction>();
    [SerializeField] LayerMask obstacleMask;

    // 태그 "SpikesAfterTime"을 가진 오브젝트에 충돌했을 때 호출되는 메서드
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트가 플레이어인지 확인하고, 플레이어와 부딪쳤을 때만 startCountDown() 메서드를 호출합니다.
        if (other.CompareTag("Player") && other.gameObject.CompareTag("SpikesAfterTime"))
        {
            Debug.Log("플레이어가 SpikesAfterTime 태그를 가진 장애물과 충돌했습니다.");
            startCountDown();
        }
    }

    public void startCountDown()
    {
        foreach (Direction dir in dirOfTouch)
        {
            // 지정된 방향에서 "SpikesAfterTime" 태그를 가진 장애물을 확인하고 파괴합니다.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, GetDirectionVector(dir), 0.6f, obstacleMask);
            if (hit && hit.collider.CompareTag("SpikesAfterTime"))
            {
                Debug.Log("SpikesAfterTime 태그를 가진 장애물을 파괴합니다.");
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
