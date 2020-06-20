namespace MPExport.FileProcessing.Constants
{
    static class PathErrors
    {
        public const string INVALID_CHARS_OR_EMPTY = "Path contains invalid characters or is empty!";
        public const string NO_ACCESS = "This app has no access to this location!";
        public const string PATH_TO_LONG = "Path is too long!";
        public const string PATH_NOT_ROOTED = "Path is not rooted!";
        public const string INPUT_FILE_FIRST = "Enter path to the input file first!";
        public const string INVALID_FILE_TYPE = "Only txt files are allowed!";
        public const string NOT_DIRECTORY = "This is not a directory path!";
    }

    static class AllowedExtensions
    {
        public const string TXT = ".txt";
        public const string PRT = ".prt";
    }
}
