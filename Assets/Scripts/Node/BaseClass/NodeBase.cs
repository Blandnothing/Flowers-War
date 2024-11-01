using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeBase : MonoBehaviour
{
    /// <summary>
    /// 棋子被放置时的回调函数
    /// </summary>
    public abstract void OnPlace();
    /// <summary>
    /// 判断棋子是否可被放置
    /// </summary>
    public abstract void CheckPlaceable();
}
