using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Button start,quit;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(startgame);
        quit.onClick.AddListener(quitgame);
        
    }

    void startgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void quitgame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
