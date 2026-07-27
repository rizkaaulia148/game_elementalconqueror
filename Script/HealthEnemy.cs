using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int startingHealt;
    [SerializeField] public int curentHealt { get; private set; }
    private Animator animator;
    public HealtBar healtBar;
    public GameObject healtBars;
    private bool dead;
    public List<GameObject> itemPreFabs = new List<GameObject>();
    private bool IsPlayerSeeingEnemy ;
    public Transform playerTransform;
    [SerializeField]private float sightRange;

    // Start is called before the first frame update
    private void Awake()
    {
        curentHealt = startingHealt;
        healtBar.SetMaxHealt(curentHealt);
        animator = GetComponent<Animator>();

    }

    private void Update()

    {
        if (IsPlayerSeeingEnemy)
        {
            if (Vector2.Distance(transform.position, playerTransform.position) > sightRange)
            {
                print("jarak masih jauh ");
                IsPlayerSeeingEnemy = false;
                healtBars.SetActive(false);
            }
           
            
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < sightRange)
            {
                print("jarak sudah dekat ");
                IsPlayerSeeingEnemy = true;
                healtBars.SetActive(true);

            }
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
                
                animator.SetTrigger("die");
                DisableObject();
                die();
                healtBars.SetActive(false);


            }

        }

    }

    public void die()
    {
        ActivateItemPreFabs();
            dead = true;
        healtBars.SetActive(false);
    }

    void ActivateItemPreFabs()
    {
        foreach (GameObject prefab in itemPreFabs) {
        if(prefab != null)
            {

                Vector3 randomOffset = new Vector3(Random.Range(-3f, 10f), 0, Random.Range(-4f, 4f));
                GameObject newItem = Instantiate (prefab,transform.position + randomOffset , Quaternion.identity);
                newItem.SetActive(true);
                Debug.Log("Prefab item telah diaktifkan oleh musuh");
            }
        }
    }


    public void DisableObject()
    {

        // enemy health
        if (GetComponentInParent<EnemyPatroli>() != null)
            GetComponentInParent<EnemyPatroli>().enabled = false;

        if (GetComponentInParent<EnemyPatroli>() != null)
            GetComponentInParent<EnemyPatroli>().enabled = false;

        if (GetComponent<Enemy>() != null)
            GetComponent<Enemy>().enabled = false;
    }
}
