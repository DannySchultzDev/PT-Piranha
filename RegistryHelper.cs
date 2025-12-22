using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_Piranha
{
	public static class RegistryHelper
	{
		private static readonly RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\PT Piranha");

		private static readonly Dictionary<Type, RegistryValueKind> typeDict = new Dictionary<Type, RegistryValueKind>()
		{
			{typeof(int), RegistryValueKind.DWord},
			{typeof(string), RegistryValueKind.String}
		};

		public static T GetValue<T>(RegistryName name, T defaultValue)
		{
			if(!typeDict.TryGetValue(typeof(T), out RegistryValueKind kind))
				throw new NotImplementedException(
					"There is no registry type implemented to handle variables of type: " + typeof(T).Name);

			if (!key.GetValueNames().Contains(name.ToString()))
			{
				key.SetValue(name.ToString(), defaultValue, kind);
				return defaultValue;
			}

			return (T)key.GetValue(name.ToString(), defaultValue);
		}

		public static void SetValue<T>(RegistryName name, T value)
		{
			if (!typeDict.TryGetValue(typeof(T),out RegistryValueKind kind))
				throw new NotImplementedException(
					"There is no registry type implemented to handle variables of type: " + typeof(T).Name);

			key.SetValue(name.ToString(), value, kind);
		}
	}
	public enum RegistryName
	{
		IP_CURRENT,
		PORT_CURRENT,
		IP_DEFAULT,
		PORT_DEFAULT,
		VERSION_MAJOR,
		VERSION_MINOR,
		VERSION_BUILD,
		SHOW_CONNECTION_SETTINGS
	}
}
