using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private CollectibleSpawner _spawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHealth") || other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerLife>().Heal();
            if (_spawner != null)
            {
                _spawner.Release();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetSpawner(CollectibleSpawner spawner)
    {
        _spawner = spawner;
    }
}
