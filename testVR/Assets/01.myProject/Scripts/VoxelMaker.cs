using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    //복셀 제작
    public GameObject voxelFactory;

    //오브젝트 풀의 크기
    public int voxelPoolSize = 20;
    //오브젝트 풀
    public static List<GameObject> voxelPool = new List<GameObject>();

    public float creatTime = 0.1f;
    // 경과시간
    float currentTime = 0f;

    LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        //오브젝트 풀에 비활성화 된 복셀을 담고 싶다.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            //1. 복셀 생성하기
            GameObject voxel = Instantiate(voxelFactory);
            //2. 복셀 비활성화하기
            voxel.SetActive(false);
            //3. 복셀을 오브젝트 풀에 담고싶다.
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

        //사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다.
        //1. 사용자가 마우스를 클릭했다면 
        //if (Input.GetButtonDown("Fire1"))
        //{

        //일정시간마다 복셀을 만들고 싶음
        // 1.경과 시간이 흐른다.
        currentTime += Time.deltaTime;
        //2.경과 시간이 생성 시간을 초과했다면
        if (currentTime > creatTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            //2. 마우스의 위치가 바닥 위에 위치해있다면(Floor)
            if (Physics.Raycast(ray, out hitInfo))
            {
                lr.enabled =true;
                //{바뀌기 전
                ////3. 복셀 공장에서 복셀을 만들어야한다.
                //GameObject voxel = Instantiate(voxelFactory);
                ////4. 복셀을 배치하고 싶다
                //voxel.transform.position = hitInfo.point;
                //}바뀌기 전

                //오브젝트 풀 이용하기
                //1. 만약 오브젝트 풀에 복셀이 있다면 
                if (voxelPool.Count > 0)
                {
                    currentTime = 0f;
                    //2. 오브젝트 풀에서 복셀을 하나 가져온다
                    GameObject voxel = voxelPool[0];
                    //3.복셀을 활성화 한다.
                    voxel.SetActive(true);
                    //4.복셀을 배치 
                    voxel.transform.position = hitInfo.point;
                    //5. 오브젝트 풀에서 복셀을 제거한다
                    voxelPool.RemoveAt(0);
                }
                lr.SetPosition(1, hitInfo.point);
                

            } //if Physics.Raycast 끝나는 곳
            else
            {
                lr.enabled = false; 
            }
        }
        //}
    }
}
