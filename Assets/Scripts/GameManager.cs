using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i;
    public AudioSource voiceSource;
    public bool listeningForPlayer;
    void Awake(){
        i = this;
    }
}
