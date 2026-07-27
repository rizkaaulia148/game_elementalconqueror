using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GrabBox : MonoBehaviour
{

    [SerializeField] public Transform grabPoint;
    [SerializeField] public Transform rayPoint;
    [SerializeField] public float rayDistance;

    private GameObject grabbedObject;

    private bool isHoldingBox;

    private Playermovement playerMovement;


    private void Start()
    {
        playerMovement =  GetComponent<Playermovement>();
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.CompareTag("Box"))
        {
            if(Input.GetKeyDown(KeyCode.E) && grabbedObject == null) 
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
                isHoldingBox = true;
                playerMovement.DisableJump();
                Debug.Log("sedang pegang box");
            }
            else if (Input.GetKeyDown(KeyCode.E) && grabbedObject != null)
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                isHoldingBox = false;
                playerMovement.EnableJump();
                Debug.Log("melepas box");
            }
        }
        if (!isHoldingBox)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (playerMovement.gron && !playerMovement.isJumpDisabled)
                {
                    playerMovement.Jump();
                }
                else if (playerMovement.jumpCounter < playerMovement.maxJump && !playerMovement.isJumpDisabled)
                {
                    playerMovement.Jump();
                    playerMovement.jumpCounter++;
                }
            }
        }
        else
        {
            playerMovement.DisableJump();
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
        
    }

}
