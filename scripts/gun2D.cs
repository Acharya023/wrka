using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
 
    void Update()
    {
        Vector3 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(gunpos.x<transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x,180f,transform.rotation.z);
        }
        else{
            transform.eulerAngles = new Vector3(transform.rotation.x,0f,transform.rotation.z);
        }
        if(Input.GetMouseButtonDown(0))
        {
            shooting();
        }
    }
    void shooting()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0f);
    }

}
