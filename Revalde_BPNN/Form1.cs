using Backprop;
using System.Diagnostics.CodeAnalysis;

namespace Revalde_BPNN
{
    public partial class Revalde_BPNN : Form
    {
        NeuralNet nn;
        int epochs = 0;
        public Revalde_BPNN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4, 1, 1);
            epochs = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            label3.Text = "Epochs: " + epochs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            epochs += 1000;
            double i0, i1, i2, i3, expected;
            for (int x = 0; x < epochs; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    i0 = (y & 8) != 0 ? 1.0 : 0.0;
                    i1 = (y & 4) != 0 ? 1.0 : 0.0;
                    i2 = (y & 2) != 0 ? 1.0 : 0.0;
                    i3 = (y & 1) != 0 ? 1.0 : 0.0;
                    nn.setInputs(0, i0);
                    nn.setInputs(1, i1);
                    nn.setInputs(2, i2);
                    nn.setInputs(3, i3);

                    expected = (y == 15) ? 1.0 : 0.0;
                    nn.setDesiredOutput(0, expected);
                    nn.learn();
                    label3.Text = "Epochs: " + epochs;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                nn.setInputs(0, Convert.ToDouble(textBox1.Text));
                nn.setInputs(1, Convert.ToDouble(textBox2.Text));
                nn.setInputs(2, Convert.ToDouble(textBox4.Text));
                nn.setInputs(3, Convert.ToDouble(textBox5.Text));
                nn.run();
                textBox3.Text = "" + nn.getOuputData(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid or missing inputs: "+ex.Message);
            }
        }
    }
}
