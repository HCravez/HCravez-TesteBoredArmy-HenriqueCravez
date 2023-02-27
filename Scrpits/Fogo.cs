using UnityEngine;

public class Fogo : MonoBehaviour {
    public Animator animator;
 
    // Use t$$anonymous$$s for initialization
    void Start () {
        Destroy (gameObject, animator.GetCurrentAnimatorStateInfo(0).length); 
    }
}