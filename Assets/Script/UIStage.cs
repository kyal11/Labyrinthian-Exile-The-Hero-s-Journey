using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIStage : MonoBehaviour
{
    [SerializeField] private Canvas WinUI;
    [SerializeField] private Canvas LoseUI;

    // Start is called before the first frame update

    public void Start()
    {
        WinUI.gameObject.SetActive(false);
        LoseUI.gameObject.SetActive(false);
    }
    public void isWon()
    {
        Time.timeScale = 0f;
        WinUI.gameObject.SetActive(true);
    }
    public void isLose()
    {

        Time.timeScale = 0f;
        LoseUI.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        // Mendapatkan indeks scene saat ini
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Memuat ulang scene dengan indeks yang sama
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }

}
