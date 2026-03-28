using System;
using System.Windows.Forms;
using AI_Flower_Classifier.Model;

namespace AI_Flower_Classifier
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Docker environment check
            bool isDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

            if (isDocker)
            {
                // Docker mein sirf training hogi
                ModelBuilder.TrainModel();
            }
            else
            {
                // Windows par normal app chalegi
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
