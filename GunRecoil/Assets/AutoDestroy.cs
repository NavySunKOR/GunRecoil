using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyThis", 3f);
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
