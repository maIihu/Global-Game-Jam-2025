using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    
    public void PlayGame()
    {
        StartCoroutine(LoadSceneGamePlay(1f));
    }

    private IEnumerator LoadSceneGamePlay(float delay)
    {
        yield return delay;
        SceneManager.LoadScene("GamePlay");
    }
}
