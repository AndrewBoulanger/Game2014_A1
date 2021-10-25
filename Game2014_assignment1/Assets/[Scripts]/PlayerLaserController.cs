///
///Author: Andrew Boulanger 101292574
///
/// File: PlayerLaserController.cs
/// 
/// Description: the actual laser beam part, passes damage data to the enemies. controls the width of the beam
/// 
/// last Modified: Oct 20th 2021
///
/// version history: 
///     v1 uses a raycast to check if its colliding with enemies. changes sprite width to extend as its being activated.
///     its width will reset to the collision point if it does hit an enemy
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the actual laser beam part, passes damage data to the enemies. controls the width of the beam
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
            SpawnableEnemy spawnableEnemy = hitResults.collider.gameObject.GetComponent<SpawnableEnemy>();
            if(spawnableEnemy != null)
                spawnableEnemy.TakeDamage(damageAmount);
            //pass damage amount to the enemy here (they'll use a timer to figure out if they need to take damage this frame)
            
        }
    }


    private void OnDisable()
    {
        renderer.size = new Vector2(0.0f, renderer.size.y);
    }

}
