namespace OpenLab.Kitchen.Recogniser.Library.Validation
{
    public struct ValidationResult
    {
        public double TruePositive { get; set; }

        public double TrueNegative { get; set; }

        public double FalsePositive { get; set; }

        public double FalseNegative { get; set; }
    }

    public struct GroupValidationResult
    {
        public double[,] CM { get; set; }

        public double Unknown { get; set; }
    }
}
