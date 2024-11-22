using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesRootB : pieces
{
    // Start is called before the first frame update
    private void Awake()
    {
        mPiecesMode = EMode.ROOT;
        mpiecesCamp = GameManager.EGamePlayer.Blue;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool piecesRemove()
    {
        if (isRemove)
        {
            GameObject.Destroy(this);
            GameObject.Destroy(pieceObj);
            GameManager.Instance.blueRootExisting = false;
            GameManager.Instance.blueRootCool = 1;
            return true;
        }
        return false;
    }
}
