using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class Plant : MonoBehaviour
{

   public enum DesiredInput{touch, mic}
   public DesiredInput desiredInput = DesiredInput.mic;

   public AnimationPlayback animationPlayback;
   public ARPlane plane;
   public Animator animator;

    void Awake(){
        animationPlayback = GetComponent<AnimationPlayback>();
    }
    void Start()    
    {
        MicInput.i.OnPlayerSpeak += OnMicInput;
        desiredInput = GameManager.i.currentSession.inputType;
    }

    void Update(){
        if(desiredInput == DesiredInput.touch){
            animationPlayback.SetPlayhead();
        }
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
            animationPlayback.MovePlayhead();
        }
    }
    
}
