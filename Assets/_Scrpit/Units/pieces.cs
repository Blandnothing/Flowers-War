using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieces : MonoBehaviour
{
    //���ӵ���Ӫ
    public GameManager.EGamePlayer mpiecesCamp { get; protected set; }
    //�������� Ĭ��ΪҶ
    public EMode mPiecesMode { get; protected set; }
    //����״̬ Ĭ��Ϊ������ ����������ʱ��Ϊtrue�����ӱ�����
    public bool isRemove = false;
    //��������λ��,�����������ƶ� Ĭ��Ϊfalse 
    public bool isCenter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void piecesRemove() { 
        
    }
    public enum EMode
    {
        ROOT = 0,
        STEM = 1,
        LEAF = 2
    }
}
