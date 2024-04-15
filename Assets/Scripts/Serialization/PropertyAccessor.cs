using System.Reflection;

namespace Core.Serialization
{
	public class PropertyAccessor : IAccessor
	{
		private PropertyInfo m_pi;

		public string Name
		{
			get
			{
				return this.m_pi.Name;
			}
		}

		public PropertyAccessor(PropertyInfo fi)
		{
			this.m_pi = fi;
		}

		public object GetValue(object obj)
		{
			return this.m_pi.GetGetMethod(true).Invoke(obj, null);
		}

		public void SetValue(object obj, object value)
		{
			this.m_pi.SetValue(obj, value, null);
		}
	}
}


