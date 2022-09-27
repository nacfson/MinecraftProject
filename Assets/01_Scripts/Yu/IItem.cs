using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    void RightClickInteraction();

    void LeftClickInteraction();
    public ItemData ItemData
	{
		get;
		set;
	}
}
