using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility
{
    virtual public IEnumerator Apply(PlayerController controller) {Debug.Log("Na"); yield break; }
}
