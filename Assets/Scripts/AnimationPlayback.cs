using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayback : MonoBehaviour
{
         
     Animator anim;
    public AnimationPlayback animationController;
    public bool loopAnimation;

    public float playbackTime;

     void Update () {
        
     }
    
    public void MovePlayhead(){
        playbackTime += Time.deltaTime;
        
        SetPlayhead(GetAnimationName(), playbackTime);

        if(playbackTime > 1){
            playbackTime = 0;
        }
    }
     void SetPlayhead(string name, float t)
     {
         anim.Play (name, 0, t);
     }
 
     string GetAnimationName()
     {
         var currAnimName = "";
         foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips) {
             if (anim.GetCurrentAnimatorStateInfo (0).IsName (clip.name)) {
                 currAnimName = clip.name.ToString();
             }
         }
 
         return currAnimName;
     }
 
}
