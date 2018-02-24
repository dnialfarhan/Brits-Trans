using UnityEngine;

public class Destination : MonoBehaviour {

	[SerializeField]
	private GameObject desCollider;
	[SerializeField]
	private GameObject Passanger;
	[SerializeField]
	private GameObject desIndicator;
	[SerializeField]
	private GameObject PickUp;

	public PlayerStat Stat;
	
	// Use this for initialization
	void Start ()
    {
		Stat = GetComponent<PlayerStat>();

		desCollider.SetActive(true);

		desIndicator.SetActive(true);
    }

	

    public void OnTriggerEnter(Collider des)
    {
        if(des.gameObject.tag == "Player")
        {
            desCollider.SetActive(false);
            Passanger.SetActive(false);

			Stat.PassangerScore();

			PickUp.SetActive(true);
			
        }
    }


}
