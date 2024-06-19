USE ClinicMaster
GO

-- DELETE FROM dbo.Payments;


---------------------------------------------------------------
------- Payments ----------------------------------------------
---------------------------------------------------------------

INSERT INTO dbo.Payments (BillNo, PayNo, PayType, ContentSent, CreatedBy, CreatedAt, Outbox, ContentReceived, Agents, Completed) 
VALUES ('B001', '240001001', 'Visit Bill', '{
  "service": "USSD_001_AIRTEL_PUSH",
  "request": {
    "ref": "AIRTEL",
    "msisdn": 978980155,
    "transaction": {
      "amount": 1,
      "country": "ZM",
      "currency": "ZMW",
      "id": "B001"
    }
  }
}', 'Admin', GETUTCDATE(), NULL, NULL, NULL, 0);

INSERT INTO dbo.Payments (BillNo, PayNo, PayType, ContentSent, CreatedBy, CreatedAt, Outbox, ContentReceived, Agents, Completed) 
VALUES ('B002', '240001002', 'Visit Bill', '{
  "service": "USSD_001_AIRTEL_PUSH",
  "request": {
    "ref": "AIRTEL",
    "msisdn": 978980155,
    "transaction": {
      "amount": 2,
      "country": "ZM",
      "currency": "ZMW",
      "id": "B002"
    }
  }
}', 'Admin', GETUTCDATE(), NULL, NULL, NULL, 0);

INSERT INTO dbo.Payments (BillNo, PayNo, PayType, ContentSent, CreatedBy, CreatedAt, Outbox, ContentReceived, Agents, Completed) 
VALUES ('B003', '240001003', 'Visit Bill', '{
  "service": "USSD_001_AIRTEL_PUSH",
  "request": {
    "ref": "AIRTEL",
    "msisdn": 978980155,
    "transaction": {
      "amount": 1,
      "country": "ZM",
      "currency": "ZMW",
      "id": "B003"
    }
  }
}', 'Admin', GETUTCDATE(), NULL, NULL, NULL, 0);
