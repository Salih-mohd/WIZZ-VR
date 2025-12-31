using UnityEngine;

public class FireSpell : SpellBase
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 5f;
    float spawnOffset = 0.05f;

    public override void Cast(Transform castPoint)
    {
        //var proj = Instantiate(projectilePrefab, castPoint.position, castPoint.rotation);
        ////proj.GetComponent<Rigidbody>().velocity = castPoint.forward * speed;

        //if (data.vfxPrefab)
        //    Instantiate(data.vfxPrefab, castPoint.position, castPoint.rotation);

        //if (data.castSfx)
        //    AudioSource.PlayClipAtPoint(data.castSfx, castPoint.position);
        Vector3 spawnPos = castPoint.position + castPoint.forward * spawnOffset;

        var obj=Instantiate(projectilePrefab, spawnPos, castPoint.rotation);
        obj.GetComponent<Rigidbody>().AddForce(castPoint.forward*speed,ForceMode.Impulse);



        Debug.Log("go casted");
    }
}
