using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ScrollingBackground : MonoBehaviour
{
   //Give script to background layers and set speed individually there.
   [SerializeField] private Vector2 scrollingMultiplier;
   private float textureUnitSizeX;
   private Transform cameraTransform;
   private Vector3 lastCameraPosition;
   
   private void Start()
   {
      cameraTransform = Camera.main.transform;
      lastCameraPosition = cameraTransform.position;
      Sprite sprite = GetComponent<SpriteRenderer>().sprite;
      Texture2D texture = sprite.texture;
      textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
   }

   private void FixedUpdate()
   {
      Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
      transform.position -= new Vector3(deltaMovement.x * scrollingMultiplier.x, deltaMovement.y * scrollingMultiplier.y);
      lastCameraPosition = cameraTransform.position;
   }
}
