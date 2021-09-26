using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
  


    private Vector3 InitialPosition;
    private Quaternion InitialRotation;
    void Start()
    {
        InitialPosition = transform.localPosition;
        InitialRotation = transform.localRotation;
    }

    private float InputX;
    private float InputY;

    void Update()
    {
        InputX = -Input.GetAxis("Mouse X");
        InputY = -Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1))
        {
            AimWeaponSway();
            AimWeaponTilt();
        }
        else
        {
            HipWeaponSway();
            HipWeaponTilt();
        }
    }

    [Header("Hip Sway")]
    public float HipAmount;
    public float HipMaxAmount;
    public float HipSmoothAmount;
    [Header("Hip Tilt")]
    public float HipTiltAmount;
    public float HipMaxTiltAmount;
    public float HipSmoothTiltAmount;
    public bool HipTiltY;

    private void HipWeaponSway() {
        float MovementX = Mathf.Clamp(InputX * HipAmount, -HipMaxAmount, HipMaxAmount);
        float MovementY = Mathf.Clamp(InputY * HipAmount, -HipMaxAmount, HipMaxAmount);

        Vector3 FinalPosition = new Vector3(MovementX, MovementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, InitialPosition + FinalPosition, Time.deltaTime * HipSmoothAmount);
    }

    private void HipWeaponTilt()
    {
        float TiltX = Mathf.Clamp(InputX * HipTiltAmount, -HipMaxTiltAmount, HipMaxTiltAmount);
        float TiltY = Mathf.Clamp(InputY * HipTiltAmount, -HipMaxTiltAmount, HipMaxTiltAmount);
        
        Quaternion FinalRotation = Quaternion.Euler( new Vector3(-TiltY, HipTiltY ? TiltX : 0, TiltX));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, InitialRotation * FinalRotation, Time.deltaTime * HipSmoothTiltAmount);
    }


    [Header("Aim Sway")]
    public float AimAmount;
    public float AimMaxAmount;
    public float AimSmoothAmount;
    [Header("Aim Tilt")]
    public float AimTiltAmount;
    public float AimMaxTiltAmount;
    public float AimSmoothTiltAmount;
    public bool AimTiltY;

    private void AimWeaponSway()
    {
        float MovementX = Mathf.Clamp(InputX * AimAmount, -AimMaxAmount, AimMaxAmount);
        float MovementY = Mathf.Clamp(InputY * AimAmount, -AimMaxAmount, AimMaxAmount);

        Vector3 FinalPosition = new Vector3(MovementX, MovementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, InitialPosition + FinalPosition, Time.deltaTime * AimSmoothAmount);
    }

    private void AimWeaponTilt()
    {
        float TiltX = Mathf.Clamp(InputX * AimTiltAmount, -AimMaxTiltAmount, AimMaxTiltAmount);
        float TiltY = Mathf.Clamp(InputY * AimTiltAmount, -AimMaxTiltAmount, AimMaxTiltAmount);

        Quaternion FinalRotation = Quaternion.Euler(new Vector3(-TiltY, AimTiltY ? TiltX : 0, TiltX));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, InitialRotation * FinalRotation, Time.deltaTime * AimSmoothTiltAmount);
    }
}
