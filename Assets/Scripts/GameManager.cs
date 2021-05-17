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

    void Awake(){
        i = this;
    }

    void Update(){
        if(Input.anyKeyDown){
            if(!gameStarted){
                currentSession.StartSession();
                title.SetActive(false);
            }
            gameStarted = true;
        }        
    }
}
