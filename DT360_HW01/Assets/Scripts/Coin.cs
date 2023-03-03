using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject cs;
    private void Start()
    {
        cs = GameObject.Find("GameManager");
        StartCoroutine(FloatAnim());
        //cs.GetComponent<CoinSpawner>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cs.GetComponent<CoinSpawner>().CoinCollect();
            Destroy(gameObject);
        }
    }

    private IEnumerator FloatAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
} 
     