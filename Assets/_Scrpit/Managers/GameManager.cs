
//��¼��Ϸ״̬���ı���Ϸ״̬
//�������Ǹ�������  2024/11/6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   public static GameManager Instance;
    //���巽  0Ϊ�췽 1Ϊ����
    public EGamePlayer player = EGamePlayer.Blue;

    //��ǰ���µ�����
   public GameObject currentPiece = null;

    //�������ĸ����Ƿ����
    public bool redRootExisting = false;
    public bool redStemExisting = false;
    public bool blueRootExisting = false;
    public bool blueStemExisting = false;

    public EGameState gameState { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        gameStateChange(EGameState.Starting);
        Instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per fram
    void Update()
    {
        switch (gameState) {
            case EGameState.Starting:


                gameStateChange(EGameState.Thinking);
                break;
            case EGameState.Thinking:


                break;
            case EGameState.Clearing:
                System.Threading.Thread.Sleep(200);
                if (currentPiece != null)
                {
                    currentPiece = null;
                    gameStateChange(EGameState.Switching);

                }
                else { gameStateChange(EGameState.Thinking); 
                }
                break;
            case EGameState.Switching:
                if (player == EGamePlayer.Blue)
                { player = EGamePlayer.Red; }
                else if (player == EGamePlayer.Red)
                { player = EGamePlayer.Blue; }
                gameStateChange(EGameState.Thinking);
                    break;
            case EGameState.Ending:
                break;
        }
    }

    
    public void gameStateChange(EGameState state) { 
       gameState = state;
    }

    //��Ϸ�ĸ���״̬
    public enum EGameState { 
       Starting = 0, //��Ϸ��ʼ��׼���׶�
       Thinking = 1, //��������˼���׶�
       Clearing = 2, //�������֮�󣬽������̵ı仯
       Switching = 3, //�任���巽
       Ending = 4     //��Ϸ����
    }
    public enum EGamePlayer { 
    Red = 0 ,
    Blue = 1
    }
}
