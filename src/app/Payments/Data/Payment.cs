
using Dapper;
using System.Data;
using App.Common.Utils;
using App.Common.Context;
using App.Payments.Contracts;
using App.Payments.Models.Requests;
using App.Payments.Models.Responses;

namespace App.Payments.Data;
public sealed class Payment(ClinicMasterContext context) : IPayment 
{
    public async Task<bool> UpdatePayment(PaymentFullRequest request)
    {        
        var query = """
                        INSERT INTO Payments (GRNNo, ReceivedDate, Content, CreatedBy, CreatedAt, SyncStatus) 
                        VALUES (@GRNNo, @ReceivedDate, CAST(@Content AS JSONB), @CreatedBy, @CreatedAt, @SyncStatus);
                    """;
                    
        var parameters = new DynamicParameters ();

        parameters.Add(name: nameof(request.GRNNo), value: request.GRNNo, dbType: DbType.String);
        parameters.Add(name: nameof(request.ReceivedDate), value: request.ReceivedDate, dbType: DbType.Date);
        parameters.Add(name: nameof(request.Content), value: request.Content, dbType: DbType.String);
        parameters.Add(name: nameof(request.CreatedBy), value: request.CreatedBy, dbType: DbType.String);
        parameters.Add(name: nameof(request.CreatedAt), value: request.CreatedAt, dbType: DbType.DateTime2);
        parameters.Add(name: nameof(request.SyncStatus), value: request.SyncStatus, dbType: DbType.Boolean);

        using var connection = context.CreateConnection();
        var result = await connection.ExecuteAsync(sql: query, param: parameters);

        return result > 0;
    }
    public async Task<PaymentResult<PaymentResponse>> GetPayment(string billNo)
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
                Message = "Payment Not Found",
                Data = PaymentResponse.Empty,            
            };
        
        var payment = new PaymentResponse 
            {
                BillNo = data.BillNo,
                PayNo = data.PayNo,
                PayType = data.PayType,
                ContentSent = Utils.DeserializeContent<PaymentContentSentResponse>
                (content: data.ContentSent) ?? PaymentContentSentResponse.Empty,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,                              
                Completed = data.Completed,
            };

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = payment,            
            };
    }
    public async Task<PaymentResult<IEnumerable<PaymentResponse>>> GetPayments(int page, int pageSize)
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
                Message = "Payments Not Found",
                Data = [],            
            };
            
        var payments = incomingData.Select(data => new PaymentResponse 
            {
                BillNo = data.BillNo,
                PayNo = data.PayNo,
                PayType = data.PayType,
                ContentSent = Utils.DeserializeContent<PaymentContentSentResponse>
                (content: data.ContentSent) ?? PaymentContentSentResponse.Empty,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,                              
                Completed = data.Completed,
            });
        
        var pagedPayments = payments.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new () 
            {
                Success = true,
                Message = string.Empty,
                Data = pagedPayments,            
            };           
    }
}