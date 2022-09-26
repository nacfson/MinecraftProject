using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSceneManager : SceneManagerParent
{
    [SerializeField]
    private GameObject _optionMainPanel;
    private bool _onPanel;

    private void Awake()
    {
        OffOptionMainPanel();
    }

    private void Update()
    {
        GetInputs();
    }
    void GetInputs()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_onPanel)
            {
                OffOptionMainPanel();
            }
            else
            {
                OnOptionMainPanel();
            }
        }
    }


    public void OnOptionMainPanel()
    {
        _optionMainPanel.SetActive(true);
        Time.timeScale = 0;
        _onPanel = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void OffOptionMainPanel()
    {
        _optionMainPanel.SetActive(false);
        Time.timeScale = 1;
        _onPanel = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
