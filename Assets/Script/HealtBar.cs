using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Image fillBar;
    public float healt;
    [SerializeField] public Animator animator;

    public void LoseHealth(int value)
    {
        animator.SetTrigger("Hitplayer");
        // Kurangin Darah
        healt -= value;
        //resfresh UI healt bar
        fillBar.fillAmount = healt / 100;

        if(healt <= 0)
        {
            animator.SetBool("Deathplayer", true);
            FindObjectOfType<UIStage>().isLose();
        }
    }
    public void Healing(int value)
    {
        if(healt < 100)
        {
            // Kurangin Darah
            healt += value;
            //resfresh UI healt bar
            fillBar.fillAmount = healt / 100;
        }
        if(healt > 100)
        {
            healt = 100;
            fillBar.fillAmount = healt / 100;
        }
        
    }  
}
