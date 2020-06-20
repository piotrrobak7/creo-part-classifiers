namespace MPExport.FileProcessing
{
    class ValidationResult
    {
        public bool Valid { get; }
        public string Message { get; }

        public ValidationResult(string message = null)
        {
            Valid = message == null;
            Message = message;
        }
    }
}
