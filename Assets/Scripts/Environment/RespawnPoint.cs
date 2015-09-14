﻿using UnityEngine;

[AddComponentMenu("Environment/Respawn Point")]
public class RespawnPoint : MonoBehaviour
{
	[SerializeField]
	protected Vector3 localRespawnPoint = default(Vector3);

	private Animator animator = null;

	public bool Activated { get; private set; } = false;
	public Vector3 Location => transform.TransformPoint(localRespawnPoint);

	protected Animator Animator => this.GetComponentIfNull(ref animator);

	public virtual void Activate()
	{
		if (Activated) return;

		Activated = true;
		Animator.SetBool("Activated", Activated);
		PlayActivateSound();
	}

	public virtual void Deactivate()
	{
		if (!Activated) return;

		Activated = false;
		animator.SetBool("Activated", Activated);
	}

	protected virtual void PlayActivateSound() => SoundManager.PlaySFX(SoundManager.LoadFromGroup(SfxGroups.RespawnPoints));
}
