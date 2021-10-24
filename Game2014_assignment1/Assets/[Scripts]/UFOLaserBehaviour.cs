using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOLaserBehaviour : MonoBehaviour
{ 
    GameObject target;

    static SpawnableObjectFactory factory;

    Timer shootTimer;
    float shootDelay = 2f;


    // Start is called before the first frame update
    void Start()
    {
        shootTimer = new Timer();
        if(factory == null)
        {
            factory = FindObjectOfType<SpawnableObjectFactory>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shootTimer.IsTimerDone(shootDelay) && factory != null)
        {
            GameObject laser = factory.CreateSpawnableObject(SObjectType.Laser, transform.position);

           laser.transform.rotation =  SetRotationFromPoint(target.transform.position);
            Vector2 direction = (target.transform.position - transform.position).normalized;
            laser.GetComponent<SimpleMovementController>().direction = direction;
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public Quaternion SetRotationFromPoint(Vector3 point)
    {
        Vector3 direction = (point - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion zRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        return zRotation;
    }
}
