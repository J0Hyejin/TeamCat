using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    private bool isPaused = false;

    public Button pauseButton; // 일시정지 버튼

  
   public void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    void Pause()
    {
        Time.timeScale = 0f; // 게임 시간을 멈춥니다.
        isPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1f; // 게임 시간을 다시 시작합니다.
        isPaused = false;
    }
}
