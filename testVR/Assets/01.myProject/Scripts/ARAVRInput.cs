#define PC

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAVRInput : MonoBehaviour
{
    static Transform lHand;

    //���� ��ϵ� ���� ��Ʈ�ѷ� ã�� ��ȯ�ϱ�
    public static Transform LHand
    {
        get
        {
            if (lHand == null)
            {
#if PC
                //LHand ��� �̸����� ���� ������Ʈ�� �����.
                GameObject handObj = new GameObject("LHand");
                //������� ��ü�� Ʈ�������� lHand�� �Ҵ�
                lHand = handObj.transform;
                //��Ʈ�ѷ��� ī�޶��� �ڽ� ��ü�� ���
                lHand.parent = Camera.main.transform;
#endif
            }
            return lHand;
        }
    }

    static Transform rHand;
    //���� ��ϵ� ������ ��Ʈ�ѷ� ã�� ��ȯ�ϱ�
    public static Transform RHand
    {
        get
        {
            if(rHand == null) 
            {
#if PC
                //rHand ��� �̸����� ���� ������Ʈ�� �����.
                GameObject handOBj = new GameObject("RHand");
                //������� ��ü�� Ʈ�������� lHand�� �Ҵ� 
                rHand = handOBj.transform; 
                //��Ʈ�ѷ��� ī�޶��� �ڽ� ��ü�� ���
                rHand.parent = Camera.main.transform;
#endif 
            }
            return rHand;
        }
    }
    
    
    //������ ��Ʈ�ѷ��� ��ġ ������
    public static Vector3 RHandPosition;

    //������ ��Ʈ�ѷ��� ���� ������
    public static Vector3 RHandDirection;

    //�ަU ��Ʈ�ѷ��� ��ġ ������
    public static Vector3 LHandPosition;

    //���� ��Ʈ�ѷ��� ���� ������
    public static Vector3 LHandDirection;





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
