using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public int m_PlayerID = 1;         
    private float m_Speed = 12f;
    public float m_TurnSpeed = 180f;       
    private float m_OriginalSpeed;
    private float m_OriginalTurnSpeed;
    
    public AudioSource m_MovementAudio;    
    public AudioClip m_EngineIdling;       
    public AudioClip m_EngineDriving;      
    public float m_PitchRange = 0.2f;


    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;
    private float m_OriginalPitch;

    private float m_MinSpeed = 0f;
    private float m_MaxSpeed = 20f;
    private float m_MinTurnSpeed = 0f;
    private float m_MaxTurnSpeed = 360f;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_MovementAxisName = "Vertical" + m_PlayerID;
        m_TurnAxisName = "Horizontal" + m_PlayerID;

        m_OriginalPitch = m_MovementAudio.pitch;

        m_OriginalSpeed = m_Speed;
        m_OriginalTurnSpeed = m_TurnSpeed;
    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

        EngineAudio();
    }


    private void EngineAudio()
    {
        // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.
        if(Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
        {
            if(m_MovementAudio.clip == m_EngineDriving)
            {
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
        else
        {
            if (m_MovementAudio.clip == m_EngineIdling)
            {
                m_MovementAudio.clip = m_EngineDriving;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
        }
    }


    private void FixedUpdate()
    {
        // Move and turn the tank.
        Move();
        Turn();
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }


    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }


   public void ChangeSpeedByAmount(float percentage)
    {
        Debug.Log("ChangeSpeedByAmount: " + percentage);
        m_Speed = m_Speed * (1 + percentage);
        if (m_Speed > m_MaxSpeed)
        {
            m_Speed = m_MaxSpeed;
        }
        if (m_Speed < m_MinSpeed)
        {
            m_Speed = m_MinSpeed;
        }
    }

    public void ChangeTurningSpeedOnAmount(float percentage)
    {
        Debug.Log("ChangeTurningSpeedOnAmount");
        m_TurnSpeed = m_TurnSpeed * (1 + percentage);
        if (m_TurnSpeed > m_MaxTurnSpeed)
        {
            m_TurnSpeed = m_MaxTurnSpeed;
        }
        if (m_TurnSpeed < m_MinTurnSpeed)
        {
            m_TurnSpeed = m_MinTurnSpeed;
        }
    }



    public void ResetOriginalSpeed()
    {
        // CHECK STATUS

        m_Speed = m_OriginalSpeed;
    }

    public void ResetOriginalTurnSpeed()
    {
        m_TurnSpeed = m_OriginalTurnSpeed;
    }
}