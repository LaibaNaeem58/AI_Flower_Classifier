namespace AI_Flower_Classifier
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnTrainModel;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblBrand; // Added for your name

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            sidebar = new Panel();
            header = new Panel();
            btnSelectImage = new Button();
            btnTrainModel = new Button();
            btnPredict = new Button();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            lblTitle = new Label();
            lblStatus = new Label();
            lblBrand = new Label();
            sidebar.SuspendLayout();
            header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // ================= HEADER =================
            header.BackColor = Color.FromArgb(0, 100, 0);
            header.Dock = DockStyle.Top;
            header.Height = 80;
            header.Controls.Add(lblTitle);
            // TITLE LABEL
            lblTitle.Text = "🌸 Flower Classification AI";
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // ================= SIDEBAR =================
            sidebar.BackColor = Color.FromArgb(33, 33, 33);
            sidebar.Dock = DockStyle.Left;
            sidebar.Width = 230;
            sidebar.Controls.Add(btnSelectImage);
            sidebar.Controls.Add(btnTrainModel);
            sidebar.Controls.Add(btnPredict);
            sidebar.Controls.Add(lblBrand);
            // BRAND LABEL (Your Name)
            lblBrand.Text = "Developed by Laiba";
            lblBrand.ForeColor = Color.Gray;
            lblBrand.Dock = DockStyle.Bottom;
            lblBrand.TextAlign = ContentAlignment.MiddleCenter;
            lblBrand.Height = 40;
            // ================= MAIN UI ELEMENTS =================
            lblStatus.Text = "Status: Ready";
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.Location = new Point(260, 90);
            lblStatus.AutoSize = true;
            pictureBox1.Location = new Point(260, 130);
            pictureBox1.Size = new Size(550, 300);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BackColor = Color.WhiteSmoke;
            progressBar1.Location = new Point(260, 450);
            progressBar1.Size = new Size(550, 15);
            // ================= BUTTONS WITH EMOJI ICONS =================
            // Since external images can crash, we use Unicode Emojis which are reliable
            StyleButton(btnSelectImage, "📂  Select Image", 50, Color.DodgerBlue);
            btnSelectImage.Click += btnSelectImage_Click;
            StyleButton(btnTrainModel, "⚙️  Train Model", 120, Color.MediumSeaGreen);
            btnTrainModel.Click += btnTrainModel_Click;
            StyleButton(btnPredict, "\U0001f9e0  Predict Flower", 190, Color.OrangeRed);
            btnPredict.Click += btnPredict_Click;
            // ================= FORM SETUP =================
            ClientSize = new Size(880, 520);
            Controls.Add(lblStatus);
            Controls.Add(pictureBox1);
            Controls.Add(progressBar1);
            Controls.Add(sidebar);
            Controls.Add(header);
            Text = "AI Flower Classifier Pro";
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            sidebar.ResumeLayout(false);
            header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void StyleButton(System.Windows.Forms.Button btn, string text, int top, System.Drawing.Color color)
        {
            btn.Text = text;
            btn.Width = 200;
            btn.Height = 55;
            btn.Left = 15;
            btn.Top = top;
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }
    }
}