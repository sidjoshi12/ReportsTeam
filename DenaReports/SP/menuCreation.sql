


--insert SysReportDirectory
--(SeqNo,ReportID,ReportType,ReportRdlName,ReportUrl,VersionNo,Remark,DeploymentDt,Frequency_Period,Deploy,Deploy_Prod,ReportMenuId,ReportRdlFullName,ReportFieldDisplay,DeptReportNo,RBI_ReportNo,CRisMacReportNo,ReportFrequency_Key,ReportingDay,ReportOwnerMain,ReportOwnerAlternate,SubmissionType,FirstReportGenerationDate,NextEntityCreationDate,DaysToGenerate,AdvReminderInDays,AdvReminderRecipient,AdvReminderCopyTo,AdvReminderSubject,AdvReminderText,Reminder1_InDays,Reminder1_Recipient,Reminder1_CopyTo,Reminder1_Subject,Reminder1_Text,Reminder2_InDays,Reminder2_Recipient,Reminder2_CopyTo,Reminder2_Subject,Reminder2_Text,RBI_Recipient,RBI_CopyTo,RBI_Subject,RBI_Text,Monitoring_Required,Ch_RptFrequency_EffectiveDate,EffectiveFromTimeKey,EffectiveToTimeKey,CreatedBy,DateCreated,ModifyBy,DateModified,ApprovedBy,DateApproved,ExportReportId,ExportReportName,DeptGroupId,PreMoc)
--values(7777,'Rpt-7777',1,'AcWise',NULL,'1.0.0',NULL,NULL,NULL,NULL,NULL,7777,'Rpt-7777-AcWise',NULL,NULL,NULL,NULL,401,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1551,9999,'sid','22/nov/2019',NULL,NULL,NULL,NULL,'Rpt-7777','AcWise',NULL,'N')

select * from SysReportDirectory where SeqNo=7777
exec [Rpt-SysReportVersion] 
@ReportName='Rpt-7777-AcWise'
,@TimeKey=4655
