using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPanel;
    private bool _mainPanelOn;
    [SerializeField]
    private RecipeManager _recipeManager;

    private void Awake()
    {
        OffMainPanel();
    }

    private void Update()
    {
        
    }
    void GetInputs()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_mainPanelOn)
            {
                OffMainPanel();

            }
            else
            {
                OnMainPanel();
            }
        }
    }

    public void OnMainPanel()
    {
        SoundManager.instance.SFXPlay("SoundObject","minecraft_click");
        _mainPanel.SetActive(true);
        _mainPanelOn = true;
        //RecipeManager.CheckPanelList();
        
    }
    public void OffMainPanel()
    {
        SoundManager.instance.SFXPlay("SoundObject","minecraft_click");
        _mainPanel.SetActive(false);
    }
}
