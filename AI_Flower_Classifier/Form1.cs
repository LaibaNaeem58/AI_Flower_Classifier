using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI_Flower_Classifier.Model;
using AI_Flower_Classifier.Services;

namespace AI_Flower_Classifier
{
    public partial class Form1 : Form
    {
        string imagePath = "";

        string modelPath = Path.Combine(
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")),
            "model.zip"
        );

        public Form1()
        {
            InitializeComponent();
        }

        // ================= STEP 1 =================
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.png;*.jpeg"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                pictureBox1.Image = Image.FromFile(imagePath);

                lblStatus.Text = "Step 1 Done";

                MessageBox.Show(
                    "Step 1 Complete: Image Selected",
                    "Step 1",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // ================= STEP 2 =================
        private async void btnTrainModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Select image first (Step 1)");
                return;
            }

            btnTrainModel.Enabled = false;
            progressBar1.Value = 0;

            if (File.Exists(modelPath))
            {
                progressBar1.Value = 100;
                lblStatus.Text = "Model Already Exists";

                MessageBox.Show(
                    "Model already trained. Using FAST mode.",
                    "Step 2 Skipped",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                btnTrainModel.Enabled = true;
                return;
            }

            try
            {
                lblStatus.Text = "Training Started...";

                for (int i = 0; i <= 30; i += 10)
                {
                    progressBar1.Value = i;
                    await Task.Delay(100);
                }

                await Task.Run(() => ModelBuilder.TrainModel());

                for (int i = 40; i <= 100; i += 20)
                {
                    progressBar1.Value = i;
                    await Task.Delay(100);
                }

                lblStatus.Text = "Training Completed";

                MessageBox.Show(
                    "Step 2 Complete: Model Trained Successfully",
                    "Training Done",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Training Error: " + ex.Message);
            }
            finally
            {
                btnTrainModel.Enabled = true;
            }
        }

        // ================= STEP 3 =================
        private void btnPredict_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Select image first (Step 1)");
                return;
            }

            if (!File.Exists(modelPath))
            {
                MessageBox.Show("Train model first (Step 2)");
                return;
            }

            lblStatus.Text = "Predicting...";

            string result = Predictor.Predict(imagePath);

            lblStatus.Text = "Done";

            MessageBox.Show(
                "Prediction Result:\n\n" + result,
                "Step 3 Output",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}