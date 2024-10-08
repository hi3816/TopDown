using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttackIng { get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack < 0.2f)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (IsAttackIng && timeSinceLastAttack >= 0.2f)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
