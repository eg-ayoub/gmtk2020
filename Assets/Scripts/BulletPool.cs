using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    public GameObject bulletPrefab;

    const int START_BULLET_COUNT = 20;

    private List<GameObject> _bullets;

    private bool _ready = false;

    public void Init()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("no bullet prefab");
            return;
        }

        _bullets = new List<GameObject>(START_BULLET_COUNT);
        for (int _b = 0; _b < START_BULLET_COUNT; _b++)
        {
            AddBullet();
        }

        _ready = true;

    }

    public GameObject GetBullet(Transform parent)
    {
        if (!_ready)
        {
            Debug.LogError("pool not ready");
            return null;
        }

        for (int _b = 0; _b < _bullets.Count; _b++)
        {
            GameObject bullet = _bullets[_b];
            if (!bullet.activeSelf)
            {
                bullet.transform.SetParent(parent);
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = AddBullet();
        newBullet.transform.SetParent(parent);
        newBullet.transform.position = transform.position;
        newBullet.SetActive(true);
        return newBullet;

    }

    public void Release(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    private GameObject AddBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        bullet.transform.SetParent(transform);
        bullet.SetActive(false);

        _bullets.Add(bullet);

        return bullet;
    }


}
