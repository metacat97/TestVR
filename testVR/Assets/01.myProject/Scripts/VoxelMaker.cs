using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    //���� ����
    public GameObject voxelFactory;

    //������Ʈ Ǯ�� ũ��
    public int voxelPoolSize = 20;
    //������Ʈ Ǯ
    public static List<GameObject> voxelPool = new List<GameObject>();

    public float creatTime = 0.1f;
    // ����ð�
    float currentTime = 0f;

    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        //������Ʈ Ǯ�� ��Ȱ��ȭ �� ������ ��� �ʹ�.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            //1. ���� �����ϱ�
            GameObject voxel = Instantiate(voxelFactory);
            //2. ���� ��Ȱ��ȭ�ϱ�
            voxel.SetActive(false);
            //3. ������ ������Ʈ Ǯ�� ���ʹ�.
            voxelPool.Add(voxel);
        }

        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.startWidth = 0.0f;
        lr.endWidth = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, Camera.main.transform.position);

        //����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�.
        //1. ����ڰ� ���콺�� Ŭ���ߴٸ� 
        //if (Input.GetButtonDown("Fire1"))
        //{

        //�����ð����� ������ ����� ����
        // 1.��� �ð��� �帥��.
        currentTime += Time.deltaTime;
        //2.��� �ð��� ���� �ð��� �ʰ��ߴٸ�
        if (currentTime > creatTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            //2. ���콺�� ��ġ�� �ٴ� ���� ��ġ���ִٸ�(Floor)
            if (Physics.Raycast(ray, out hitInfo))
            {
                lr.enabled =true;
                //{�ٲ�� ��
                ////3. ���� ���忡�� ������ �������Ѵ�.
                //GameObject voxel = Instantiate(voxelFactory);
                ////4. ������ ��ġ�ϰ� �ʹ�
                //voxel.transform.position = hitInfo.point;
                //}�ٲ�� ��

                //������Ʈ Ǯ �̿��ϱ�
                //1. ���� ������Ʈ Ǯ�� ������ �ִٸ� 
                if (voxelPool.Count > 0)
                {
                    currentTime = 0f;
                    //2. ������Ʈ Ǯ���� ������ �ϳ� �����´�
                    GameObject voxel = voxelPool[0];
                    //3.������ Ȱ��ȭ �Ѵ�.
                    voxel.SetActive(true);
                    //4.������ ��ġ 
                    voxel.transform.position = hitInfo.point;
                    //5. ������Ʈ Ǯ���� ������ �����Ѵ�
                    voxelPool.RemoveAt(0);
                }
                lr.SetPosition(1, hitInfo.point);
                

            } //if Physics.Raycast ������ ��
            else
            {
                lr.enabled = false; 
            }
        }
        //}
    }
}
