using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsetControl : MonoBehaviour
{
   public AudioClip Worldcup;       //노래
   private AudioSource Headset;     //스피커
   private bool isplaying = false ;
   
   private void Start()
   {
      Headset = GetComponent<AudioSource>();
    // playsound(Worldcup,Headset);
   }
   
   public static void playsound(AudioClip clip, AudioSource audioPlayer)
   {
      audioPlayer.Stop();
      audioPlayer.clip = clip;
      audioPlayer.loop = false;
      audioPlayer.time = 0;
      audioPlayer.Play();
   }
   public static void stopsound(AudioClip clip, AudioSource audioPlayer)
   {
      audioPlayer.Stop();
     /* audioPlayer.clip = clip;
      audioPlayer.loop = false;
      audioPlayer.time = 0;
      audioPlayer.Stop();
     */
   }


   private void OnMouseDown()
   {
      print("헤드셋 클릭");

      if (isplaying == false)
      {
         playsound(Worldcup,Headset);
         isplaying = true;
      }
      else 
      {
         stopsound(Worldcup,Headset);
         isplaying = false;
      }
      
      
   }
   

   
}
