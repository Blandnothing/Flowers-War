
//�����ز������������ӷ��õ�λ���Լ�����
//�������Ǹ�������  2024/11/6

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{   
    //�洢�����׶��õ��ĸ��Ӷ���
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
    //�������ĵ���¼� �����Ҷ �Ҽ��Ǹ� �м��Ǿ�
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

    //����⣬��ȡ���Ӷ���
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

        //�����δ��⵽����ʱ����currentCell�ÿ�
        if (!hasDetectCell)
        {
            if (currentCell != null)
            {
                currentCell = null;
            }
        }


    }
}
