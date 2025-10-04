using System;

namespace Core.Serialization
{
	public class ShowInInspector : Attribute
	{
		public string FieldName
		{
			get;
			set;
		}

		public string ToolTip
		{
			get;
			protected set;
		}

		public bool ReadOnly
		{
			get;
			set;
		}

		public bool StaticArraySize
		{
			get;
			set;
		}

		public ShowInInspector()
			: this(false)
		{
		}

		public ShowInInspector(bool readOnly)
			: this(null, null, readOnly)
		{
		}

		public ShowInInspector(string fieldName, string toolTip = "", bool readOnly = false)
			: this(fieldName, toolTip, readOnly, false)
		{
		}

		public ShowInInspector(string fieldName, string toolTip, bool readOnly, bool staticArraySize)
		{
			this.FieldName = fieldName;
			this.ToolTip = toolTip;
			this.ReadOnly = readOnly;
			this.StaticArraySize = staticArraySize;
		}
	}
}


