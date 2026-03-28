using Microsoft.ML;
using System;
using System.IO;
using System.Linq;
using AI_Flower_Classifier.Data;

namespace AI_Flower_Classifier.Services
{
    public class Predictor
    {
        public static string Predict(string imagePath)
        {
            var mlContext = new MLContext();

            string root = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string modelPath = Path.Combine(root, "model.zip");

            if (!File.Exists(modelPath))
                return "Model not trained";

            var model = mlContext.Model.Load(modelPath, out _);
            var engine = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);

            var prediction = engine.Predict(new ImageData { ImagePath = imagePath });

            float maxScore = prediction.Score.Length > 0 ? prediction.Score.Max() : 0;

            if (maxScore < 0.65f)
                return $"Unknown ({maxScore:P0})";

            return $"{prediction.PredictedLabel} ({maxScore:P0})";
        }
    }
}