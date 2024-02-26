
namespace App.Common.Exceptions;
public static class AddGlobalErrorHandlerExtensions {

    public static IServiceCollection AddGlobalExceptionHandler (this IServiceCollection services)
    { 
        services.AddExceptionHandler<AppBadHttpRequestExceptionHandler>();
        services.AddExceptionHandler<AppNotImplementedExceptionHandler>();
        services.AddExceptionHandler<AppUnauthorizedAccessExceptionHandler>();
        services.AddExceptionHandler<AppGlobalExceptionHandler>();

        return services;
    }
}