using UnityEngine;

public class RespawnBox : MonoBehaviour
{
    private Vector3 startPositionBox; // Posisi awal pemain

    [SerializeField] public float fallBoundaryBox; // Batas jatuh ke jurang

    private void Start()
    {
        startPositionBox = transform.position;
    }

    private void Update()
    {
        // Deteksi jatuh ke jurang
        if (transform.position.y < fallBoundaryBox)
        {
            fallDie();
        }
    }

    private void fallDie()
    {
        // Logika mati, misalnya:
        // Mengatur ulang posisi pemain ke posisi awal
        transform.position = startPositionBox;
    }
}