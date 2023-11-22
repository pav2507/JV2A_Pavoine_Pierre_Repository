using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject circle;
    public MovementEtTir movementEtTirRef;
    private Ennemy ennemy;


    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up*speed;
        movementEtTirRef = FindObjectOfType<MovementEtTir>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ennemy = collision.gameObject.GetComponent<Ennemy>();
        if (ennemy)
        {
            movementEtTirRef.Scorefunction();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(circle, transform.position, Quaternion.identity);
        }
    }
}
