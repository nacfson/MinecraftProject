using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButton
{
    /// <summary>
    /// 선택됐을 때
    /// </summary>
    void Selected();

    /// <summary>
    /// 선택되지 않았을 때
    /// </summary>
    void NoneSelected();
}
