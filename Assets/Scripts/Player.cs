using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterSwitcher _switcher;

    private void Start()
    {
        _switcher = GetComponent<CharacterSwitcher>();
    }

    public void DispatchHit(Vector3 towards)
    {
        int character = _switcher.GetCharacterIndex();
        transform.GetChild(character).GetComponent<HitProcessor>().ProcessHit(towards);
    }
}
