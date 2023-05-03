using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

namespace WineCrafter
{
    public class PanelController : MonoBehaviour
    {

        public GameObject myPanel;

        public void OnButtonClick()
        {
            StartCoroutine(DeactivatePanelWithAnimation());
        }

        private IEnumerator DeactivatePanelWithAnimation()
        {
            // Get reference to the Animator component on UI panel
            Animator animator = myPanel.GetComponent<Animator>();


            // Play the animation
            if (animator != null )
            {
                animator.Play("PopUpPanel0");
            }
            

            // Wait for the animation to finish
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            // Deactivate the UI panel
            myPanel.SetActive(false);
        }



    }
}

