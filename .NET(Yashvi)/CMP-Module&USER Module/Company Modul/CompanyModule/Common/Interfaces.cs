using System.Linq.Expressions;
using CompanyModule.Common.Responses;
using CompanyModule.Interface.Repository;
using CompanyModule.Models.DTO;

namespace CompanyModule.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<T> GetById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void MarkPropertyModified(T entity, string propertyName);
    }

    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ICompanyDetailRepository CompanyDetailRepository { get; }
        IApplicationUserAttachmentRepository ApplicationUserAttachmentRepository { get; }
        IOtpMasterRepository OtpMasterRepository { get; }
        Task<int> SaveChangesAsync();
        Task<int> CompleteAsync();
    }

    public interface IServiceResponseExceptionHandler
    {
        Task<ServiceResponse<T>> HandleAsync<T>(Func<Task<T>> operation, object? context = null);
    }

    public class ServiceResponseException : Exception
    {
        public System.Net.HttpStatusCode StatusCode { get; }
        
        public ServiceResponseException(System.Net.HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public static class TaskRunnerFactory
    {
        public static Task<Task<T>> RunTask<T>(Func<Task<T>> taskFactory)
        {
            return Task.FromResult(taskFactory());
        }
    }

    public static class CredentialHashSaltGenerator
    {
        public static (string passwordHash, string saltHash) GenerateCredential(string password)
        {
            var salt = Guid.NewGuid().ToString();
            var hash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password + salt));
            return (hash, salt);
        }

        public static bool ValidateCrednetial(string password, string hash, string salt)
        {
            var computedHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password + salt));
            return computedHash == hash;
        }
    }

    public static class JWTHelper
    {
        public static string GenerateJwtToken(object user, List<string> roles)
        {
            return "dummy-jwt-token";
        }
    }

    public static class OtpGenerator
    {
        public static string GetPassword(int length)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }

    public static class ImagesRootFolderPath
    {
        public const string RootFolder = "Images";
        public const string ProfilePhoto = "ProfilePhotos";
        public const string EmailTemplate = "EmailTemplates";
    }

    public static class CsvRootFolderPath
    {
        public const string RootFolder = "Csv";
        public const string User = "Users";
    }

    public class EmailResponse
    {
        public string[] To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailResponse(string[] to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }

    public static class EmailHelper
    {
        public static object CreateEmailMessage(EmailResponse emailResponse)
        {
            return new { emailResponse.To, emailResponse.Subject, emailResponse.Body };
        }

        public static Task SendEmail(object emailMessage)
        {
            return Task.CompletedTask;
        }
    }
}