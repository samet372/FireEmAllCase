using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPooling : MonoBehaviour
{
    Queue<GameObject> pooledPlayers;

    public GameObject _playerPrefabGirl;
    public GameObject _playerPrefabMen;

    [SerializeField] int _poolSize;

    private void Awake()  //basic object pooling system
    {
        pooledPlayers = new Queue<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject girl = Instantiate(_playerPrefabGirl);
            GameObject men = Instantiate(_playerPrefabMen);

            girl.SetActive(false);
            men.SetActive(false);

            pooledPlayers.Enqueue(girl);
            pooledPlayers.Enqueue(men);
        }
    }

    public GameObject GetPoolPlayer()
    {
        GameObject obj = pooledPlayers.Dequeue();
        obj.SetActive(true);

        pooledPlayers.Enqueue(obj);
        return obj;
    }
}
