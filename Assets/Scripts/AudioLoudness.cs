using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
 
 public class AudioLoudness : MonoBehaviour {
 
     public AudioSource audioSource;
     public float updateStep = 0.1f;
     public int sampleDataLength = 1024;
 
     private float currentUpdateTime = 0f;
 
     public float loudness;
     private float[] clipSampleData;
 
     // Use this for initialization
     void Awake () {
     
         if (!audioSource) {
             Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
         }
         clipSampleData = new float[sampleDataLength];
 
     }
     
     // Update is called once per frame
     void Update () {
     
     if(audioSource.isPlaying){
         currentUpdateTime += Time.deltaTime;
         if (currentUpdateTime >= updateStep) {
             
             currentUpdateTime = 0f;
             audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
             loudness = 0f;
             foreach (var sample in clipSampleData) {
                 loudness += Mathf.Abs(sample);
             }
             loudness /= sampleDataLength; //clipLoudness is what you are looking for
         }
     }else{
         loudness = Mathf.Lerp(loudness, 0, Time.deltaTime);
     }
     }
 }
