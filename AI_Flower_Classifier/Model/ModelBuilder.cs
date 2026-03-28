using Microsoft.ML;
using System;
using System.IO;
using System.Linq;
using AI_Flower_Classifier.Data;

namespace AI_Flower_Classifier.Model
{
    public class ModelBuilder
    {
        public static void TrainModel()
        {
            var mlContext = new MLContext();
            string root = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string dataPath = Path.Combine(root, "dataset", "flowers");

            var images = Directory.GetDirectories(dataPath)
                .SelectMany(folder => Directory.GetFiles(folder).Take(15)
                .Select(file => new ImageData { ImagePath = file, Label = Path.GetFileName(folder) }))
                .ToList();

            var data = mlContext.Data.LoadFromEnumerable(images);

            // PIPELINE FIX: Load -> Resize -> Extract Pixels -> Train
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label")
                .Append(mlContext.Transforms.LoadImages("ImageObject", dataPath, "ImagePath")) // Step 1: Load as Image Object
                .Append(mlContext.Transforms.ResizeImages("ImageObject", 224, 224, "ImageObject")) // Step 2: Resize
                .Append(mlContext.Transforms.ExtractPixels("Pixels", "ImageObject")) // Step 3: Convert to Pixels (Vector)
                .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy("Label", "Pixels")) // Step 4: Train
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(data);

            // Save model.zip
            mlContext.Model.Save(model, data.Schema, Path.Combine(root, "model.zip"));
        }
    }
}