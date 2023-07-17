using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int startGameScene;

    public void StartScene()
    {
        SceneManager.LoadScene(startGameScene);
    }
}
