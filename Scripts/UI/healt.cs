using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healt : MonoBehaviour

{

    [SerializeField] private int startingHealt;
    [SerializeField]public int curentHealt { get; private set; }
    private Animator animator;
    public HealtBar healtBar;
    private bool dead;
    [SerializeField] private float fallBoundary;
    public static Vector2 lastCheckPoint;



    // Start is called before the first frame update
    private void Awake()
    {
        curentHealt = startingHealt; 
        healtBar.SetMaxHealt(curentHealt);
        animator = GetComponent<Animator>();
        lastCheckPoint = transform.position;

    }
    private void Update()
    {
        if (transform.position.y < fallBoundary)
        {
            Respawn();
        }
    }

    public void TakeDamage(int _damage)
    {
        curentHealt = Mathf.Clamp(curentHealt - _damage, 0, startingHealt);
        healtBar.SetHealt(curentHealt);
        if (curentHealt > 0)
        {
            animator.SetTrigger("hurt");

        }
        else
        {
            if (!dead)
            {
                Die();
                animator.SetTrigger("die");
                DisableObject();
                Respawn();
            }

        }

    }

    private void Die()
    {
        dead = true;
        Respawn();
    }
  

    private void Respawn()
    {
        transform.position = lastCheckPoint;
        curentHealt = startingHealt;
        healtBar.SetMaxHealt(curentHealt);
        dead = false;


        GetComponent<Playermovement>().enabled = true;
        /*StartCoroutine(ReturnToIdle());*/
    }
    public void SetCheckpointPosition(Vector2 position)
    {
        lastCheckPoint = position;
    }
    /*private IEnumerator ReturnToIdle()
    {
        // Tunggu hingga animasi kematian selesai diputar
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Set animator ke animasi idle setelah animasi kematian selesai
      

        // Reset status kematian
      
    }*/

    public void DisableObject()
    {
        if (GetComponent<Playermovement>() != null)
            GetComponent<Playermovement>().enabled = false;
        // enemy health
        if (GetComponentInParent<EnemyPatroli>() != null)
            GetComponentInParent<EnemyPatroli>().enabled = false;

        if (GetComponent<Enemy>() != null)
            GetComponent<Enemy>().enabled = false;
    }
}


