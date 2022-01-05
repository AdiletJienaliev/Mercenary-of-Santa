using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnableSceneLoader : MonoBehaviour
{
    public string sceneName;

    private void OnEnable()
    {
        SceneManager.LoadScene(sceneName);
    }
}
