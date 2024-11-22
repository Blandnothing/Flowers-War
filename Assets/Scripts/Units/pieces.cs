using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieces : MonoBehaviour
{
    //棋子的阵营
    public GameManager.EGamePlayer mpiecesCamp { get; protected set; }
    //棋子种类 默认为叶
    public EMode mPiecesMode { get; protected set; }
    //棋子状态 默认为不消除 在满足条件时改为true，棋子被消除
    public bool isRemove = false;
    //获取脚本所负载的棋子
    public GameObject pieceObj = null;
    // Start is called before the first frame update
    void Start()
    {
       pieceObj = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    virtual public bool piecesRemove() { return false; }
    public enum EMode
    {
        ROOT = 0,
        STEM = 1,
        LEAF = 2
    }
}
