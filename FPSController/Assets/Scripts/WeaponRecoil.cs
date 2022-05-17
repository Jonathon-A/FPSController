using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{

    private Quaternion InitialRotation;
    private Vector3 InitialPosition;

    void Start()
    {
        InitialPosition = transform.localPosition;
        InitialRotation = transform.localRotation;
        FireRate = 60f / FireRateRPM;
      
    }

    void Update()
    {
        
        FireTime += Time.deltaTime;
        if (Input.GetMouseButton(0) && FireTime >= FireRate)
        {
             Fire();
            
        }
       
            Return();
        
    }

    private float FireRate;
    public FirstPersonLook CameraScript;

    [Header("Weapon Stats")]
    public float FireRateRPM;

    public float MaxRecoilX;
    public float MinRecoilX;
    public float MaxRecoilY;
    public float MinRecoilY;

    public float RecoilAmount;
    public float RecoilSmoothAmount;

    public float ReturnSmoothAmount;
    //public float ReturnTime;

    private float FireTime;

    [Header("Weapon Shooting")]
    public AudioSource GunShotSource;


    public Transform ShootPoint;

    public GameObject Bullet;

    public ParticleSystem MuzzleFlash;

    public float BulletVelocity;

    public float RemovalTime;
    private void Fire()
    {
        CameraScript.AddRotation(new Vector2(-Random.Range(MinRecoilX, MaxRecoilX), Random.Range(MinRecoilY, MaxRecoilY)));


        transform.localPosition = Vector3.Lerp(transform.localPosition, InitialPosition + new Vector3(0,0, -RecoilAmount), Time.deltaTime * RecoilSmoothAmount);

        MuzzleFlash.Play();

        GameObject NewBullet = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation) as GameObject;
        NewBullet.transform.Rotate(Vector3.up * 90f);
        NewBullet.GetComponent<Rigidbody>().velocity = ShootPoint.forward * BulletVelocity ;

        Destroy(NewBullet, RemovalTime);

        FireTime %= FireRate;

        AudioSource newShotSound =  Instantiate(GunShotSource, ShootPoint.position, ShootPoint.rotation) as AudioSource;

        newShotSound.Play();

   


    }
    private void Return()
    {

     transform.localPosition = Vector3.Lerp(transform.localPosition, InitialPosition, Time.deltaTime * ReturnSmoothAmount);
    }
}
