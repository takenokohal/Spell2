using UnityEngine;

public class NullPo : MonoBehaviour
{
    private NullPo _nullPo;

    private int i;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(_nullPo.i);
    }
}
