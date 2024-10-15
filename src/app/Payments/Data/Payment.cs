
using Dapper;
using System.Data;
using ClinicMasterFirstContact.src.App.Common.Utils;
using ClinicMasterFirstContact.src.App.Common.Context;
using ClinicMasterFirstContact.src.App.Payments.Contracts;
using ClinicMasterFirstContact.src.App.Common.Models.Responses;
using ClinicMasterFirstContact.src.App.Payments.Models.Requests;
using ClinicMasterFirstContact.src.App.Payments.Models.Responses;

namespace ClinicMasterFirstContact.src.App.Payments.Data;
public sealed class Payment(ClinicMasterContext context) : IPayment 
{
    public async Task<int> UpdatePayment(PaymentFullRequest request)
    {        
        var query = """
                        INSERT INTO Payments (GRNNo, ReceivedDate, Content, CreatedBy, CreatedAt, SyncStatus) 
                        VALUES (@GRNNo, @ReceivedDate, CAST(@Content AS JSONB), @CreatedBy, @CreatedAt, @SyncStatus);
                    """;

        using var connection = context.CreateConnection();
        return await connection.ExecuteAsync(sql: query, param: request);
    }
    public async Task<ResultResponse<PaymentResponse>> GetPayment(string billNo)
    {
        var query = """
                        SELECT BillNo, PayNo, PayType, ContentSent, CreatedBy, 
                        CreatedAt, Outbox, ContentReceived, Agents, Completed
                        FROM Payments WHERE BillNo = @BillNo
                    """;

        using var connection = context.CreateConnection();
        var parameters = new { billNo };
        var data = await connection.QuerySingleOrDefaultAsync<PaymentRowData> (sql: query, param: parameters);
        
        if (data is null) return new () 
            {
                Success = false,
                Count = 0,
                Message = "Payment Not Found",
                Data = PaymentResponse.Empty,            
            };
        
        var payment = new PaymentResponse 
            {
                BillNo = data.BillNo,
                PayNo = data.PayNo,
                PayType = data.PayType,
                ContentSent = CommonUtils.DeserializeContent<PaymentContentSentResponse>
                (content: data.ContentSent) ?? PaymentContentSentResponse.Empty,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,                              
                Completed = data.Completed,
            };

        return new () 
            {
                Success = true,
                Count = 1,
                Message = string.Empty,
                Data = payment,            
            };
    }
    public async Task<ResultResponse<IEnumerable<PaymentResponse>>> GetPayments(int page, int pageSize)
    {       
        if (page <= 0) page = 1;
        if (pageSize <= 0) pageSize = 10;
        if (pageSize > 100) pageSize = 100;

        var query = """
                        SELECT BillNo, PayNo, PayType, ContentSent, CreatedBy, 
                        CreatedAt, Outbox, ContentReceived, Agents, Completed
                        FROM Payments
                    """;

        using var connection = context.CreateConnection();
        var incomingData = await connection.QueryAsync<PaymentRowData>(sql: query);

        if (incomingData is null) return new () 
            {
                Success = false,
                Count = 0,
                Message = "Payments Not Found",
                Data = [],            
            };
            
        var payments = incomingData.Select(data => new PaymentResponse 
            {
                BillNo = data.BillNo,
                PayNo = data.PayNo,
                PayType = data.PayType,
                ContentSent = CommonUtils.DeserializeContent<PaymentContentSentResponse>
                (content: data.ContentSent) ?? PaymentContentSentResponse.Empty,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,                              
                Completed = data.Completed,
            });
        
        var pagedPayments = payments.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new () 
            {
                Success = true,
                Count = pagedPayments.Count,
                Message = string.Empty,
                Data = pagedPayments,            
            };           
    }
}