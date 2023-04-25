using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;


public class JumperAgent : Agent
{
    //public GameObject obstacle;
    private Rigidbody rb;
    private int counter = 0;
    private int collisions = 0;
    public override void OnEpisodeBegin()
    {
        rb = this.GetComponent<Rigidbody>();
        // reset de positie en orientatie als de agent gevallen is
        if (this.transform.localPosition.y < 0)
        {
            this.transform.localPosition = new Vector3(0, 0.5f, 0);
            this.transform.localRotation = Quaternion.identity;
        }
        counter = 0;
        collisions= 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.localPosition);
    }

    public float speedMultiplier = 0.4f;
    public float rotationMultiplier = 5;
    private bool isJumping = false;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if (actionBuffers.DiscreteActions[0] == 1&&!isJumping)
        {
            this.Jump();
            isJumping= true;
        }

        if (actionBuffers.DiscreteActions[0] == 0)
        {
            Debug.Log("action is 0");
        }

        if (transform.localPosition.y > 8)
        {
            isJumping = true;
        }else if (transform.localPosition.y <= 0.6 && transform.localPosition.y >= 0)
        {
            isJumping = false;
        }

        if(this.counter == 5) 
        { 
            EndEpisode();
        }

        if (this.collisions == 10)
        {
            EndEpisode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AddReward(-0.5f);
            Destroy(collision.gameObject);
            collisions++;
        }
            
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;
        if(Input.GetKey(KeyCode.UpArrow))
            discreteActionsOut[0] = 1;
    }

    private void Jump()
    {
        rb.AddRelativeForce(Vector3.up * 3f, ForceMode.Impulse);
        AddReward(-0.05f);
    }

    public void updateCounter()
    {
        AddReward(0.5f);
        this.counter++;
    }
}
