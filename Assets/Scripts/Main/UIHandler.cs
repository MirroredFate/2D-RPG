using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    // General
    [Header("General")]
    public DialogueHandler dialogue;
    public bool text_IsShowing;
    public WaitForSeconds text_Wait;
    
    //Main Menu
    [Header("Main Menu")]
    public CanvasGroup mainMenu_Panel;
    public TextMeshProUGUI mainMenu_titleText;
    public Button mainMenu_newgameButton;
    public Button mainMenu_exitButton;

    //Intro
    [Header("Intro")]
    public TextMeshProUGUI intro_Text;
    public CanvasGroup intro_Panel;


}
