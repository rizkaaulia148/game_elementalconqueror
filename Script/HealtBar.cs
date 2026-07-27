using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
   /* [SerializeField] private healt playerHealt;
    [SerializeField] private Image totalhealtBar;
    [SerializeField] private Image CurrenHealtBar;
    // Start is called before the first frame update
   */
    public Slider slider;

    public void SetHealt(int health)
    {
        slider.value = health;
    }
    public void SetMaxHealt(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
   
}
