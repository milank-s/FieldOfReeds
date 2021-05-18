using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public AudioSource voiceSource;
    public SessionScript currentSession;
    public GameObject title;
    public bool gameStarted = false;
    public bool listeningForPlayer;

    public bool playIntroNarration;

    void Awake(){
        Application.targetFrameRate = 60;
        i = this;
    }

    void Update(){
        if(Input.touchCount > 0 || Input.anyKeyDown){
            if(!gameStarted && playIntroNarration){
                currentSession.StartSession();
                title.SetActive(false);
            }
            gameStarted = true;
        }        
    }
}
