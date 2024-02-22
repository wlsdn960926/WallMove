using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    PlayerMovement player;
    RaycastHit2D hit;
    [SerializeField] LayerMask obstacleMask;
    [SerializeField] float timeAfterSpikesKill;
    public GameObject clearPanel;

    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.collider.tag == "Spikes")
        {
            switch(player.movingDir)
            {
                case Direction.North:
                    hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1, obstacleMask);
                    break;
                case Direction.South:
                    hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1, obstacleMask);
                    break;
                case Direction.East:
                    hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1, obstacleMask);
                    break;
                case Direction.West:
                    hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1, obstacleMask);
                    break;
            }
            if(hit != null)
            {
                clearPanel.SetActive(true);
            }
        }

        if(info.collider.tag == "HintTile")
        {
            Destroy(info.collider.gameObject);
        }

    }
}
