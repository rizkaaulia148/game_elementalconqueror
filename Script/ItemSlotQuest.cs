using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*using static UnityEditor.Progress;*/
using UnityEngine.SceneManagement;


public class ItemSlotQuest : MonoBehaviour
{
    //ITEM DATA
    [Header("ITEM DATA")]
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    //ITEMSLOT

    [Header("ITEM SLOT")]

    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private TMP_Text NamaText;
    [SerializeField] private Image itemImage;

    [SerializeField] private string sceneToLoad;
    public GameObject questionNextLevel;


    private questmanager Questmanager;

    private int numberquestion = 2;

    private bool itemBerkurang;
    private bool itemKosong;
    private InventoryManager invmanager;

    [SerializeField] public door namaPintu;



    /*private List<Item> items = new List<Item>();*/

    private void Start()
    {
        Questmanager = GameObject.Find("Craftingmenu").GetComponent<questmanager>();

        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {

        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        NamaText.text = itemName;
        NamaText.enabled = true;



        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;

        Debug.Log("masuk kesini dia");

    }


    public void OnButtonClick()
    {

        Debug.Log("button sudah di klik");
        if (!string.IsNullOrEmpty(itemName) && quantity > 0 && itemSprite != null)
        {
            Debug.Log("perintah di eksekusi");
            Questmanager.AddItem(itemName, quantity, itemSprite);
            Debug.Log("selesai tambah item");


            if (quantity > 0 && Questmanager.allSlotsMatch)
            {

                // Kurangi jumlah item
                Debug.Log("Quantity berkurang");
                itemBerkurang = true;
                quantity--;
                quantityText.text = quantity.ToString();

                // Tambahkan logika lain yang diperlukan setelah mengurangi item

                if (quantity == 0)
                {
                    // Jika jumlah item menjadi 0, hapus item dari slot 
                    itemKosong = true;
                    ClearItem();

                    print("sudah hilang");
                }

            }
            print("terakhir kesini");
            Debug.Log("sisa berapa slot terakhir " + Questmanager.slotnumber);



            if (Questmanager.allSlotsMatch && Questmanager.slotnumber <= 0)
            {
                if (questionNextLevel.activeSelf)
                {
                    questionNextLevel.SetActive(false);

                    Time.timeScale = 1;

                    Debug.Log("NEXT LEVEL");

                    Questmanager.triggerColider();
                    Debug.Log("Trigger aktif");
                    Debug.Log(namaPintu.namapintu());

                    if (namaPintu.namapintu() == "PintuKematian") ;

                    Debug.Log("Load Ending");
                    LoadScene();

                }

            }
            else if (!Questmanager.allSlotsMatch)
            {
                Debug.Log("Tidak semua Slot cocok. Menonaktifkan GameObject nextLevel.");
            }


        }
        else
        {
            Debug.Log("Tombol tidak dapat diinteraksi. Perintah tidak dieksekusi Dhynanti.");
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }


    private void ClearItem()
    {
        itemName = "";
        quantity = 0;
        itemSprite = null;
        isFull = false;

        NamaText.text = "";
        NamaText.enabled = false;
        quantityText.text = "";
        quantityText.enabled = false;
        itemImage.sprite = null;
    }




}