using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour
{
    // ButtonSelect 는 버튼 생성하는 오브젝트의 부모로 있어야 한다.
    [SerializeField]
    public List<Button> buttonList = new List<Button>();
    public int buttonCount;
    [SerializeField] private int horizontalCount;
    public bool buttonMove;

    public bool listChanged;


    private void Start()
    {
        buttonCount = 0;
        buttonMove = true;
        listChanged =false;
    }


    private void Update()
    {
        CheckButtonPanelCount();
        CheckSelectedButton();
        UseButton();
    }

    
    public void CheckButtonPanelCount()
    {
        if(buttonMove == true)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                if (buttonCount > 0)
                {
                    buttonCount--;
                    CheckSelectedButton();
                }
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (buttonCount < buttonList.Count - 1)
                {
                    buttonCount++;
                    CheckSelectedButton();
                }
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (buttonCount > horizontalCount - 1)
                {
                    buttonCount -= horizontalCount;
                    CheckSelectedButton();
                }
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {

                if (buttonCount < buttonList.Count - horizontalCount)
                {
                    buttonCount += horizontalCount;
                    CheckSelectedButton();
                }
            }
            CheckSelectedButton();
        }
    }
    public void UseButton()
    {
        if(buttonMove == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                buttonList[buttonCount].onClick.Invoke();
                
            }
        }

    }
    
    /// <summary>
    /// ���õ� ��ư�� �ִ��� üũ�Ѵ�
    /// </summary>
    public void CheckSelectedButton()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (i == buttonCount)
            {
                buttonList[i].GetComponent<IButton>().Selected();
            }
            else
            {
                
                buttonList[i].GetComponent<IButton>().NoneSelected();
            }
        }
    }

}
