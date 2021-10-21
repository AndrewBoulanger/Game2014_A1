using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour
{

    public float scalingSpeed;
    private SpriteRenderer renderer;

    public float damageAmount = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
   
        renderer.size = new Vector2(renderer.size.x + scalingSpeed, renderer.size.y);
  
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitResults = Physics2D.Raycast(transform.position, transform.right, renderer.size.x, LayerMask.GetMask("Enemies"));
        if (hitResults.collider != null)
        {
            renderer.size = new Vector2(hitResults.distance, renderer.size.y);
            hitResults.collider.gameObject.GetComponent<SpawnableObject>().TakeDamage(damageAmount);
            //pass damage amount to the enemy here (they'll use a timer to figure out if they need to take damage this frame)
            
        }
    }


    private void OnDisable()
    {
        renderer.size = new Vector2(0.0f, renderer.size.y);
    }



}
