﻿using UnityEngine;

/// <summary>
/// A carrier drone. It just carry but doesn't attack.
/// Hmmm... maybe it carries a supply to another AI outpost
/// I guess?....
/// </summary>
public class CarrierDrone : Drone
{
    private float _current;

    [SerializeField] private AnimationCurve _curve;
    [SerializeField] protected Vector2 _spawningPos;
    [SerializeField] protected Vector2 _targetPos;
    [SerializeField] protected bool _isMovementLocked;
    
    private static readonly int Flying = Animator.StringToHash("Flying");

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }
    protected override int GetState()
    {
        return Flying;
    }

    public override void Move()
    {
        if (_isMovementLocked)
        {
            _current = Mathf.MoveTowards(_current, 1f, _moveSpeed * Time.deltaTime);
            Vector3 currentPos = Vector3.Lerp(_spawningPos, _targetPos, _curve.Evaluate(_current));
            transform.position = currentPos;
        }
        else
        {
            transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
        }
    }

    public override void Die()
    {
        ObjectPool.Instance.SpawnFromPool("Bubble_100", transform.position, Quaternion.identity);
        base.Die();
    }
}
