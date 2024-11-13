using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesRoot : pieces
{
    // Start is called before the first frame update
    private void Awake()
    {
        mPiecesMode = EMode.ROOT;
        mpiecesCamp = GameManager.EGamePlayer.Red;
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
            print(mpiecesCamp);
        }
    }
}
