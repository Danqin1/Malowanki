using UnityEngine;
using UnityEngine.EventSystems;

public class CrayonAnimations : MonoBehaviour
{
    Animator animator;
    public  GameObject[] crayons = new GameObject[12];
    public void PlayCrayonAnimation(int CrayonNr)
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
        for (int i = 0; i < crayons.Length; i++)
        {
            if (crayons[i].name == name)
            {
                animator = crayons[i].GetComponent<Animator>();
            }
        }
        if (animator)
            {
                animator.SetInteger("CrayonNr", CrayonNr);
                animator.Play("AnimateCrayon");
            }
        }
}
