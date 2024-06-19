
	-- DROP TABLE IF EXISTS dbo.MedicalReports;
	-- DROP TABLE IF EXISTS dbo.Payments;
	-- DROP TABLE IF EXISTS dbo.Surgeries;
	-- DROP TABLE IF EXISTS dbo.Patients;
	-- DROP TABLE IF EXISTS dbo.Agents;

---------------------------------------------------------------
------- Agents ------------------------------------------------
---------------------------------------------------------------

	-- DROP TABLE IF EXISTS dbo.Agents;
	-- GO
-- DhftOS5uphK3vmCJQrexST1RsyjZBjxWrgJMFPU4
CREATE TABLE dbo.Agents
	(AgentId NVARCHAR(20) NOT NULL CONSTRAINT pkAgentIdAgents PRIMARY KEY,
	AgentName NVARCHAR(40) NOT NULL CONSTRAINT uqAgentNameAgents UNIQUE (AgentName),
	ApiKey NVARCHAR(MAX) NOT NULL,
	StartDateTime DATETIME2(0) NOT NULL,
	EndDateTime DATETIME2(0) NOT NULL,
	AgentStatus NVARCHAR(10) NOT NULL 
    CONSTRAINT chkAgentStatusAgents CHECK (AgentStatus IN ('Active', 'Inactive')),
	Creator NVARCHAR(MAX) NOT NULL CONSTRAINT ckCreatorAgents CHECK (ISJSON(Creator) = 1),
	CreatedAt DATETIME2(0) NOT NULL
	);
GO

---------------------------------------------------------------
------- Patients ----------------------------------------------
---------------------------------------------------------------

	-- DROP TABLE IF EXISTS dbo.Patients;
	-- GO

CREATE TABLE dbo.Patients
	(PatientNo NVARCHAR(20) NOT NULL CONSTRAINT pkPatientNoPatients PRIMARY KEY,
	FullName NVARCHAR(40) NOT NULL,
	Gender NVARCHAR(10) NOT NULL,
	Age INT NOT NULL,
	Creator NVARCHAR(MAX) NOT NULL CONSTRAINT ckCreatorPatients CHECK (ISJSON(Creator) = 1),
	CreatedAt DATETIME2(0) NOT NULL,
	Consumers NVARCHAR(MAX) NOT NULL CONSTRAINT ckConsumersPatients CHECK (ISJSON(Consumers) = 1)
	);
GO

---------------------------------------------------------------
------- Surgeries ---------------------------------------------
---------------------------------------------------------------

	-- DROP TABLE IF EXISTS dbo.Surgeries;
	-- GO
	
CREATE TABLE dbo.Surgeries(
	TreatmentNo NVARCHAR(20) NOT NULL 
	CONSTRAINT pkTreatmentNoSurgeries PRIMARY KEY CLUSTERED (TreatmentNo ASC),
	PatientNo NVARCHAR(20) CONSTRAINT fkPatientNoSurgeries 
	REFERENCES dbo.Patients (PatientNo) ON DELETE CASCADE ON UPDATE CASCADE,
	VisitDate DATETIME2(0) NOT NULL,
	Content NVARCHAR(MAX) NOT NULL CONSTRAINT ckContentSurgeries CHECK (ISJSON(Content) = 1),
	Creator NVARCHAR(MAX) NOT NULL CONSTRAINT ckCreatorSurgeries CHECK (ISJSON(Creator) = 1),
	CreatedAt DATETIME2(0) NOT NULL,
	Consumers NVARCHAR(MAX) NOT NULL CONSTRAINT ckConsumersSurgeries CHECK (ISJSON(Consumers) = 1)
	);
GO

---------------------------------------------------------------
------- Payments ----------------------------------------------
---------------------------------------------------------------

	-- DROP TABLE IF EXISTS dbo.Payments;
	-- GO
	
	-- [Account Bill,Extra Bill,Extra Bill Account,Extra Bill CASH,Extra Bill Insurance,Insurance Bill,IPD Round Bill,Visit Bill,Visit Bill CASH]

CREATE TABLE dbo.Payments(
	BillNo NVARCHAR(20) NOT NULL CONSTRAINT pkBillNoPayments PRIMARY KEY,
	PayNo NVARCHAR(20) NOT NULL,
	PayType NVARCHAR(100) NOT NULL, 
	ContentSent NVARCHAR(MAX) NOT NULL CONSTRAINT ckContentSentPayments CHECK (ISJSON(ContentSent) = 1),
	Creator NVARCHAR(MAX) NOT NULL CONSTRAINT ckCreatorPayments CHECK (ISJSON(Creator) = 1),
	CreatedAt DATETIME2(0) NOT NULL,
	Outbox NVARCHAR(MAX) CONSTRAINT ckOutboxPayments CHECK (ISJSON(Outbox) = 1), -- help to sync with message broker
	ContentReceived NVARCHAR(MAX) CONSTRAINT ckContentReceivedPayments CHECK (ISJSON(ContentReceived) = 1),
	Consumers NVARCHAR(MAX) NOT NULL CONSTRAINT ckConsumersPayments CHECK (ISJSON(Consumers) = 1),
	Completed BIT
	);
GO

---------------------------------------------------------------
------- MedicalReports ----------------------------------------
---------------------------------------------------------------

	-- DROP TABLE IF EXISTS dbo.MedicalReports;
	-- GO
	
CREATE TABLE dbo.MedicalReports(
	FacilityCode NVARCHAR(20) NOT NULL,
	VisitNo NVARCHAR(20) NOT NULL,
	CONSTRAINT pkFacilityCodeVisitNoMedicalReports PRIMARY KEY(FacilityCode, VisitNo),	
	VisitDate DATETIME2(0) NOT NULL,
	Content NVARCHAR(MAX) NOT NULL CONSTRAINT ckContentMedicalReports CHECK (ISJSON(Content) = 1),
	Creator NVARCHAR(MAX) NOT NULL CONSTRAINT ckCreatorMedicalReports CHECK (ISJSON(Creator) = 1),
	CreatedAt DATETIME2(0) NOT NULL,
	Consumers NVARCHAR(MAX) NOT NULL CONSTRAINT ckConsumersMedicalReports CHECK (ISJSON(Consumers) = 1)
	);
GO
