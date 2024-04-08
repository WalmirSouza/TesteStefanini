namespace Questao5.Infrastructure.Database
{
	public class DapperMapper
	{
		private readonly Dictionary<Type, Dictionary<object, object>> _map = new();

		public IEnumerable<TObject> GetObjects<TObject>() => GetContainer<TObject>().Values.OfType<TObject>();

		public TObject Get<TObject, TId>(TId id, TObject obj)
		{
			var container = GetContainer<TObject>();

			if (!container.TryGetValue(id, out var value))
			{
				container[id] = value = obj;
			}

			return (TObject)value;
		}

		private Dictionary<object, object> GetContainer<TObject>()
		{
			var type = typeof(TObject);
			if (!_map.TryGetValue(type, out var container))
			{
				container = new Dictionary<object, object>();
				_map[type] = container;
			}
			return container;
		}
	}
}
