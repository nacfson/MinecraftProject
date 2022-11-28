using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBlock : MonoBehaviour
{
    [SerializeField] Material[] breakingTexture;

    public void BreakingBlockTexturing(float breakingRate, Vector3 pos)
    {

        if (breakingRate >= 0 && breakingRate <= 0.1)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[9];
        }
        else if (breakingRate >= 0.1 && breakingRate <= 0.2)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[8];
        }
        else if (breakingRate >= 0.2 && breakingRate <= 0.3)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[7];
        }
        else if (breakingRate >= 0.3 && breakingRate <= 0.4)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[6];
        }
        else if (breakingRate >= 0.4 && breakingRate <= 0.5)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[5];
        }
        else if (breakingRate >= 0.5 && breakingRate <= 0.6)
        {
                gameObject.GetComponent<MeshRenderer>().material = breakingTexture[4];
        }
        else if (breakingRate >= 0.6 && breakingRate <= 0.7)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[3];
        }
        else if (breakingRate >= 0.7 && breakingRate <= 0.8)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[2];
        }
        else if (breakingRate >= 0.8 && breakingRate <= 0.9)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[1];
        }
        else if (breakingRate >= 0.9 && breakingRate <= 1)
        {
            gameObject.GetComponent<MeshRenderer>().material = breakingTexture[0];
        }
    }

    public void StopBreaking()
    {
        transform.position = new Vector3(99, 99, 99);
    }
}

