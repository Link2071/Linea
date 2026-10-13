using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool _isPaused = false;

    public void Pause()
    {
        if (!_isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            _isPaused = true;
        }
        else if (_isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            _isPaused = false;
        }
    }
}
