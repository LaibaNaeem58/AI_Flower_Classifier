using Microsoft.ML.Data;

namespace AI_Flower_Classifier.Data
{
    public class ImageData
    {
        public string ImagePath { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }
}