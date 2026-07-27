using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject questionCanvas;
    public SpriteRenderer chestSpriteRenderer;
    public Sprite openSprite;
    private bool isOpen = false;
    public List<GameObject> itemPreFabs = new List<GameObject>();


    private bool isPlayerNearby = false;
    public Jawaban jawab;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            Time.timeScale = 0;
            questionCanvas.SetActive(true);
        }

        if(jawab.answer == true && !isOpen)
        {
            print("chest bisa dibuka");
            chestSpriteRenderer.sprite = openSprite;
            isOpen = true;
            ActivateItemPreFabs();
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 1;
            isPlayerNearby = false;
            
        }
    }
    void ActivateItemPreFabs()
    {
        foreach (GameObject prefab in itemPreFabs)
        {
            if (prefab != null)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-3f, 5f), 0, Random.Range(-4f, 4f));
                GameObject newItem = Instantiate(prefab, transform.position + randomOffset, Quaternion.identity);
                newItem.SetActive(true);
                Debug.Log("Prefab item telah diaktifkan oleh Chest");
            }
        }
    }

}





/*private bool menuActivated = false;
    private bool canOpen = false;

    public SpriteRenderer chestSpriteRenderer;
    public Sprite openSprite;
    public List<GameObject> itemPreFabs = new List<GameObject>();
    [SerializeField] private GameObject question;
 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Chest dapat dibuka");
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("Chest tidak dapat dibuka");
            canOpen = false;
        }
    }

    private void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            
            question.SetActive(true);
        }
        else
        {
       
            question.SetActive(false);
        }


            
            *//*print("Chest telah dibuka");
           
            isOpen = true;
            ActivateItemPreFabs();
            Destroy(gameObject);*//* // Menghancurkan chest setelah dibuka   
    }
*//*
    void ActivateItemPreFabs()
    {
        foreach (GameObject prefab in itemPreFabs)
        {
            if (prefab != null)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-3f, 5f), 0, Random.Range(-4f, 4f));
                GameObject newItem = Instantiate(prefab, transform.position + randomOffset, Quaternion.identity);
                newItem.SetActive(true);
                Debug.Log("Prefab item telah diaktifkan oleh Chest");
            }
        }
    }*/