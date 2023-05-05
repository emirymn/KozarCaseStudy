using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TableScript : MonoBehaviour
{
    [SerializeField] Items.ItemType itemType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (itemType == other.GetComponent<Items>().itemType)
            {
                other.transform.SetParent(transform);
                other.transform.DOLocalMove(Vector3.zero, 0.5f);
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<Rigidbody>().useGravity = false;

                if (other.GetComponent<Items>().trueItem)
                    GameManager.instance.UpdatePoint(5);
                else
                    GameManager.instance.UpdatePoint(-5);

                switch (itemType)
                {
                    case Items.ItemType.head:
                        {
                            other.transform.DOLocalRotate(new Vector3(0, 180, 0), 0.5f);
                            break;
                        }
                    case Items.ItemType.shoes:
                        {
                            other.transform.DOLocalRotate(new Vector3(0, 180, 0), 0.5f);
                            break;
                        }
                    default:
                        {
                            other.transform.DOLocalRotateQuaternion(Quaternion.identity, 0.5f);
                            break;
                        }
                }

                if (transform.childCount == 2)
                {
                    transform.GetChild(0).GetComponent<Items>().GoBackFirstPosition();
                }
            }
            else
                StartCoroutine(GoBackFirstPos(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (itemType == other.GetComponent<Items>().itemType)
            {
                if (other.GetComponent<Items>().trueItem)
                    GameManager.instance.UpdatePoint(-5);
                else
                    GameManager.instance.UpdatePoint(5);
            }
        }
    }

    IEnumerator GoBackFirstPos(GameObject other)
    {
        yield return new WaitForSeconds(1f);
        other.GetComponent<Items>().GoBackFirstPosition();
    }
}
