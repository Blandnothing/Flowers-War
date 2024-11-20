using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesStemB : pieces
{
    // Start is called before the first frame update
    private void Awake()
    {
        mPiecesMode = EMode.STEM;
        mpiecesCamp = GameManager.EGamePlayer.Blue;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void piecesRemove()
    {
        if (isRemove)
        {
            GameObject.Destroy(this);
            GameObject.Destroy(pieceObj);
            GameManager.Instance.blueStemExisting = false;
            GameManager.Instance.blueStemCool = 1;
        }
    }
}
