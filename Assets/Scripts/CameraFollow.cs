
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
   [SerializeField]
   GameObject player;
  [SerializeField]
   float cameraAngle = 90;
   [SerializeField]
   int cameraDistance = 5;
   float _rotationX = 0f;
   float _rotationY = 0f;
   bool rightMouseCamera = false;
   public float sensitivity = 15f;
 private Vector3 _offset;
 [SerializeField] private Transform target;
  [SerializeField] private float smoothTime;
 private Vector3 _velocity;

 private void Awake()
 {
    _offset = transform.position - target.position;
 }

 private void Update()
 {
  
   _rotationX = Input.GetAxisRaw("Mouse X") * sensitivity;

 
   if(Input.GetMouseButton(1))
    {
      cameraAngle += _rotationX;
    }

    Vector3 targetPosition = target.position + _offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);

    Vector3 placeholder = PosFromAngle(cameraAngle);
    Vector3 cameraPos = player.transform.position + placeholder * cameraDistance;
    transform.position = cameraPos;
    
 }

 
 public Vector3 PosFromAngle(float angle)
 {
   angle += transform.eulerAngles.y;
   return new Vector3(Mathf.Sin(angle* Mathf.Deg2Rad), 0.8f, Mathf.Cos(angle * Mathf.Deg2Rad));
 }


// private void OnCameraMove(InputValue value) => rightMouseCamera = true;
}
