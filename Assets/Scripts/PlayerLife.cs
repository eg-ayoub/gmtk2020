using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    int hp = 6;

    const float INVULN_COOLDOWN = .5f;
    private float lastHit;

    private bool vulnerable = true;

    private void Start()
    {
        lastHit = Time.time;
        FindObjectOfType<HPDisplay>().SetHP(hp);
    }

    public void Heal()
    {
        hp = Mathf.Clamp(hp + 2, 0, 6);
        FindObjectOfType<HPDisplay>().SetHP(hp);
    }

    public void TakeDamage()
    {
        if (Time.time - lastHit >= INVULN_COOLDOWN && vulnerable)
        {
            FindObjectOfType<CameraShaker>().Shake();
            lastHit = Time.time;
            Debug.Log("ouch");
            hp -= 1;
            transform.parent.GetComponent<PlayerAnimator>().Hit();
            if (hp <= 0)
            {
                transform.parent.GetComponent<PlayerAnimator>().Die();
                transform.parent.GetComponentInChildren<PlayerAudio>().PlayerDeath();
                StartCoroutine(ResetAfterAnimation());
            }
        }
        FindObjectOfType<HPDisplay>().SetHP(hp);
    }

    IEnumerator ResetAfterAnimation()
    {
        yield return new WaitForSecondsRealtime(1f);
        ResetLevel();
    }

    public void ResetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MakeVulnerable()
    {
        vulnerable = true;
    }

    public void MakeInvulnerable()
    {
        vulnerable = false;
    }
}
