using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameStates {MAIN_MENU, INTRO, CLASS_SELECTION, HOME, BATTLE, DUNGEON, TOWN}
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


    public GameStates states;

    private void Awake() {
        states = GameStates.MAIN_MENU;
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
                states = GameStates.MAIN_MENU;
                break;
            case 1:
                states = GameStates.INTRO;
                break;
            case 2:
                states = GameStates.CLASS_SELECTION;
                break;
            case 3:
                states = GameStates.HOME;
                break;
            case 4:
                states = GameStates.BATTLE;
                break;
            case 5: 
                states = GameStates.DUNGEON;
                break;
            case 6:
                states = GameStates.TOWN;
                break;
            default:
                states = GameStates.MAIN_MENU;
                break;

        }
    }

    public int GetGamestate(){
        switch(states){
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

}
