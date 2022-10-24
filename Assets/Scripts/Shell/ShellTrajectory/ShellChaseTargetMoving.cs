using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellChaseTargetMoving : IShellMoving
{
    private Vector3 m_TargetPosition;
    private float m_DetectTargetRange = 10f;
    private float m_ChaseTargetSpeed = 8f;
    public void MoveShell(Shell shell)
    {
        if (DetecTarget(shell))
        {
            MoveTowardTarget(shell);
        }
    }

    private void MoveTowardTarget(Shell shell)
    {
        shell.transform.position = Vector3.MoveTowards(shell.transform.position, m_TargetPosition, m_ChaseTargetSpeed * Time.deltaTime);
    }

    private bool DetecTarget(Shell shell)
    {
        Collider[] hitColliders = Physics.OverlapSphere(shell.transform.position, m_DetectTargetRange, shell.m_TankLayerMask);
        
        // if detect no tanks
        if (hitColliders.Length == 0)
            return false;

        // find the nearest tank
        GameObject target = null;
        float minDistance = float.MaxValue;
        foreach(Collider collider in hitColliders)
        {
            if(collider.gameObject.GetComponent<TankHealth>().m_PlayerID == shell.GetTankID())
            {
                continue;
            }
            float distance = Vector3.Distance(shell.transform.position, collider.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                target = collider.gameObject;
            }
        }

        if (target == null)
            return false;
        m_TargetPosition = target.transform.position;
        return true;
    }

   
}
