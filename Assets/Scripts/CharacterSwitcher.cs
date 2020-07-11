using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{

    private PlayerController _controller;
    private PlayerAnimator _animator;

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
        _controller = GetComponent<PlayerController>();
        _animator = GetComponent<PlayerAnimator>();
        ProcessSwitch();
        StartCoroutine(SwichLoop());
    }

    private IEnumerator SwichLoop()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(MIN_SWITCH_TIME, MAX_SWITCH_TIME));
            _animator.StartMutation();
            yield return new WaitForSecondsRealtime(.4f);

            if (!characterLock)
            {
                if (character == CHARACTERS.TINKY)
                {
                    _controller.UnlockMove();
                }
                else if (character == CHARACTERS.LALA)
                {
                    _controller.UnlockMove();
                }
                character = (CHARACTERS)GetNewCharacter();
                _animator.GOTO((int)character);
                _controller.EndDash();
                if (character == CHARACTERS.LALA)
                {
                    _controller.LockMove();
                }
                ProcessSwitch();
            }

        }

    }

    private int GetNewCharacter()
    {
        int newChara = Random.Range(0, 4);
        while (newChara == (int)character)
        {
            newChara = Random.Range(0, 4);
        }
        return newChara;
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
