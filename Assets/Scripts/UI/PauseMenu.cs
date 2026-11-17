using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> pauseMenuItems;
    [SerializeField] private GameObject pauseButton;
    private bool _isPaused = false;

    public void Pause()
    {
        if (!_isPaused)
        {
            pauseButton.SetActive(false);
            foreach(GameObject obj in pauseMenuItems)
            {
                obj.SetActive(true);
            }
            Time.timeScale = 0;
            _isPaused = true;
        }
        else if (_isPaused)
        {
            pauseButton.SetActive(true);
            foreach(GameObject obj in pauseMenuItems)
            {
                obj.SetActive(false);
            }
            Time.timeScale = 1;
            _isPaused = false;
        }
    }

    public void HandleResume()
    {
        Pause();
    }

    public void HandleMainMenu()
    {
        Pause();
        SceneManager.LoadScene(1);
    }

    public void HandleExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
