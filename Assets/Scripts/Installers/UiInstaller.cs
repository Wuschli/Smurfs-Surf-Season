using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
	public Transform UiRoot;

	public override void InstallBindings()
	{
		foreach (var initializable in UiRoot.GetComponentsInChildren(typeof(IWorldInitializable)))
			Container.Bind<IWorldInitializable>().ToSelf().FromInstance(initializable as IWorldInitializable);
		foreach (var tickable in UiRoot.GetComponentsInChildren(typeof(IWorldTickable)))
			Container.Bind<IWorldTickable>().ToSelf().FromInstance(tickable as IWorldTickable);
	}
}
