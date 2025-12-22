using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT_Piranha
{
	public partial class ConnectionSettings : Form
	{
		string defaultIP;
		string currentIP;
		int defaultPort;
		int currentPort;

		bool showConnectionSettings;
		Version version;

		public ConnectionSettings()
		{
			defaultIP = RegistryHelper.GetValue(RegistryName.IP_DEFAULT, "localhost");
			currentIP = RegistryHelper.GetValue(RegistryName.IP_CURRENT, defaultIP);
			defaultPort = RegistryHelper.GetValue(RegistryName.PORT_DEFAULT, 38281);
			currentPort = RegistryHelper.GetValue(RegistryName.PORT_CURRENT, defaultPort);

			showConnectionSettings = RegistryHelper.GetValue(RegistryName.SHOW_CONNECTION_SETTINGS, 1) != 0;
			version = new Version(
				RegistryHelper.GetValue(RegistryName.VERSION_MAJOR, 0),
				RegistryHelper.GetValue(RegistryName.VERSION_MINOR, 6),
				RegistryHelper.GetValue(RegistryName.VERSION_BUILD, 5));

			InitializeComponent();
		}

		private void ConnectionSettings_Load(object sender, EventArgs e)
		{
			defaultIPTextBox.Text = defaultIP;
			currentIPTextBox.Text = currentIP;
			defaultPortTextBox.Text = defaultPort.ToString();
			currentPortTextBox.Text = currentPort.ToString();

			showConnectionSettingsCheckBox.Checked = showConnectionSettings;
			versionTextBox.Text = version.ToString();
		}

		private void CurrentIPChanged(object sender, EventArgs e)
		{
			currentIP = currentIPTextBox.Text;
		}

		private void CurrentPortChanged(object sender, EventArgs e)
		{
			if (int.TryParse(currentPortTextBox.Text, out int currentPortTextBoxInt))
				currentPort = currentPortTextBoxInt;
			else
				currentPortTextBox.Text = currentPort.ToString();
		}

		private void ShowConnectionSettingsChanged(object sender, EventArgs e)
		{
			showConnectionSettings = showConnectionSettingsCheckBox.Checked;
		}

		private void ResetCurrentConnection(object sender, EventArgs e)
		{
			currentIP = defaultIP;
			currentIPTextBox.Text = defaultIP;
			currentPort = defaultPort;
			currentPortTextBox.Text = defaultPort.ToString();
		}

		private void DefaultIPChanged(object sender, EventArgs e)
		{
			defaultIP = defaultIPTextBox.Text;
		}

		private void DefaultPortChanged(object sender, EventArgs e)
		{
			if (int.TryParse(defaultPortTextBox.Text, out int defaultPortTextBoxInt))
				defaultPort = defaultPortTextBoxInt;
			else
				defaultPortTextBox.Text = defaultPort.ToString();
		}

		private void VersionChanged(object sender, EventArgs e)
		{
			if (Version.TryParse(versionTextBox.Text, out Version versionTextBoxVersion))
				version = versionTextBoxVersion;
			else
				versionTextBox.Text = version.ToString();
		}

		private void ConnectionSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult != DialogResult.OK)
				return;

			RegistryHelper.SetValue(RegistryName.IP_CURRENT, currentIP);
			RegistryHelper.SetValue(RegistryName.PORT_CURRENT, currentPort);
			RegistryHelper.SetValue(RegistryName.SHOW_CONNECTION_SETTINGS,
				showConnectionSettings ? 1 : 0);
			RegistryHelper.SetValue(RegistryName.IP_DEFAULT, defaultIP);
			RegistryHelper.SetValue(RegistryName.PORT_DEFAULT, defaultPort);
			RegistryHelper.SetValue(RegistryName.VERSION_MAJOR, version.Major);
			RegistryHelper.SetValue(RegistryName.VERSION_MINOR, version.Minor);
			RegistryHelper.SetValue(RegistryName.VERSION_BUILD, version.Build);
		}
	}
}
