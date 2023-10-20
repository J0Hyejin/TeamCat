using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    private bool isPaused = false;

    public Button pauseButton; // �Ͻ����� ��ư

  
   public void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    void Pause()
    {
        Time.timeScale = 0f; // ���� �ð��� ����ϴ�.
        isPaused = true;
    }

    void Resume()
    {
        Time.timeScale = 1f; // ���� �ð��� �ٽ� �����մϴ�.
        isPaused = false;
    }
}
