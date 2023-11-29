using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RoatateArm(newAimDirection);
    }

    private void RoatateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        armRenderer.flipY = Mathf.Abs(rotZ)>90f;
        characterRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0,0,rotZ);
    }

    void Update()
    {
        
    }
}
