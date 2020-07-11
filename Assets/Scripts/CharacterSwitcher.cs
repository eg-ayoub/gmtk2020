using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    const float MIN_SWITCH_TIME = .5f;
    const float MAX_SWITCH_TIME = 6f;

    public enum CHARACTERS
    {
        TINKY = 0,
        JIPSY,
        LALA,
        PO
    }

    public CHARACTERS character = CHARACTERS.TINKY;

    [SerializeField]
    public bool characterLock;

    private void Start()
    {
        ProcessSwitch();
        StartCoroutine(SwichLoop());
    }

    private IEnumerator SwichLoop()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(MIN_SWITCH_TIME, MAX_SWITCH_TIME));

            if (!characterLock)
            {
                character = (CHARACTERS)Random.Range(0, 4);
                ProcessSwitch();
            }

        }

    }

    private void ProcessSwitch()
    {
        for (int _c = 0; _c < 4; _c++)
        {
            if (_c == (int)character)
            {
                transform.GetChild(_c).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(_c).gameObject.SetActive(false);
            }
        }
    }

    public int GetCharacterIndex()
    {
        return (int)character;
    }

}
