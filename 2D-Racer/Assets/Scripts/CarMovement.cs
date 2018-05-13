using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public float maximumEngineForce;
    public float maximumReverseEngineForce;
    public float maximumSteeringTorque;
    public float reversePower;
    public float acceleration;
    public float deceleration;

    private float m_EnginePower = 0F;
    private float m_TargetEnginePower = 0F;
    private float m_SteeringDirection = 0F;

    private Rigidbody2D m_rb2d;

    private void Awake()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateEnginePower();
    }

    private void UpdateEnginePower()
    {
        float acc = Mathf.Abs(m_EnginePower) < Mathf.Abs(m_TargetEnginePower) ? acceleration : deceleration;

        m_EnginePower = Mathf.MoveTowards(m_EnginePower, m_TargetEnginePower, acc * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteeringForce();
    }

    private void ApplyEngineForce()
    {
        float engineForce = m_EnginePower >= 0F ? maximumEngineForce : maximumReverseEngineForce;

        m_rb2d.AddForce(transform.up * m_EnginePower * engineForce, ForceMode2D.Force);
    }

    private void ApplySteeringForce()
    {
        m_rb2d.AddTorque(m_SteeringDirection * maximumSteeringTorque, ForceMode2D.Force);
    }

    public void SetSteeringDirection(float steeringDirection)
    {
        m_SteeringDirection = Mathf.Clamp(steeringDirection, -1F, 1F);
    }

    public void SetEnginePower(float enginePower)
    {
        m_TargetEnginePower = Mathf.Clamp(enginePower, -1F, 1F);
    }

}
