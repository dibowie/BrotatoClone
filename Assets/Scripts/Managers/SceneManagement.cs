using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : Singleton<SceneManagement>
{
    public void SceneRestart()
    {
        SceneManager.LoadScene(0);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }
}
