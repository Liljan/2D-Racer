using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputKeyboard : CarInputBase
{
    private void Update()
    {
        UpdateSteering();
        UpdateEnginePower();
    }

    private void UpdateSteering()
    {
        float x = Input.GetAxis("Horizontal");
        SetSteeringDirection(-x);
    }

    private void UpdateEnginePower()
    {
        float y = Input.GetAxis("Vertical");
        SetEnginePower(y);
    }
}
