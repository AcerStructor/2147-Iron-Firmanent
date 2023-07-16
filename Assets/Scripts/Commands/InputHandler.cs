﻿using UnityEngine;

/// <summary>
/// This class handles all the input which the
/// player does such as moving and shooting
/// </summary>
public class InputHandler : MonoBehaviour
{
    private ICommand _moveForward;
    private ICommand _moveBackward;
    private ICommand _moveLeft;
    private ICommand _moveRight;
    private ICommand _shoot;

    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _movementLimitX, _movementLimitY;

    private void Awake()
    {
        if (_player == null) _player = GameObject.FindWithTag("Player");
        
        Transform playerTransform = _player.GetComponent<Transform>();

        _moveForward = new MoveCommand(playerTransform, Vector3.up, _speed, _movementLimitX, _movementLimitY);
        _moveBackward = new MoveCommand(playerTransform, Vector3.down, _speed, _movementLimitX, _movementLimitY);
        _moveLeft = new MoveCommand(playerTransform, Vector3.left, _speed, _movementLimitX, _movementLimitY);
        _moveRight = new MoveCommand(playerTransform, Vector3.right, _speed, _movementLimitX, _movementLimitY);
        _shoot = new ShootCommand(playerTransform);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) _moveForward.Execute();
        if (Input.GetKey(KeyCode.S)) _moveBackward.Execute();
        if (Input.GetKey(KeyCode.A)) _moveLeft.Execute();
        if (Input.GetKey(KeyCode.D)) _moveRight.Execute();
        if (Input.GetKeyDown(KeyCode.Space)) _shoot.Execute();
    }
}
