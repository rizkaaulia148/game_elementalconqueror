using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 startPosition; // Posisi awal pemain

    [SerializeField] public float fallBoundary; // Batas jatuh ke jurang

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Deteksi jatuh ke jurang
        if (transform.position.y < fallBoundary)
        {
            Die();
        }
    }

    private void Die()
    {
        // Logika mati, misalnya:
        // Mengatur ulang posisi pemain ke posisi awal
        transform.position = startPosition;
    }
}