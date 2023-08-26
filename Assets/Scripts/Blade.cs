using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
   private Collider bladecollider;
   private bool slicing;
   private Camera _camera;
   public Vector3 direction { get; private set; }
   public float minSliceVelocity = 0.01f;

   private void Awake()
   {
      bladecollider = GetComponent<Collider>();
      _camera=Camera.main;
      
   }

   private void OnEnable()
   {
       stopSlicing();
       
   }

   private void OnDisable()
   {
      stopSlicing();
   }

   private void Update() 
   {
      if (Input.GetMouseButtonDown(0))
      {
       startSlicing();
      }else if (Input.GetMouseButtonDown(0))
      {
         stopSlicing();
      } else if (slicing)
      {
         ContinueSlicing();
      }
   }
   void startSlicing()
   {
      Vector3 newPOS = _camera.ScreenToWorldPoint(Input.mousePosition);
      newPOS.z = 0f;
      
      transform.position = newPOS;

      
      slicing = true;
      bladecollider.enabled = true; 
   }
   void stopSlicing()
   {
      slicing = false;
      bladecollider.enabled = false; 

   }
   void ContinueSlicing()
   {
      Vector3 newPOS = _camera.ScreenToWorldPoint(Input.mousePosition);
      newPOS.z = 0f;
      direction = newPOS - transform.position;

      float velocity = direction.magnitude / Time.deltaTime;
      bladecollider.enabled = velocity > minSliceVelocity;
      transform.position = newPOS;
   }
}
