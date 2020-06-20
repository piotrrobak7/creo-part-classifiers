using System;
using System.IO;
using System.Security;

namespace MPExport.FileProcessing
{
    static class PathValidator
    {
        public static ValidationResult ValidateInputFilePath(string path) => ValidatePath(path, PathType.InputFile);
        public static ValidationResult ValidateOutputDirPath(string path) => ValidatePath(path, PathType.OutputDir);
        public static ValidationResult ValidateCreoPartPath(string path) => ValidatePath(path, PathType.CreoPart);

        #region General validation

        private static ValidationResult ValidatePath(string path, PathType pathType)
        {
            path = RemoveQuotes(path);
            var result = ValidatePath(path);
            if (!result.Valid) return result;

            switch (pathType)
            {
                case PathType.InputFile: return ValidateInputFilePath2(path);
                case PathType.OutputDir: return ValidateOutputDirPath2(path);
                case PathType.CreoPart: return ValidateCreoPartPath2(path);
                default: ThrowInvalidPathTypeException(); return null;
            }
        }

        private static string RemoveQuotes(string path)
        {
            if (path.Length > 0 && path[0] == '"' && path[path.Length - 1] == '"')
            {
                path = path.Remove(0, 1);
                path = path.Remove(path.Length - 1);
            }

            return path;
        }

        private static ValidationResult ValidatePath(string path)
        {
            string errorMsg = null;

            try { Path.GetFullPath(path); }
            catch (ArgumentException) { errorMsg = Constants.PathErrors.INVALID_CHARS_OR_EMPTY; }
            catch (SecurityException) { errorMsg = Constants.PathErrors.NO_ACCESS; }
            catch (NotSupportedException) { errorMsg = Constants.PathErrors.INVALID_CHARS_OR_EMPTY; }
            catch (PathTooLongException) { errorMsg = Constants.PathErrors.PATH_TO_LONG; }

            if (errorMsg == null && !Path.IsPathRooted(path)) errorMsg = Constants.PathErrors.PATH_NOT_ROOTED;

            return new ValidationResult(errorMsg);
        }

        #endregion

        #region Specific validation

        private static ValidationResult ValidateInputFilePath2(string path)
        {
            switch (Path.GetExtension(path))
            {
                case Constants.AllowedExtensions.TXT: return new ValidationResult();
                case "": return new ValidationResult(Constants.PathErrors.INPUT_FILE_FIRST);
                default: return new ValidationResult(Constants.PathErrors.INVALID_FILE_TYPE);
            }
        }

        private static ValidationResult ValidateOutputDirPath2(string path)
        {
            switch (Path.GetExtension(path))
            {
                case "": return new ValidationResult();
                default: return new ValidationResult(Constants.PathErrors.NOT_DIRECTORY);
            }
        }

        private static ValidationResult ValidateCreoPartPath2(string path)
        {
            switch (Path.GetExtension(path))
            {
                case Constants.AllowedExtensions.PRT: return new ValidationResult();
                default: return new ValidationResult(Constants.PathErrors.NOT_DIRECTORY);
            }
        }

        private static void ThrowInvalidPathTypeException()
        {
            const string errorMsg = "Provided path type is not implemented!";
            throw new ArgumentException(errorMsg);
        }

        #endregion
    }
}
