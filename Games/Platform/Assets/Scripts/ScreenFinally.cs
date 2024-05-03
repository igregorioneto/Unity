using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFinally : MonoBehaviour
{
    [SerializeField] AudioClip soundButton;

    public void LoadScene(string sceneName)
    {
        if (soundButton != null)
           AudioSource.PlayClipAtPoint(soundButton, Camera.main.transform.position);
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
