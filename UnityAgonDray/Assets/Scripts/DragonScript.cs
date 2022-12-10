using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public float minZ = 65f;
    public float maxZ = 87.5f;
    public float returnSpeed = 1.0f;
    public GameObject player;
    public BossPillarScript pillarManager;
    public BossRangeScript range;

    private float defaultZ;

    private void Awake()
    {
        defaultZ = transform.position.z;
    }

    private void Update()
    {
        Vector3 pos = transform.position;

        if (range.inRange && !pillarManager.active)
        {
            pos.z = player.transform.position.z;
            if (pos.z < minZ) pos.z = minZ;
            if (pos.z > maxZ) pos.z = maxZ;
        }
        else
        {
            if (Mathf.Abs(transform.position.z - defaultZ) < returnSpeed * Time.deltaTime)
            {
                
                pos.z = defaultZ;
            }
            else
            {
                pos.z += (returnSpeed * Time.deltaTime) * Mathf.Sign(defaultZ - transform.position.z);
                
            }
        }

        transform.position = pos;
    }
}
