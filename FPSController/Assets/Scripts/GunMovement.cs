using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    [Header("Idle Sway")]
    public float verticalSwayAmount = 0.5f;
    public float horiztonalSwayAmount = 1f;
    public float swaySpeed = 4f;

    [Header("Sway Multiplier")]
    public float HipMultiplier;
    public float MovementMultiplier;
    public float MovementSpeedMultiplier;

    public float SmoothAmount;
    void Update()
    {
        float UsedHipMultiplier = 1f;
        if (!Input.GetMouseButton(1))
        {
            UsedHipMultiplier = HipMultiplier;
        }

        float InputMultiplier = Mathf.Clamp01(Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        

        float UsedSwaySpeed = swaySpeed + MovementSpeedMultiplier * InputMultiplier;

        float x = 0, y = 0;
       
        y += (UsedHipMultiplier + MovementMultiplier * InputMultiplier) * verticalSwayAmount * Mathf.Sin((UsedSwaySpeed * 2) * Time.time);
        x += (UsedHipMultiplier + MovementMultiplier * InputMultiplier) * horiztonalSwayAmount * Mathf.Sin(UsedSwaySpeed * Time.time);

        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(x, y, transform.localPosition.z), Time.deltaTime * SmoothAmount);
      //  transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }
}
