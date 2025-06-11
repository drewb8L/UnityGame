using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;
public class MainMenuEvents : MonoBehaviour
{
   private UIDocument _document;
   private AudioSource _audioSource;
   private ProgressBar _pb;

   private void Awake()
   {
      _document = GetComponent<UIDocument>();
      _audioSource = GetComponent<AudioSource>();
      
      _pb = _document.rootVisualElement.Q<ProgressBar>();

      if (_pb != null)
      {
         Debug.Log("Progress bar found");
         _pb.value = 0;
         StartCoroutine(FakeLoading());
      }
   }

   private IEnumerator FakeLoading()
   {
      float duration = 3.0f;
      float elapsed = 0.0f;

      while (elapsed < duration)
      {
         elapsed += Time.deltaTime;
         float percent = Mathf.Clamp01(elapsed / duration);
         _pb.value = percent * 100;
         yield return null;
      }

      _pb.value = 100;
      Debug.Log("Progress bar finished");
   }

   private void OnDisable()
   {
 
   }

   
}
