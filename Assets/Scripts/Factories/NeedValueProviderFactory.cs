using System;
using Settings;
using Zenject;

namespace Factories
{
	public class NeedValueProviderFactory : Factory<NeedRange, Location, INeedValueProvider>
	{
	}

	public class CustomNeedValueProviderFactory : IFactory<NeedRange, Location, INeedValueProvider>
	{
		private readonly DiContainer _container;
		private readonly World _world;


		public CustomNeedValueProviderFactory(DiContainer container, World world)
		{
			_container = container;
			_world = world;
		}
		public INeedValueProvider Create(NeedRange range, Location location)
		{
			var result = _container.Instantiate<DefaultNeedValueProvider>(new object[] { location, UnityEngine.Random.Range(range.Min, range.Max) });
			_world.Register(result);
			return result;
		}
	}
}