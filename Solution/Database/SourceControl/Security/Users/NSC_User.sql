IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'NSC_User')
CREATE LOGIN [NSC_User] WITH PASSWORD = 'p@ssw0rd'
GO
CREATE USER [NSC_User] FOR LOGIN [NSC_User]
GO
