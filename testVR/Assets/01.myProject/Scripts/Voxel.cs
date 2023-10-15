using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    public float speed = 5;

    //{���� ���� ������

    //���� ������ �ð�
    public float destroyTime = 2.0f;
    //����ð�
    float currentTime;

//}���� ���� ������


    void OnEnable()
    {
        currentTime = 0;

        Vector3 direction = Random.insideUnitSphere;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed; 
    }

    void Update()
    {
        //�ð��� �帧
        currentTime += Time.deltaTime;

        if (currentTime > destroyTime) 
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);

            VoxelMaker.voxelPool.Add(gameObject);
        }
    }
}
