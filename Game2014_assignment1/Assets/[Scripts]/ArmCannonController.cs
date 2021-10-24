using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCannonController : MonoBehaviour
{
    Vector3 direction;
    Quaternion zRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3();
        zRotation = new Quaternion();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRotationFromPoint(Vector3 point)
    {
        direction = (point - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        zRotation = Quaternion.AngleAxis(angle, Vector3.forward);
  
        transform.rotation = zRotation;
    }
}