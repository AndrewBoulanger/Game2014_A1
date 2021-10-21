using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Effects
{
    explosion,
    laser,
    NumOfEffects
}

//class provides object resources that other objects need to create in the course of the game
public class EffectsPool : MonoBehaviour
{
    [SerializeField]
    List< GameObject> effectTypes;

    Dictionary<Effects, ObjectPool> effectPools;

    HudDelegate hudDelegate;

    // Start is called before the first frame update
    void Start()
    {
        effectPools = new Dictionary<Effects, ObjectPool>();
        int i = 0;
        foreach(GameObject effect in effectTypes)
        {
           ObjectPool pool = new ObjectPool( effect);
           effectPools.Add((Effects)i++, pool);
        }

    }

    public GameObject GetEffect(Effects effectType, Vector2 position)
    {
        GameObject effect = effectPools[effectType].GetObject(position);
        effect.transform.SetParent(transform);
        return effect;

    }

    public void ReturnEffect(Effects effectType, GameObject objectToReturn)
    {
        effectPools[effectType].ReturnObject(objectToReturn);
    }
}
