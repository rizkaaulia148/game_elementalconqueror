using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyPatroli : MonoBehaviour
    
{
   

    [Header("Patrol Points")]
    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameter")]
    [SerializeField] public float speed;
    [SerializeField] public float speedChase;

    private Vector3 initscale;
    private bool movingleft;

    [Header("Enemy Idle")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animation")]
    [SerializeField] private Animator animator;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    private float scaleY;
    private float scaleX;
    private float scaleZ;




    private void Awake()
    {
        initscale = enemy.localScale;
        scaleX = enemy.localScale.x;
        scaleY = enemy.localScale.y;
        scaleZ = enemy.localScale.z;
       
    }

    private void OnDisable()
    {
        animator.SetBool("walk", false);
    }


    private void Update()
    {

        if (isChasing)
        {
            if (Vector2.Distance(enemy.position, playerTransform.position) > chaseDistance)
            {
                print("jarak sudah lebih ");
                isChasing = false;
            }
            
            if (enemy.position.x > playerTransform.position.x)
            {
                enemy.localScale = new Vector3(-scaleX, scaleY, scaleZ);
                animator.SetBool("walk", true);
                enemy.position += Vector3.left * speedChase * Time.deltaTime;
            }
            if (enemy .position.x < playerTransform.position.x)
            {
                animator.SetBool("walk", true);
                enemy.localScale = new Vector3(scaleX, scaleY, scaleZ);
                enemy.position += Vector3.right * speedChase * Time.deltaTime;


            }
        }

        else
        {
            if (Vector2.Distance(enemy.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;

            }
            

            if (movingleft)
            {
                if (enemy.position.x >= LeftEdge.position.x)

                    MoveDirection(-1);

                else
                    DirectionChange();
            }
            else
            {
                if (enemy.position.x <= RightEdge.position.x)
                    MoveDirection(1);
                else
                    DirectionChange();
            }
        }
    }



    private void DirectionChange()
    {
        animator.SetBool("walk", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        movingleft = !movingleft;
    }
    private void MoveDirection(int _direction)
    {
        idleTimer = 0;
        animator.SetBool("walk",true);
        
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x) * _direction,
                            initscale.y, initscale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
                            enemy.position.y, enemy.position.z);
    }
}

