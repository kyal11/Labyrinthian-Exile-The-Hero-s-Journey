using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public Sprite[] backgrounds;
    public TextMeshProUGUI dialogText;
    public Image backgroundImage;

    private int currentBackgroundIndex = 0;
    private int currentDialogIndex = 0;
    // Method untuk mengubah background
    public void ChangeBackground(int backgroundIndex)
    {
        if (backgroundIndex >= 0 && backgroundIndex < backgrounds.Length)
        {
            backgroundImage.sprite = backgrounds[backgroundIndex];
            currentBackgroundIndex = backgroundIndex;
        }
        else
        {
            Debug.LogError("Invalid background index!");
        }
    }

    // Method untuk mengubah dialog
    public void ChangeDialog(string newDialog)
    {
 
        dialogText.text = newDialog;
        currentDialogIndex++;
    }

    // Method untuk berpindah ke scene berikutnya
   
}
