using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ItemCollectSystem : MonoBehaviour
{
    #region Variable
    [SerializeField] Camera cam;
    [SerializeField] bool isFull = false;
    [SerializeField] Transform itemHolderPos;
    private GameObject tempObj;
    #endregion
    
    private void Update()
    {
        ItemCollect();
    }

    void ItemCollect()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.gameObject.CompareTag("Item") && !isFull)
                {
                    tempObj = hit.transform.gameObject;
                    Rigidbody rb = tempObj.GetComponent<Rigidbody>();

                    tempObj.transform.SetParent(itemHolderPos);
                    tempObj.transform.localPosition = Vector3.zero;
                    tempObj.transform.DOLocalRotateQuaternion(Quaternion.identity, 0.5f);

                    rb.isKinematic = true;
                    rb.useGravity = false;
                    isFull = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isFull)
            {
                Rigidbody rb = tempObj.GetComponent<Rigidbody>();
                Drop(tempObj, rb);
            }
        }
    }

    void Drop(GameObject obj, Rigidbody rb)
    {
        itemHolderPos.DetachChildren();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(Camera.main.transform.forward * 200);
        isFull = false;
    }

}
