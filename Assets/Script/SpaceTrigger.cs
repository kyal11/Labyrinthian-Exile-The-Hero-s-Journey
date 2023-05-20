using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceTrigger : MonoBehaviour
{
    public DialogController dialogController;

    public Sprite[] backgrounds;
    private int currentBackgroundIndex = 0;

    public string[] dialogues;
    private int currentDialogIndex = 0;

    private void Start()
    {
        dialogController.ChangeBackground(currentBackgroundIndex);
        dialogController.ChangeDialog(dialogues[currentDialogIndex]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentBackgroundIndex++;
            if (currentBackgroundIndex >= backgrounds.Length)
            {
                currentBackgroundIndex = backgrounds.Length - 1;
            }
            dialogController.ChangeBackground(currentBackgroundIndex);

            currentDialogIndex++;
            if (currentDialogIndex >= dialogues.Length)
            {
                currentDialogIndex = dialogues.Length - 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            dialogController.ChangeDialog(dialogues[currentDialogIndex]);
        }
    }
    public int maxDialogue()
    {
        return dialogues.Length - 1;
    }
}
