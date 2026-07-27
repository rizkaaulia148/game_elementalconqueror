
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [Header ("Attack Parameter")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameter")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    private float cooldowntimer = Mathf.Infinity;
    private healt playerHealth;
    private Animator animator;
    


    private EnemyPatroli enemyPatrol;
    private void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatroli>();
        animator=GetComponent<Animator>();
    
    }
    public void Update()
    {



        cooldowntimer += Time.deltaTime;
        if (PlayerInSight())
        {
          


            if (cooldowntimer >= attackCooldown)
            {
                cooldowntimer = 0;
                animator.SetTrigger("meleeAttack");

                Debug.Log("di attaCK ENNEMY");


            }

        }
        if (enemyPatrol != null) {
            enemyPatrol.enabled = !PlayerInSight();

        }

    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,Vector2.left,0,playerLayer );

        
        //if player still in range damage him
        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<healt>();

        return hit.collider != null;
    }
    private void damagePlayer()
    {

        playerHealth.TakeDamage(damage);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x *  colliderDistance,
         new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}
