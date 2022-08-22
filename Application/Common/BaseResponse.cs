using FluentValidation.Results;

namespace Application.Common;

public class BaseResponse
{
    public ResponseStatus Status { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
    public List<string> ValidationErrors { get; set; }

    public BaseResponse()
    {
        ValidationErrors = new List<string>();
        Success = true;
        Status = ResponseStatus.Success;
    }
    public BaseResponse(string? message = null)
    {
        ValidationErrors = new List<string>();
        Message = message;
        Success = true;
        Status = ResponseStatus.Success;
    }

    public BaseResponse(string message, bool success)
    {
        ValidationErrors = new List<string>();
        Success = success;
        Message = message;
        Status = success ? ResponseStatus.Success : ResponseStatus.BadQuery;
    }

    public BaseResponse(ValidationResult validationResult)
    {
        ValidationErrors = new List<String>();
        Success = validationResult.Errors.Count < 0;
        foreach (var item in validationResult.Errors)
        {
            ValidationErrors.Add(item.ErrorMessage);
        }
        Status = ResponseStatus.ValidationError;
    }
}

public enum ResponseStatus
{
    Success = 0,
    NotFound = 1,
    BadQuery = 2,
    ValidationError = 3
}
