#define PC

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAVRInput : MonoBehaviour
{
    static Transform lHand;

    //씬에 등록된 왼쪽 컨트롤러 찾아 반환하기
    public static Transform LHand
    {
        get
        {
            if (lHand == null)
            {
#if PC
                //LHand 라는 이름으로 게임 오브젝트를 만든다.
                GameObject handObj = new GameObject("LHand");
                //만들어진 객체의 트랜스폼을 lHand에 할당
                lHand = handObj.transform;
                //컨트롤러를 카메라의 자식 객체로 등록
                lHand.parent = Camera.main.transform;
#endif
            }
            return lHand;
        }
    }

    static Transform rHand;
    //씬에 등록된 오른쪽 컨트롤러 찾아 반환하기
    public static Transform RHand
    {
        get
        {
            if(rHand == null) 
            {
#if PC
                //rHand 라는 이름으로 게임 오브젝트를 만든다.
                GameObject handOBj = new GameObject("RHand");
                //만들어진 객체의 트랜스폼을 lHand에 할당 
                rHand = handOBj.transform; 
                //컨트롤러를 카메라의 자식 객체로 등록
                rHand.parent = Camera.main.transform;
#endif 
            }
            return rHand;
        }
    }
    
    
    //오른쪽 컨트롤러의 위치 얻어오기
    public static Vector3 RHandPosition;

    //오른쪽 컨트롤러의 방향 얻어오기
    public static Vector3 RHandDirection;

    //왼쪾 컨트롤러의 위치 얻어오기
    public static Vector3 LHandPosition;

    //왼쪽 컨트롤로의 방향 얻어오기
    public static Vector3 LHandDirection;





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
