using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    private Vector3 InitialLocalPosition;
    void Start()
    {
        InitialLocalPosition = transform.localPosition;
        PreviousPosition = transform.position;
    }


    void LateUpdate()
    {
        WeaponTilt();
      //  WeaponSway();
    }

    public float MaxRoationAngle;
    public float RoationMultiplier;


    private float RotationY = 0;

    //when turning
    private void WeaponTilt()
    {

        float RotationSpeed = (transform.eulerAngles.y - RotationY) * RoationMultiplier;
        RotationY = transform.eulerAngles.y;


    
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Clamp(RotationSpeed, -MaxRoationAngle, MaxRoationAngle));
        if (RotationSpeed != 0)
        {
           Debug.Log( Mathf.Clamp(RotationSpeed, -MaxRoationAngle, MaxRoationAngle)) ;
        }

    }

    public float WeaponSwayRate;
    public float WeaponSwayAmplitude;
    public float WeaponSwayMovementModifier;

    private float X = 0;
    private Vector3 PreviousPosition;
    private void WeaponSway()       
    {
        float Speed = (transform.position - PreviousPosition).magnitude * WeaponSwayMovementModifier * Time.deltaTime;
     //   Debug.Log(Speed);
        PreviousPosition = transform.position;


        X += WeaponSwayRate * Time.deltaTime;
        transform.localPosition = new Vector3(InitialLocalPosition.x, InitialLocalPosition.y + (WeaponSwayAmplitude + Speed) * Mathf.Sin(X), InitialLocalPosition.z);


    }
}
