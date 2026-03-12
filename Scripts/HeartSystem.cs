using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int lives = 3;

    void Start()
    {
        UpdateHearts();
    }

    public void LoseLife(int amount = 1)
    {

        lives -= amount;
        if (lives < 0) lives = 0;

        UpdateHearts();

        if (lives == 0)
        {
            //when the player has no hearts left trigger gameover
            SceneManager.LoadScene("GameOver");
        }
    }

    public void GainLife(int amount = 1)
    {
        
        if (lives < 3)
        {
            lives += amount;

            if (lives > 3)
            {
                lives = 3;
            }
            UpdateHearts();
        }


       
    }
    void UpdateHearts()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < lives);
        }
    }
}