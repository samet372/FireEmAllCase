using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] PlayerPooling _playerPooling = null;

    [SerializeField] Transform _playerRespawnPoint;

    private void Start()
    {
        PlayerSpawner();
    }

    public void PlayerSpawner()
    {
        var players = _playerPooling.GetPoolPlayer();
        players.transform.position = _playerRespawnPoint.position;
    }

}
