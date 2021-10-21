using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleMovementController : MonoBehaviour
{

    public float speed = 2;
    public Vector3 direction = Vector3.left;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidbody.velocity = direction* speed;
    }

    private void OnEnable()
    {
        if(rigidbody != null)
            rigidbody.velocity = direction* speed;
    }
}
