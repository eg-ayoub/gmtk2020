using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobPool : MonoBehaviour
{
    [SerializeField]
    public GameObject blobPrefab;

    const int START_BLOB_COUNT = 5;

    private List<GameObject> _blobs;

    private bool _ready = false;

    public void Init()
    {
        if (blobPrefab == null)
        {
            Debug.LogError("no blob prefab");
            return;
        }

        _blobs = new List<GameObject>(START_BLOB_COUNT);
        for (int _b = 0; _b < START_BLOB_COUNT; _b++)
        {
            AddBlob();
        }

        _ready = true;

    }

    public GameObject GetBlob(Transform parent)
    {
        if (!_ready)
        {
            Debug.LogError("pool not ready");
            return null;
        }

        for (int _b = 0; _b < _blobs.Count; _b++)
        {
            GameObject blob = _blobs[_b];
            if (!blob.activeSelf)
            {
                blob.transform.SetParent(parent);
                blob.transform.position = transform.position;
                blob.SetActive(true);
                return blob;
            }
        }

        GameObject newBlob = AddBlob();
        newBlob.transform.SetParent(parent);
        newBlob.transform.position = transform.position;
        newBlob.SetActive(true);
        return newBlob;
    }

    public void Release(GameObject blob)
    {
        blob.SetActive(false);
    }

    private GameObject AddBlob()
    {
        GameObject blob = Instantiate(blobPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        blob.transform.SetParent(transform);
        blob.SetActive(false);

        _blobs.Add(blob);

        return blob;
    }

}
