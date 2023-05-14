using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sperascript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized*speed;
        bulletRB.velocity = new Vector2(moveDir.x,moveDir.y);
        Destroy(this.gameObject,2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player playerComponent))
        {
            playerComponent.TakeDamage(1);
            Destroy(gameObject);

        }
    }
}
