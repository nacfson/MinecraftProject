using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBlock : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(transform.position, transform.right);
		Gizmos.color = Color.blue;
		Gizmos.DrawRay(transform.position, -transform.right);
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(transform.position, transform.up);
		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position, -transform.up);
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(transform.position, transform.forward);
		Gizmos.color = new Color(1, 0, 1);
		Gizmos.DrawRay(transform.position, -transform.forward);
	}
}
