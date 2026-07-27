using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jawaban : MonoBehaviour
{
    [SerializeField] private GameObject question;
    
    public List<GameObject> itemPreFabs = new List<GameObject>();
    public bool answer;

    // Start is called before the first frame update
    public void jawaban(bool jawab)
    {
        if (jawab)
        {
            Time.timeScale = 1;
            question.SetActive(false);
           
            answer = true;
            print("jawaban benar" + answer);
        }
        else
        {
            
            Time.timeScale = 0;
            question.SetActive(true);
            answer = false;
            // Mengubah warna tombol menjadi merah
        }
    }

   /* public void ActiveItemPrefab()
    {
        foreach (GameObject prefab in itemPreFabs)
        {
            if (prefab != null)
            {

                Vector3 randomOffset = new Vector3(Random.Range(-3f, 10f), 0, Random.Range(-4f, 4f));
                GameObject newItem = Instantiate(prefab, transform.position + randomOffset, Quaternion.identity);
                newItem.SetActive(true);
                Debug.Log("Prefab item telah diaktifkan oleh musuh");
            }
        }
    }*/


}
