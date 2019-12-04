using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameStates {MAIN_MENU, INTRO, CLASS_SELECTION, HOME, BATTLE, DUNGEON, TOWN}
public enum IntroStates { DIALOGUE_1, NAME_INPUT, DIALOGUE_2 }
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }


    public GameStates game_States;
    public IntroStates intro_States;

    public Player player;

    private void Awake() {
        game_States = GameStates.MAIN_MENU;
    }

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGamestate(int state){
        switch(state){
            case 0:
                game_States = GameStates.MAIN_MENU;
                break;
            case 1:
                game_States = GameStates.INTRO;
                break;
            case 2:
                game_States = GameStates.CLASS_SELECTION;
                break;
            case 3:
                game_States = GameStates.HOME;
                break;
            case 4:
                game_States = GameStates.BATTLE;
                break;
            case 5: 
                game_States = GameStates.DUNGEON;
                break;
            case 6:
                game_States = GameStates.TOWN;
                break;
            default:
                game_States = GameStates.MAIN_MENU;
                break;

        }
    }

    public void SetIntroState(int state){
        switch(state){
            case 0:
                intro_States = IntroStates.DIALOGUE_1;
                break;
            case 1:
                intro_States = IntroStates.NAME_INPUT;
                break;
            case 2:
                intro_States = IntroStates.DIALOGUE_2;
                break;
            default:
                intro_States = IntroStates.DIALOGUE_1;
                break;
        }
    }

    public int GetGamestate(){
        switch(game_States){
            case GameStates.MAIN_MENU:
                return 0;
            case GameStates.INTRO:
                return 1;
            case GameStates.CLASS_SELECTION:
                return 2;
            case GameStates.HOME:
                return 3;
            case GameStates.BATTLE:
                return 4;
            case GameStates.DUNGEON: 
                return 5;
            case GameStates.TOWN:
                return 6;
            default:
                return 0;
        }
    }

    public int GetIntroState(){
        switch(intro_States){
            case IntroStates.DIALOGUE_1:
                return 0;
            case IntroStates.NAME_INPUT:
                return 1;
            case IntroStates.DIALOGUE_2:
                return 2;
            default:
                return 0;
        }
    }

}
