
using ClinicMasterFirstContact.src.App.Payments.Contracts;
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Payments.Models.Requests;
using ClinicMasterFirstContact.src.App.Payments.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Payments.Controllers;

public static class PaymentController 
{   public static async Task<IResult> UpdatePayment(PaymentRequest request, IPayment repo, 
                                        ILogger<PaymentRequest> logger)
    {      
        try
        {    
            var fullRequest = PaymentFullRequest.Create(request);
            var result = await repo.UpdatePayment(fullRequest);

            logger.LogInformation("Goods Received Note request received {@fullRequest}", fullRequest); 

            return Results.Created(uri: $"/payments/{request.GRNNo}/", 
                    value: new CreatedResponse
                        {
                            Success = result > 0,
                            StatusCode = StatusCodes.Status201Created,
                            Count = result,
                            Message = "Payments Updated Successfully",
                            Location = $"/payments/{request.GRNNo}/", 
                        });            
        }
        catch (Exception ex) 
        { 
            logger.LogError("Failed to create Gooods Received Note with GRN No: {@GRNNo}", request.GRNNo); 
            return Results.Problem(detail: ex.Message); 
        }  
    }
    public static async Task<IResult> GetPayment(string billNo, IPayment repo)
    {      
        try
        {
            var payment = await repo.GetPayment(billNo);
            if (payment.Data.Equals(PaymentResponse.Empty)) return Results.NotFound(value: payment);

            return Results.Ok(value: payment);            
        }
        catch (Exception ex) { return Results.Problem(detail: ex.Message); }  
    }

    public static async Task<IResult> GetPayments(IPayment repo, HttpContext context)
    {
        try
        {
            var pageValue = context.Request.Query["page"].FirstOrDefault();
            var pageSizeValue = context.Request.Query["pageSize"].FirstOrDefault();

            if (!int.TryParse(pageValue, out int page) || page <= 0) page = 1;
            if (!int.TryParse(pageSizeValue, out int pageSize) || pageSize <= 0) pageSize = 10;
        
            var payments = await repo.GetPayments(page: page, pageSize: pageSize);

            return Results.Ok(value: payments);   
            
        }
        catch (Exception ex) { return Results.Problem(detail: ex.Message); }
    }

}