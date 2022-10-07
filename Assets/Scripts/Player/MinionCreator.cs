using UnityEngine;

public class MinionCreator : MonoBehaviour
{
    [SerializeField] GameObject GameObject_Minion;
    [SerializeField] Transform Transform_Minon_SpawnPoint;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameObject.Find("Minion(Clone)") == null)
        {
            Instantiate(GameObject_Minion, Transform_Minon_SpawnPoint.position, Quaternion.identity);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Destroy(GameObject.Find("Minion(Clone)"));
        }
    }
}
