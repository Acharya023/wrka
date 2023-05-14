using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybehaviour : MonoBehaviour
{
    public float speed;
    public float lineofsite;
    public float shootingrange;
    public float firerate = 1f;
    private float nextfiretime;
    public GameObject spear;
    public GameObject spearparent;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null){
            float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
            if(distanceFromPlayer<lineofsite&&distanceFromPlayer>shootingrange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed*Time.deltaTime);
            }
            else if(distanceFromPlayer<=shootingrange&&nextfiretime<Time.time)
            {
                Instantiate(spear,spearparent.transform.position,Quaternion.identity);
                nextfiretime = Time.time + firerate;
            }
    }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineofsite);
        Gizmos.DrawWireSphere(transform.position,shootingrange);
    }
}
