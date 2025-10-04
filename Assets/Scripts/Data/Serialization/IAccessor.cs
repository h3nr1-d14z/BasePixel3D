namespace Core.Serialization
{
	public interface IAccessor
	{
		string Name
		{
			get;
		}

		object GetValue(object obj);

		void SetValue(object obj, object value);
	}
}


