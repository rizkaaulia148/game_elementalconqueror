using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform shootingPoint;
    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}
