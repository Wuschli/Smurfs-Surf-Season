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
			INeedValueProvider result = null;
			if (range.Need.name.ToLower() == "rush")
				result = _container.Instantiate<RushNeedValueProvider>(new object[] { location, range.Need });
			else
				result = _container.Instantiate<DefaultNeedValueProvider>(new object[] { location, range.Need, UnityEngine.Random.Range(range.Min, range.Max) });
			_world.Register(result);
			return result;
		}
	}
}