using UnityEngine;

public class PopCat : MonoBehaviour
{
    Animator ani_;

    private void Start()
    {
        ani_ = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ani_.SetTrigger("Pop");
    }
}
