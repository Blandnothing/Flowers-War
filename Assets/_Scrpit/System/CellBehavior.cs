
//���Ƹ��Ӷ���Ľű����������Ӳ���������
//�������Ǹ������� 2024/11/6

using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellBehavior : MonoBehaviour
{   
    //Ԥ��ı���
    Vector3 stemSub = new Vector3(0, 0.25f, 0);
    //Ԥ��ı���

    //���ӵı��
    public int index = 0;

    //���ӹ��ص�outLine���
    Outline selfLine;

    //����λ�ڸ����ϵ�����
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
    //������Ӧ���ӵķ���
    //��
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
    //��
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
    //Ҷ
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
    //������Ӧ���ӵķ���
   
   public void PreSeleceted() {

        
        
    }

   
}
