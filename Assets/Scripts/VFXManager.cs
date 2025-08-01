using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField]
    private GameObject doubleRingMarker;
    public GameObject DoubleRingMarker { get { return doubleRingMarker; } }
    [SerializeField]
    private GameObject[] magicVFX;
    public GameObject[] MagicVFX { get { return magicVFX; } }
    [SerializeField]
    private MagicData[] magicDatas;
    public MagicData[] MagicDatas { get { return magicDatas; }}
    public static VFXManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMagic(int id, Vector3 posA, float time)
    {
        //Load Magic
        if (MagicVFX[id] == null)
            return;

        GameObject objLoad = Instantiate(magicVFX[id], posA, Quaternion.identity);
        Destroy(objLoad, time);
    }

    public void ShootMagic(int id, Vector3 posA, Vector3 posB, float time)
    {
        //Shoot Magic
        if (MagicVFX[id] == null)
            return;

        GameObject objShoot = Instantiate(magicVFX[id], posA, Quaternion.identity);
        objShoot.transform.position = Vector3.LerpUnclamped(posA, posB, time);
        Destroy(objShoot, time);
    }
}
