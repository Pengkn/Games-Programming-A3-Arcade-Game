using UnityEngine;

public class instructions : MonoBehaviour
{
    public GameObject PausePanel;


    // Update is called once per frame
    void Start()
    {

        PausePanel.SetActive(true); //sets instruction panel to visible for a few sections at start of level then deletes
        Destroy(gameObject, 3f);
    }

}
    
