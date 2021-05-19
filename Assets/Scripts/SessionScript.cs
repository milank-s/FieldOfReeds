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

    public void SetPlantInput(Plant.DesiredInput i){
        foreach(Plant p in PlantManager.i.plants){
            p.desiredInput = i;
        }
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

        float maxMicVolume = 0;
        float t =0;

        bool waitingForSpeech = true;
         while(waitingForSpeech){
             if(MicInput.averageLoudness > 0.01f){

                 MicInput.i.PlayerSpoke();
                 
                 waitingForSpeech = false;
             }

            yield return null;
        }

        t = 0;
        while(t < 1){
            t += Time.deltaTime;
            if(MicInput.MicLoudness > maxMicVolume){
                maxMicVolume = MicInput.MicLoudness;
            }
            yield return null;
        }
    
        t= 0;
        while(t < 1){
            if(MicInput.averageLoudness > 0.01f){
               t = 0;
            }else{
                t += Time.deltaTime;
            }

            yield return null;
        }

        GameManager.i.listeningForPlayer = false;
    }
    
}
