using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

    }

}
