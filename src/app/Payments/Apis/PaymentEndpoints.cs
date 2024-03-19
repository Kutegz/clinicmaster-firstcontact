
using App.Common.Filters;
using App.Payments.Controllers;
using App.Payments.Models.Requests;

namespace App.Payments.Apis;
public static class PaymentEndpoints
{
    public static void ConfigurePaymentApis(this WebApplication app)
    {
        // Includes all Payments API endpoint mappings
        var group = app.MapGroup(prefix: "/payments").RequireAuthorization();
                        // .AddEndpointFilter<ApiAccessAuthEndpointFilter>();
                        
        group.MapPut(pattern: "", handler: PaymentController.UpdatePayment).AllowAnonymous()
                                    .WithName(nameof(PaymentController.UpdatePayment))
                                    .AddEndpointFilter<RequestEndPontFilter<PaymentRequest>>();   
                        
        group.MapGet(pattern: "/{billNo}", handler: PaymentController.GetPayment).AllowAnonymous(); 
        group.MapGet(pattern: "", handler: PaymentController.GetPayments).AllowAnonymous();
    }

}