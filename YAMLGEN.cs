using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT_Piranha
{
	public partial class YAMLGEN : Form
	{
		public YAMLGEN()
		{
			InitializeComponent();
		}

		private void generateButton_Click(object sender, EventArgs e)
		{
			string errors = InputErrors();
			if (!string.IsNullOrEmpty(errors))
			{
				MessageBox.Show(errors);
				return;
			}

			int count = int.Parse(countTextBox.Text);
			string format = "D" + countTextBox.Text.Length.ToString();

			string baseFile = File.ReadAllText(inputFileTextBox.Text);
			string baseFileName = Path.GetFileNameWithoutExtension(inputFileTextBox.Text);

			for (int world = 1; world <= count; ++world)
			{
				string worldFormat = world.ToString(format);
				string newFile = baseFile.Replace(playerTextBox.Text, playerTextBox.Text + worldFormat);

				string newFilePath = Path.Combine(outputFolderTextBox.Text, baseFileName + worldFormat + ".YAML");

				File.WriteAllText(newFilePath, newFile);
			}

			MessageBox.Show("Generation Complete");
		}

		private string InputErrors()
		{
			StringBuilder errors = new StringBuilder();
			if (!File.Exists(inputFileTextBox.Text))
				errors.AppendLine("Input File does not exist.");
			if (!Directory.Exists(outputFolderTextBox.Text))
				errors.AppendLine("Output Folder does not exist.");
			if (playerTextBox.Text.Length + countTextBox.Text.Length > 16)
				errors.AppendLine("Player Name + World Count index length exceed max player name length of 16.");
			if (!int.TryParse(countTextBox.Text, out _))
				errors.AppendLine("World Count is not a number.");
			return errors.ToString();
		}

		private void inputFileButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				inputFileTextBox.Text = fileDialog.FileName;
			}
		}

		private void outputFolderButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderDialog = new FolderBrowserDialog();
			if (folderDialog.ShowDialog() == DialogResult.OK)
			{
				outputFolderTextBox.Text = folderDialog.SelectedPath;
			}

		}
	}
}
