using UnityEngine;

public abstract class SpellBase : MonoBehaviour
{
    public SpellData data;

    public abstract void Cast(Transform castPoint);
}
