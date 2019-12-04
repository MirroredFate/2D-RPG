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
        ui.intro_NameInput.onEndEdit.AddListener(delegate {Intro_NameInputSubmit(); });
        GameManager.Instance.SetIntroState(0);

        ui.text_Wait = new WaitForSeconds(0.1f);
        ui.intro_NameInput.gameObject.SetActive(false);

        DisablePanel(ui.mainMenu_Panel);
        EnablePanel(ui.intro_Panel);

        if(!ui.text_IsShowing){
            StartCoroutine(DisplayText(ui.dialogue.intro_Text, ui.intro_Text));
            StartCoroutine(Intro_ShowNameInput());
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameManager.Instance.GetGamestate()){
            case 0: // Main Menu
                
                break;
            case 1: // Intro Sequence
                Intro_Update();
                break;
        }
        
    }

    void Intro_Update()
    {
        switch(GameManager.Instance.GetIntroState()){
                    case 0: // Start Dialogue
                        if(!ui.text_IsShowing)
                        {
                            StopCoroutine(DisplayText(ui.dialogue.intro_Text, ui.intro_Text));
                        }
                        break;

                    case 1: // Name Input
                        StopCoroutine(Intro_ShowNameInput());
                        
                        break;

                    case 2: // Second Dialogue
                        if(!ui.text_IsShowing)
                        {

                            StopCoroutine(DisplayText(ui.dialogue.intro_Dialogue2, ui.intro_Text));
                        }
                        break;

                    default:
                        break;
                }
    }

    IEnumerator DisplayText(string[] text, TextMeshProUGUI displayText)
    {
        string sub = " ";
        string formattedText = " ";
        if(displayText.text != "")
        {
            displayText.text = "";
            
        }
        ui.text_IsShowing = true;
        for (int i = 0; i < text.Length; i++)
        {
            if(FormatText(text[i]) != "")
            {
                formattedText = FormatText(text[i]);
                Debug.Log(formattedText);

                for (int j = 0; j < formattedText.Length; j++)
                {
                    sub = formattedText.Substring(j, 1);
                
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
                if(i < text.Length - 1)
                {
                    yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
                    displayText.text = "";
                
                    StopCoroutine(WaitForKeyDown(KeyCode.Space));
                }
            }
            else
            {
                for (int j = 0; j < text[i].Length; j++)
                {
                    sub = text[i].Substring(j, 1);
                
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
                if(i < text.Length - 1)
                {
                    yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
                    displayText.text = "";
                
                    StopCoroutine(WaitForKeyDown(KeyCode.Space));
                }
            }
        }
        ui.text_IsShowing = false;
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode)){
            yield return null;
        }
    }

    string FormatText(string text)
    {
        string newText = "";

        // /p = Player Name
        if(text.Contains("/p"))
        {
            int index = text.IndexOf("/p");
            newText = text.Replace("/p", GameManager.Instance.player.GetPlayerName());
        }

        return newText;
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

    #region Intro Stuff

    IEnumerator Intro_ShowNameInput()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        while(ui.text_IsShowing)
        {
            yield return wait;
        }
        ui.intro_NameInput.gameObject.SetActive(true);
        GameManager.Instance.SetIntroState(1);
    }

    void Intro_NameInputSubmit()
    {
        GameManager.Instance.player.SetPlayerName(ui.intro_NameInput.text);
        GameManager.Instance.SetIntroState(2);
        StartCoroutine(DisplayText(ui.dialogue.intro_Dialogue2, ui.intro_Text));
        ui.intro_NameInput.gameObject.SetActive(false);
    }

    #endregion


}
