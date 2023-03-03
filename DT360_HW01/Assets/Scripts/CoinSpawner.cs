using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    public TextMeshProUGUI currentCoinText;
    public TextMeshProUGUI happy;
    public int currentCoin;
    public GameObject coin;
    private Vector3 posCoin;
    private float x;
    private float z;
    private int time = 10;


    private void Start()
    {
        happy.enabled = false;
        currentCoinText.text = currentCoin.ToString();
        SpawnCoin();
    }
    private void Update()
    {
        currentCoinText.text = "Coin Obtained: " + currentCoin.ToString();
    }
    public int GetCurCoin()
    {
        return currentCoin;
    }
    public void SpawnCoin()
    {
        Debug.Log("Spawning Coin");
        time = 10;
        StartCoroutine(SpawnCoins());
    }
    public void CoinCollect()
    {
        currentCoin++;
    }
    public void happyTrigger()
    {
        StartCoroutine(Happy());
    }
    private IEnumerator Happy()
    {
        happy.enabled = true;
        yield return new WaitForSeconds(3.0f);
        happy.enabled = false;
    }
    private IEnumerator SpawnCoins()
    {
        while (time > 0)
        {
            time = time - 1;
            x = Random.Range(-9.0f, 9.0f);
            z = Random.Range(-9.0f, 9.0f);
            posCoin = new Vector3(x, 1.0f, z);
            Instantiate(coin, posCoin, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
