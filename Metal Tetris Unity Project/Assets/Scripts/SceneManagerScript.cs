using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(int sceneNum)
    {

        if (sceneNum == 0) SceneManager.LoadScene(0); // Menu
        if(sceneNum == 1) SceneManager.LoadScene(1); // Instructions
        if (sceneNum == 2) SceneManager.LoadScene(2); // Play Game
        if (sceneNum == 3) SceneManager.LoadScene(3); // Credits


    }
}
