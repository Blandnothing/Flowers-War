
//鼠标相关操作，决定棋子放置的位置以及种类
//起名字是个体力活  2024/11/6

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{   
    //存储鼠标检测阶段拿到的格子对象
    CellBehavior currentCell ;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  if (GameManager.Instance.gameState == GameManager.EGameState.Thinking)
        {
            MouseDetect();
           GameManager.Instance.currentPiece = MouseInput();
        }
    }
    //决定鼠标的点击事件 左键是叶 右键是根 中键是茎
    private GameObject MouseInput()
    {
        if (currentCell != null)
        {  
            if (Input.GetMouseButtonDown(0))
            {
                currentCell.OnSelected3();
                GameManager.Instance.gameStateChange(GameManager.EGameState.Clearing);
            }
            if (Input.GetMouseButtonDown(2))
            {
                currentCell.OnSelected2();
                GameManager.Instance.gameStateChange(GameManager.EGameState.Clearing);
            }
            if (Input.GetMouseButtonDown(1))
            {
                currentCell.OnSelected1();
                GameManager.Instance.gameStateChange(GameManager.EGameState.Clearing);
            }
           
        }

        
        return currentCell.thisPieces;
        
    }

    //鼠标检测，获取格子对象
    private void MouseDetect()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInof;
        bool hasDetectCell = false;
        if (Physics.Raycast(mouseRay, out hitInof))
        {
            
            CellBehavior cellBehavior = hitInof.transform.GetComponent<CellBehavior>();
            if (cellBehavior != null)
            {
                currentCell = cellBehavior;
                print(currentCell.name);
                cellBehavior.PreSeleceted();
                hasDetectCell = true;

            }
        }

        //在鼠标未检测到格子时，将currentCell置空
        if (!hasDetectCell)
        {
            if (currentCell != null)
            {
                currentCell = null;
            }
        }


    }
}
