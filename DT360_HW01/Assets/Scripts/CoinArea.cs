using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinArea : MonoBehaviour
{
    public bool enter;
    private void OnTriggerEnter(Collider other)
    {
        enter = true;
    }
    private void OnTriggerExit(Collider other)
    {
        enter = false;
    }
}
