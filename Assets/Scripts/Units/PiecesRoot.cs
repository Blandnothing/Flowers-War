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
    public override bool piecesRemove()
    {
        if (isRemove)
        {
            GameObject.Destroy(this);
            GameObject.Destroy(pieceObj);
            GameManager.Instance.redRootExisting = false;
            GameManager.Instance.redRootCool = 1;
            return true;
        }
        return false;
    }
}
