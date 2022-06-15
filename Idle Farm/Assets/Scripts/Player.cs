using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private GameObject weapon;
    [SerializeField] private ParticleSystem wheatEffect;
    private Collider wheat;

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (wheat == null)
        {
            anim.SetBool("Attack", false);
            weapon.SetActive(false);
        }
    } 
    public void TakeAnim()
    {
        if (wheat != null)
        {
            wheat.GetComponent<Wheat>().TakeDamage(1);
            Instantiate(wheatEffect, transform.position, Quaternion.identity);
        }
    }
   private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wheat")
        {
            wheat = other;
            anim.SetBool("Attack", true);
            weapon.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wheat")
        {
            anim.SetBool("Attack", false);
            weapon.SetActive(false);
            wheat = null;
        }
    }
}
