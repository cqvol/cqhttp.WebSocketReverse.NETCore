///source : https://github.com/Jie2GG/Native.Framework
using cqhttp.WebSocketReverse.NETCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace cqhttp.WebSocketReverse.NETCore.Expand
{
	/// <summary>
	/// 扩展方法集
	/// </summary>
	public static class SystemExpand
	{
		/// <summary>
		/// 读取 <see cref="System.Enum"/> 标记 <see cref="System.ComponentModel.DescriptionAttribute"/> 的值
		/// </summary>
		/// <param name="value">原始 <see cref="System.Enum"/> 值</param>
		/// <returns></returns>
		public static string GetDescription (this System.Enum value)
		{
			if (value == null)
			{
				return string.Empty;
			}

			FieldInfo fieldInfo = value.GetType ().GetField (value.ToString ());
			DescriptionAttribute attribute = fieldInfo.GetCustomAttribute<DescriptionAttribute> (false);
			return attribute.Description;
		}

		/// <summary>
		/// 酷Q码解析
		/// </summary>
		public static List<CQCode> Parse(this System.String message)
        {
			return CQCode.Parse(message);
		}
	}
}
