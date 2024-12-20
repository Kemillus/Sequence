using System;
using System.Windows.Forms;

namespace Sequence
{
    public partial class Form1 : Form
    {
        private Sequence<int> intSequence = new Sequence<int>();

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int value = int.Parse(textBoxValue.Text);
                int index = int.Parse(textBoxInsertionIndex.Text);
                intSequence.Insert(index, value);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateListBox();
        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(textBoxReceiptInndex.Text);
                int value = intSequence[index];
                label4.Text = $"Value at index {index}: {value}";
            }

            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GetSubsequenceButton_Click(object sender, EventArgs e)
        {
            try
            {
                int startIndex = comboBox1.SelectedIndex;
                int endIndex = comboBox2.SelectedIndex;

                if (startIndex == -1 || endIndex == -1)
                {
                    throw new ArgumentException("Please select start and end indices.");
                }


                Sequence<int> subsequence = intSequence.GetSubsequence(startIndex, endIndex);

                listBoxTransformation.Items.Clear();
                foreach (int item in subsequence)
                {
                    listBoxTransformation.Items.Add(item);
                }
            }

            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateListBox()
        {
            listBoxItem.Items.Clear();
            for (int i = 0; i < intSequence.Count; i++)
            {
                listBoxItem.Items.Add(intSequence[i]);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateComboBoxes(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            if (intSequence != null)
            {
                foreach (var item in intSequence)
                {
                    comboBox1.Items.Add(item);
                    comboBox2.Items.Add(item);
                }
            }
        }
    }
}
