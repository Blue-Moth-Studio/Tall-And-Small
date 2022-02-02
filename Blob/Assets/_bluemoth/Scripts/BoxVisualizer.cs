using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
