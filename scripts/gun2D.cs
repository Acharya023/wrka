using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    Vector3 gunpos;
    float angle;
    [SerializeField] private AudioSource shoot;
 
    void Update()
    {
        gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(gunpos.y,gunpos.x)*Mathf.Rad2Deg;

        if(gunpos.x<transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x,180f,transform.rotation.z);
        }
        else{
            transform.eulerAngles = new Vector3(transform.rotation.x,0f,transform.rotation.z);
        }
        if(Input.GetMouseButtonDown(0))
        {
            shoot.Play();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        }
    }
}
