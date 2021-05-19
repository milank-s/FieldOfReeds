using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class Plant : MonoBehaviour
{

   public enum DesiredInput{touch, mic}
   public DesiredInput desiredInput = DesiredInput.mic;

   public AnimationPlayback animationController;
   public ARPlane plane;
   public Animator animator;

    void Start()    
    {
        MicInput.i.OnPlayerSpeak += OnMicInput;
        desiredInput = GameManager.i.currentSession.inputType;
    }

    void Update(){

    }

    public void OnMicInput(){
        if(desiredInput == DesiredInput.mic){
            animator.SetTrigger("React");
        }
    }

    public void LoopAnimation(bool loop){
        animator.SetBool("Loop", loop);
    }

    public void OnPlayerTouch(){
        if(desiredInput == DesiredInput.touch){
            animator.SetTrigger("React");
            animationController.MovePlayhead();
        }
    }
    
}
