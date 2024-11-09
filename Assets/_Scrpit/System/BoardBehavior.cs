
//�������̣���ȡΪ���̵ĸ��ӱ�Ų���¼���
//�������Ǹ�������  2024/11/6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehavior : MonoBehaviour
{   
    

    public static BoardBehavior Instance;

    //���̸��ӵĿ��
    private int mCellWidth = Const.CellWidth ;
    private int mCellHeight = Const.CellHeight ;

    //������ײ���ԭ��
    GameObject originCell = null;

    //������ײ���ʵ���ͽű����б�
    List<GameObject> cellList = new List<GameObject>();
    List<CellBehavior> CellBehaviors = new List<CellBehavior>();

    //�ж���������ʱ���м����
    int next =-1;
    int last =-1;
    int current =-1;

    // Start is called before the first frame update
    void Start()
    {   
        

        Instance = this;
        originCell = Resources.Load<GameObject>("prefabs/Cell");
        
        GameObject cell = null;

        for (int i = 0; i < 8; i++) {
            for (int n = 0; n < 8 ; n++){
                //�������ӵ���ײ�岢������
                cell = Instantiate(originCell);
                cellList.Add(cell);
                CellBehaviors.Add(cell.GetComponent<CellBehavior>());
                cellList[i*8+n].transform.position = originCell.transform.position+new Vector3(n*mCellWidth,i*mCellHeight,0);
                cellList[i * 8 + n].name = "cube" + (i * 8 + n);
                //�������ӵ���ײ�岢������

                //Ϊ���ӽű��趨���ӵı��
                CellBehaviors[i * 8 + n].index = i * 8 + n;
        }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InspectPieces() { 
        for(int r = 0; r < 8 ; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                
                current = r * 8 + c;
                if (CellBehaviors[current].thisPieces != null)
                {
                    if (current > 0) { last = current - 1; }
                    if (current < 63) { next = current + 1; }
                    if (CellBehaviors[last] != null && CellBehaviors[next] != null) {
                    
                    }
                    
                }
            }
        }
    
    }
}
