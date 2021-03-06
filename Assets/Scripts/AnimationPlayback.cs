using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayback : MonoBehaviour
{
         
    Animator anim;
    public float playbackTime;

    void Awake(){
        anim = GetComponent<Animator>();
    }
    
    public void MovePlayhead(){
        
        playbackTime += Time.deltaTime/GetCurrentClip().length;
        
        if(playbackTime > 1){
            playbackTime = 0;
        }
    }
    public void SetPlayhead(){
        anim.Play (GetAnimationName(), 0, playbackTime);

    }
    public void LoopAnimation(bool loop){
        anim.SetBool("Loop", loop);
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

     AnimationClip GetCurrentClip()
     {
         
         foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips) {
             if (anim.GetCurrentAnimatorStateInfo (0).IsName (clip.name)) {
                 return clip;
             }
         }

         return null;
     }
 
}
