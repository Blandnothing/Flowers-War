
//控制格子对象的脚本，创建棋子并储存棋子,以及棋子上负载的脚本
//起名字是个体力活 2024/11/6

using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellBehavior : MonoBehaviour
{
    #region 程序所用的各种变量与属性
    //该格子是否为核心区域以及为那个阵营的核心区域
    public GameManager.EGamePlayer cellCamp = GameManager.EGamePlayer.Cell;
    public bool coreCell = false;

    //预设的变量,三角形中心的偏移量
    Vector3 stemSub = new Vector3(0, 0.25f, 0);

    //格子的编号
    public int index = 0;

    //格子挂载的outLine组件
    Outline selfLine;

    //现在位于格子上的棋子
    public GameObject thisPieces = null;
    //棋子上挂载的脚本
    public pieces thisScript = null;

    //是否可以下棋
    public bool canDorp = false;
    #endregion
    
    void Start()
    {   
        selfLine = GetComponent<Outline>();
    }

    void Update()
    {
        
    }

    #region 与鼠标点击生成相关方法
    //根
    public void OnSelected1()
    {
        if (this.thisPieces == null)
        {
            if (GameManager.Instance.player == GameManager.EGamePlayer.Red && !GameManager.Instance.redRootExisting && GameManager.Instance.redRootCool == 0)
            {
                CreatePiecesRedRoot();
                if (GameManager.Instance.redStemCool > 0) { GameManager.Instance.redStemCool--; }
                GameManager.Instance.redRootExisting = true;
            }
            else if (GameManager.Instance.player == GameManager.EGamePlayer.Blue && !GameManager.Instance.blueRootExisting && GameManager.Instance.blueRootCool == 0)
            {
                CreatePiecesBlueRoot();
                if (GameManager.Instance.blueStemCool > 0) { GameManager.Instance.blueStemCool--; }
                GameManager.Instance.blueRootExisting = true;
            }
        }
        else
        {

        }

    }
    //茎
    public void OnSelected2()
    {
        if (this.thisPieces == null)
        {
            if (GameManager.Instance.player == GameManager.EGamePlayer.Red && !GameManager.Instance.redStemExisting && GameManager.Instance.redStemCool == 0)
            {
                CreatePiecesRedStem();
                if (GameManager.Instance.redRootCool > 0) { GameManager.Instance.redRootCool--; }
                GameManager.Instance.redStemExisting = true;

            }
            else if (GameManager.Instance.player == GameManager.EGamePlayer.Blue && !GameManager.Instance.blueStemExisting && GameManager.Instance.blueStemCool == 0)
            {
                CreatePiecesBlueStem();
                if (GameManager.Instance.blueRootCool > 0) { GameManager.Instance.blueRootCool--; }
                GameManager.Instance.blueStemExisting = true;

            }
        }
        else
        {

        }

    }
    //叶
    public void OnSelected3()
    {
        if (this.thisPieces == null)
        {
            if (GameManager.Instance.player == GameManager.EGamePlayer.Red)
            {
                CreatePiecesRed();
                if (GameManager.Instance.redRootCool > 0) { GameManager.Instance.redRootCool--; }
                if (GameManager.Instance.redStemCool > 0) { GameManager.Instance.redStemCool--; }
            }
            else if (GameManager.Instance.player == GameManager.EGamePlayer.Blue)
            {
                CreatePiecesBlue();
                if (GameManager.Instance.blueRootCool > 0) { GameManager.Instance.blueRootCool--; }
                if (GameManager.Instance.blueStemCool > 0) { GameManager.Instance.blueStemCool--; }
            }
        }
        else
        {

        }

    }
    #endregion

    #region 创建相应棋子的方法
    //叶red
    public void CreatePiecesRed() {
        thisPieces = Instantiate(Const.Instance.preLeaf);
        thisPieces.transform.position = this.transform.position;
        thisScript = thisPieces.GetComponent<PiecesLeaf>();
    }
    //叶blue
    public void CreatePiecesBlue() {
        thisPieces = Instantiate(Const.Instance.preLeafB);
        thisPieces.transform.position = this.transform.position;
        thisScript = thisPieces.GetComponent<PiecesLeafB>();
    }
    //根red
    public void CreatePiecesRedRoot() {
        thisPieces = Instantiate(Const.Instance.preRoot);
        thisPieces.transform.position = this.transform.position;
        thisScript = thisPieces.GetComponent<PiecesRoot>();
    }
    
    //根blue
    public void CreatePiecesBlueRoot() {
        thisPieces = Instantiate(Const.Instance.preRootB);
        thisPieces.transform.position = this.transform.position;
        thisScript = thisPieces.GetComponent<PiecesRootB>();
    }
    //茎red
    public void CreatePiecesRedStem() {
        thisPieces = Instantiate(Const.Instance.preStem);
        thisPieces.transform.position = this.transform.position - stemSub;
        thisScript = thisPieces.GetComponent<PiecesStem>();
    }
    //茎blue
    public void CreatePiecesBlueStem() {
        thisPieces = Instantiate(Const.Instance.preStemB);
        thisPieces.transform.position = this.transform.position + stemSub;
        thisScript = thisPieces.GetComponent<PiecesStemB>();
    }
    #endregion

    public void PreSeleceted() {

        
        
    }

   
}
