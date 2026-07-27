using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Playermovement playerMovement;
    healt Health;

    private void Awake()
    {
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<healt>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Simpan posisi checkpoint
            if (Health != null)
            {
                Health.SetCheckpointPosition(transform.position);
            }
        }
    }
}
