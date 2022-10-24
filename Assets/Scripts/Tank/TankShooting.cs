using UnityEngine;
using UnityEngine.UI;

public partial class TankShooting : MonoBehaviour
{
    public int m_PlayerID = 1;       
    public Rigidbody m_Shell;            
    public Slider m_AimSlider;           
      
    public float m_MinLaunchForce = 15f; 
    public float m_MaxLaunchForce = 30f; 
    public float m_MaxChargeTime = 0.75f;

    //public FiringControl m_FiringControl;


    private string m_FireButton;
    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    private bool m_Fired;

    private bool m_IsActive = true;


    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        m_FireButton = "Fire" + m_PlayerID;

        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;

        //m_FiringControl = new FiringControl();
        FiringControlStart();
    }


    private void Update()
    {
        // only update if the tank is able to shoot
        if (m_IsActive)
        {
            // if the tank is currently firing bullets, do nothing until it finish.
            if (!IsFiring())
            {
                // Track the current state of the fire button and make decisions based on the current launch force.
                m_AimSlider.value = m_MinLaunchForce;

                if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
                {
                    // at max charge, not yet fired
                    m_CurrentLaunchForce = m_MaxLaunchForce;
                    Fire();
                }
                else if (Input.GetButtonDown(m_FireButton))
                {
                    // just pressed fire button
                    m_Fired = false;
                    m_CurrentLaunchForce = m_MinLaunchForce;

                    PlayChargingClip();
                }
                else if (Input.GetButton(m_FireButton) && !m_Fired)
                {
                    // holding the fire button, not yet fired
                    m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

                    m_AimSlider.value = m_CurrentLaunchForce;
                }
                else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
                {
                    // released the fire button, not yet fired
                    Fire();
                    PlayFireClip();

                }
            }

            FiringControlUpdate();
        }
        
    }


    private void Fire()
    {
        // Instantiate and launch the shell.
        m_Fired = true;
        // start firing with current launch force
        OnStartFiring(m_PlayerID, m_CurrentLaunchForce);

        m_CurrentLaunchForce = m_MinLaunchForce;
    }

    #region Getter setter
    public void SetActive(bool active) {
        m_IsActive = active;
    }

    #endregion
}