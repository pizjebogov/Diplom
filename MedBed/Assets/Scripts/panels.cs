using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class panels : MonoBehaviour
{
    public GameObject AnglePanel;
    public GameObject ButtonPanel;
    public GameObject AngleVector;
    public Button[] PoseButtons = new Button[6];
    public GameManager gm;
    
    void Start()
    {
        /* Calibrating(AnglePanel, Screen.width / 6, Screen.height / 2, Screen.width / 12, 0);
         Calibrating(ButtonPanel, Screen.width, Screen.height / 8, 0, Screen.height / 16);
         */
       // gm.switchtohead();
    }

    // Update is called once per frame
    void Update()
    {
        
        Rect Anglerect = AnglePanel.GetComponent<RectTransform>().rect;
        
        Calibrating(AnglePanel, Screen.width / 5, Screen.height / 3, Screen.width / 5, Screen.height / 6);
        Calibrating(ButtonPanel, Screen.width, Screen.height / 5, 0, Screen.height / 10);
        ButtonPanel.GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.width / 6, Screen.height / 5);
        Calibrating(AngleVector, Screen.width / 50, Screen.width / 50, Screen.width / 10, -Screen.height / 6);
        
        switch (gm.mode)
        {
            case ("head"):
                PoseButtons[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PoseButtons[1].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[2].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                break;
            case ("body"):
                PoseButtons[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PoseButtons[0].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[2].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                break;
            case ("legs"):
                PoseButtons[2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PoseButtons[1].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[0].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                break;
            case ("spine"):
                PoseButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PoseButtons[1].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[2].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[0].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                break;
            case ("gozero"):
                PoseButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PoseButtons[1].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[2].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[0].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                for(int i = 0; i < 4; i++)
                {
                    PoseButtons[i].GetComponent<Button>().interactable = false;
                }
                PoseButtons[5].GetComponent<Button>().interactable = false;
                break;
            case ("Cycling"):
                PoseButtons[5].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                PoseButtons[1].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[2].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[3].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[4].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                PoseButtons[0].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                for (int i = 0; i < 5; i++)
                {
                    PoseButtons[i].GetComponent<Button>().interactable = false;
                }
                break;
            case (null):
                foreach(Button button in PoseButtons)
                {
                    button.GetComponent<Button>().interactable = true;
                    button.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                }
                break;
        }
    }

    public void Calibrating(GameObject calibrated,float width,float height,float posx,float posy)
    {
        RectTransform rt = calibrated.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, height);
        rt.anchoredPosition = new Vector2(posx, posy);

    }
}
