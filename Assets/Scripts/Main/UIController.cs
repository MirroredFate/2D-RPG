using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public UIHandler ui;

    // Start is called before the first frame update
    void Start()
    {
        // Disable all Panels, except Main Menu
        DisablePanel(ui.intro_Panel);

        
        // Start the Main Menu
        StartMainMenu();
    }

    void StartMainMenu(){
        ui.mainMenu_newgameButton.onClick.AddListener(() => MainMenu_NewGame());
        ui.mainMenu_exitButton.onClick.AddListener(() => MainMenu_ExitGame());
    }

    void StartIntro(){

        ui.text_Wait = new WaitForSeconds(0.1f);

        DisablePanel(ui.mainMenu_Panel);
        EnablePanel(ui.intro_Panel);

        StartCoroutine(DisplayText(ui.dialogue.intro_Text, ui.intro_Text));
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameManager.Instance.GetGamestate()){
            case 0: // Main Menu
                
                break;
            case 1: // Intro Sequence
                if(!ui.text_IsShowing)
                {
                    StopCoroutine(DisplayText(ui.dialogue.intro_Text, ui.intro_Text));
                }
                break;
        }
        
    }

    IEnumerator DisplayText(string[] text, TextMeshProUGUI displayText)
    {
        if(displayText.text != "")
        {
            displayText.text = "";
        }
        ui.text_IsShowing = true;
        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < text[i].Length; j++)
            {
                string sub = text[i].Substring(j, 1);

                if(sub == " ")
                {
                    displayText.text += sub;
                }
                else
                {
                    displayText.text += sub;
                    yield return ui.text_Wait;
                }
            } 
            yield return new WaitForSeconds(2f);
            if(i < text.Length - 1)
            {
                displayText.text = "";
            }
        }
        ui.text_IsShowing = false;
    }

    void DisablePanel(CanvasGroup panel){
        panel.alpha = 0f;
        panel.blocksRaycasts = false;
        panel.interactable = false;
        panel.gameObject.SetActive(false);
    }

    void EnablePanel(CanvasGroup panel){
        panel.alpha = 1f;
        panel.blocksRaycasts = true;
        panel.interactable = true;
        panel.gameObject.SetActive(true);
    }

    #region Button Scripts

    public void MainMenu_NewGame(){
        GameManager.Instance.SetGamestate(1);
        StartIntro();
    }

    public void MainMenu_ExitGame(){
        Application.Quit();
    }


    #endregion
}
