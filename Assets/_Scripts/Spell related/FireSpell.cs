using UnityEngine;

public class FireSpell : SpellBase
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 20f;

    public override void Cast(Transform castPoint)
    {
        //var proj = Instantiate(projectilePrefab, castPoint.position, castPoint.rotation);
        ////proj.GetComponent<Rigidbody>().velocity = castPoint.forward * speed;

        //if (data.vfxPrefab)
        //    Instantiate(data.vfxPrefab, castPoint.position, castPoint.rotation);

        //if (data.castSfx)
        //    AudioSource.PlayClipAtPoint(data.castSfx, castPoint.position);
        Debug.Log("fireBall casted");
    }
}
