using System.Reflection;

namespace Core.Serialization
{
	public class FieldAccessor : IAccessor
	{
		private FieldInfo m_fi;

		public string Name
		{
			get
			{
				return this.m_fi.Name;
			}
		}

		public FieldAccessor(FieldInfo fi)
		{
			this.m_fi = fi;
		}

		public object GetValue(object obj)
		{
			return this.m_fi.GetValue(obj);
		}

		public void SetValue(object obj, object value)
		{
			this.m_fi.SetValue(obj, value);
		}
	}
}


