using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseS()
    {
        //when player presses pause button make pause screen visable and pause game
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        //when player presses continue button make pause screen invisable and unpause game

        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
