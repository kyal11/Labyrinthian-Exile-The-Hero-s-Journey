using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Image fillBar;
    public float healt;

    public void LoseHealth(int value)
    {
        // Kurangin Darah
        healt -= value;
        //resfresh UI healt bar
        fillBar.fillAmount = healt / 100;

        if(healt <= 0)
        {
            FindObjectOfType<UIStage>().isLose();
        }
    }
  
}
