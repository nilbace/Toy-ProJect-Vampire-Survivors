using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{

    [Header("AXE")]
    [SerializeField] GameObject Axe;
    [SerializeField] public int AxeLevel;
    [SerializeField] float AXEleveldelay;
    [SerializeField] float AXEcooltime;
    [Header("SPEAR")]
    [SerializeField] GameObject Spear;
    [SerializeField] public int SpearLevel;
    [SerializeField] float Spearleveldelay;
    [SerializeField] float Spearcooltime;
    

    void Start()
    {
        StartCoroutine(ThrowAXE());
        StartCoroutine(ThrowSPEAR());
    }

    IEnumerator ThrowAXE( )
    {
        while(AxeLevel > 0)
        {
            for(int i = 0; i < AxeLevel; i++)
            {   GameObject instance = Instantiate(Axe,
                                    transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
                yield return new WaitForSeconds(AXEleveldelay);
                Destroy(instance, 7f);
            }
        yield return new WaitForSeconds(AXEcooltime);

        }       
    }

    IEnumerator ThrowSPEAR( )
    {
        while(SpearLevel > 0)
        {
            for(int i = 0; i < SpearLevel; i++)
            {   GameObject instance = Instantiate(Spear,
                                    transform.position + new Vector3(transform.localScale.x, 0, 0),
                                     Quaternion.Euler(0, 0, -134));
                yield return new WaitForSeconds(Spearleveldelay);
                Destroy(instance, 5f);
            }
        yield return new WaitForSeconds(Spearcooltime);

        }       
    }
}
