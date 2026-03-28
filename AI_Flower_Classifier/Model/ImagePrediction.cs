using Microsoft.ML.Data;

namespace AI_Flower_Classifier.Data
{
    public class ImagePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabel { get; set; } = string.Empty;

        public float[] Score { get; set; } = Array.Empty<float>();
    }
}