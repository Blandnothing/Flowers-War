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
    //棋子特殊位置,不可消除与推动 默认为false 
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
