using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5;

    //{복셀 관련 변수들

    //복셀 제거할 시간
    public float destroyTime = 2.0f;
    //경과시간
    float currentTime;

//}복셀 관련 변수들


    void OnEnable()
    {
        currentTime = 0;

        Vector3 direction = Random.insideUnitSphere;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed; 
    }

    void Update()
    {
        //시간이 흐름
        currentTime += Time.deltaTime;

        if (currentTime > destroyTime) 
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);

            VoxelMaker.voxelPool.Add(gameObject);
        }
    }
}
