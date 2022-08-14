using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    public void Died()
    {
        Destroy(gameObject);
    }
}
