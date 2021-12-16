using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{

    [Header("Weapon Aiming")]
    private Vector3 InitialPosition;
    public Vector3 AimPosition;
    public float AimTime;

    public float StowDistance;

    void Start()
    {

        InitialPosition = transform.localPosition;
    }


    void Update()
    {
        RaycastHit hit;
        Ray Ray = new Ray(transform.position + transform.up * -0.1f, transform.parent.forward);
        bool TooClose = false;

        if (Physics.Raycast(Ray, out hit))
        {
            
            if (0 < hit.distance && hit.distance < StowDistance)
            {
                transform.localRotation = Quaternion.Euler(0,   ( StowDistance - hit.distance) * - 90 / StowDistance, 0);
                TooClose = true;
            }

            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                TooClose = false;
            }


        }

        AimDownSights(TooClose);

    }


    private void AimDownSights(bool TooClose)
    {

        if (Input.GetMouseButton(1) && !TooClose)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, AimPosition, Time.deltaTime * AimTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, InitialPosition, Time.deltaTime * AimTime);
        }

    }
}
