using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBlock : MonoBehaviour
{
    [SerializeField] Material[] breakingTexture;

    public void BreakingBlockTexturing(float breakingRate)
    {
        Material originMaterial = GetComponent<MeshRenderer>().materials[0];

        if(breakingRate >= 0 && breakingRate <= 0.1)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[9] , originMaterial};
        }
        else if (breakingRate >= 0.1 && breakingRate <= 0.2)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[8], originMaterial };
        }
        else if (breakingRate >= 0.2 && breakingRate <= 0.3)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[7], originMaterial };
        }
        else if (breakingRate >= 0.3 && breakingRate <= 0.4)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[6], originMaterial };
        }
        else if (breakingRate >= 0.4 && breakingRate <= 0.5)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[5], originMaterial };
        }
        else if (breakingRate >= 0.5 && breakingRate <= 0.6)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[4], originMaterial };
        }
        else if (breakingRate >= 0.6 && breakingRate <= 0.7)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[3], originMaterial };
        }
        else if (breakingRate >= 0.7 && breakingRate <= 0.8)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[2], originMaterial };
        }
        else if (breakingRate >= 0.8 && breakingRate <= 0.9)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[1], originMaterial };
        }
        else if (breakingRate >= 0.9 && breakingRate <= 1)
        {
            GetComponent<MeshRenderer>().materials = new Material[2] { breakingTexture[0], originMaterial };
        }
    }
}

