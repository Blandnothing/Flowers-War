
//控制格子对象的脚本，创建棋子并储存棋子
//起名字是个体力活 2024/11/6

using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellBehavior : MonoBehaviour
{   
    //预设的变量
    Vector3 stemSub = new Vector3(0, 0.25f, 0);
    //预设的变量

    //格子的编号
    public int index = 0;

    //格子挂载的outLine组件
    Outline selfLine;

    //现在位于格子上的棋子
    public GameObject thisPieces = null;

    // Start is called before the first frame update
    void Start()
    {   
        selfLine = GetComponent<Outline>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //创建相应棋子的方法
    //根
   public void OnSelected1() {
        if (this.thisPieces == null)
        {   if (GameManager.Instance.player == GameManager.EGamePlayer.Red && !GameManager.Instance.redRootExisting)
            {
                thisPieces = Instantiate(Const.Instance.preRoot);
                thisPieces.transform.position = this.transform.position;
                GameManager.Instance.redRootExisting = true;
            }
            else if(GameManager.Instance.player == GameManager.EGamePlayer.Blue&& !GameManager.Instance.blueRootExisting)
            {
                thisPieces = Instantiate(Const.Instance.preRootB);
                thisPieces.transform.position = this.transform.position;
                GameManager.Instance.blueRootExisting = true;
            }
        }
        else { 
        
        }
     
    }
    //茎
    public void OnSelected2()
    {
        if (this.thisPieces == null)
        {
            if (GameManager.Instance.player == GameManager.EGamePlayer.Red && !GameManager.Instance.redStemExisting)
            {
                thisPieces = Instantiate(Const.Instance.preStem);
                thisPieces.transform.position = this.transform.position - stemSub;
                GameManager.Instance.redStemExisting = true;
            }
            else if (GameManager.Instance.player == GameManager.EGamePlayer.Blue && !GameManager.Instance.blueStemExisting) {
                thisPieces = Instantiate(Const.Instance.preStemB);
                thisPieces.transform.position = this.transform.position + stemSub;
                GameManager.Instance.blueStemExisting = true;
            }
        }
        else
        {

        }
  
    }
    //叶
    public void OnSelected3() {
        if (this.thisPieces == null)
        {
            if (GameManager.Instance.player == GameManager.EGamePlayer.Red)
            {
                thisPieces = Instantiate(Const.Instance.preLeaf);
                thisPieces.transform.position = this.transform.position;
            }
          else if(GameManager.Instance.player == GameManager.EGamePlayer.Blue) {
                thisPieces = Instantiate(Const.Instance.preLeafB);
                thisPieces.transform.position = this.transform.position;
            }
        }
        else
        {

        }
       
    }
    //创建相应棋子的方法
   
   public void PreSeleceted() {

        
        
    }

   
}
