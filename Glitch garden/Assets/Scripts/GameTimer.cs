using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
   [Tooltip("Level timer in seconds")] [SerializeField]
   private float levelTime = 10f;
   private bool levelFinished = false;

   private Slider slider;
   private void Start()
   {
      slider = GetComponent<Slider>();
   }

   private void Update()
   {
      if (levelFinished) { return; }
      slider.value = Time.timeSinceLevelLoad / levelTime;

      bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
      if (timerFinished)
      {
         FindObjectOfType<LevelController>().LevelTimerFinished();
         levelFinished = true;
      }
   }
   
}
