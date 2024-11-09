using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M : MonoBehaviour
{
    
    GameObject originPiecesStem = null;
    GameObject originPiecesRoot = null;
    GameObject originPiecesLeaf = null;
    GameObject pieces = null;
    // Start is called before the first frame update
    void Start()
    {
       originPiecesLeaf =  Resources.Load<GameObject>("prefabs/Leaf");
       originPiecesStem =  Resources.Load<GameObject>("prefabs/Root");
       originPiecesRoot =  Resources.Load<GameObject>("prefabs/Stem");
        print(Input.mousePosition);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            PutPieces(originPiecesStem);
        }
    }
    void PutPieces(GameObject piecesMode) {
        if (piecesMode != null)
        { 
         pieces =  Instantiate(piecesMode);
            
            pieces.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
            pieces = null;
        }
    }
}
