using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionScript : MonoBehaviour
{

    public virtual void StartSession(){

    }

    public virtual IEnumerator SessionSequence(){

        yield return null;
    }

    public virtual void EndSession(){

    }

    public IEnumerator PlayNarration(AudioClip clip){
        GameManager.i.voiceSource.clip = clip;
        GameManager.i.voiceSource.Play();
        while(GameManager.i.voiceSource.isPlaying){
            yield return null;
        }
        GameManager.i.voiceSource.clip= null;
    }

    public IEnumerator WaitForPlayer(){

        GameManager.i.listeningForPlayer = true;

         while(MicInput.averageLoudness < 0.2f){
            yield return null;
        }

        while(MicInput.averageLoudness > 0.2f){

            yield return null;
        }
        GameManager.i.listeningForPlayer = false;
    }
}
