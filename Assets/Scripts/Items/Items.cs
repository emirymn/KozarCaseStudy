using DG.Tweening;
using UnityEngine;

public class Items : MonoBehaviour
{
    public ItemType itemType;
    public enum ItemType { head, glasses, ear, shoes }
    public bool trueItem;
    Vector3 firstPos;

    private void Awake()
    {
        firstPos = transform.position;
    }

    public void GoBackFirstPosition()
    {
        transform.SetParent(GameObject.Find("------Collectables").transform);
        transform.DOKill(false);
        transform.DOMove(firstPos,1f);
        transform.DORotate(Vector3.zero, 0.5f);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
