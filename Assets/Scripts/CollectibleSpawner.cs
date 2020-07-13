using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject collectiblePrefab;

    private GameObject _collectible;

    private void Start()
    {
        if (collectiblePrefab == null)
        {
            Debug.LogError("no collectible prefab");
            return;
        }

        Create();
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSecondsRealtime(120);
            while (_collectible.activeSelf)
            {
                yield return new WaitForSecondsRealtime(.1f);
            }
        }
    }

    private void Spawn()
    {
        _collectible.SetActive(true);
        _collectible.transform.SetParent(transform);
        _collectible.transform.position = transform.position;
        _collectible.SetActive(true);

        _collectible.GetComponent<Collectible>().SetSpawner(this);
    }

    public void Release()
    {
        _collectible.SetActive(false);
    }

    private void Create()
    {
        _collectible = Instantiate(collectiblePrefab, Vector3.zero, Quaternion.identity) as GameObject;

        _collectible.transform.SetParent(transform);
        _collectible.SetActive(false);
    }
}
