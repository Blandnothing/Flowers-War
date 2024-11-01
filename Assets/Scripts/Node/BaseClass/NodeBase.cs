using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeBase : MonoBehaviour
{
    /// <summary>
    /// ���ӱ�����ʱ�Ļص�����
    /// </summary>
    public abstract void OnPlace();
    /// <summary>
    /// �ж������Ƿ�ɱ�����
    /// </summary>
    public abstract void CheckPlaceable();
}
